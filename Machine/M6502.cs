/* * M6502.cs * * CPU emulator for the MOS Technology 6502 microprocessor. * 
 * Copyright (c) 2003 Mike Murphy * Modified 2004 Dan Boris *  
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 * *  */using System;using System.Text;using System.Collections;
namespace SixtyFive {
public sealed class M6502 {	private AddressSpace Mem;	private Machine machine;	private int instruction_count;
	private delegate void OpcodeHandler();	private OpcodeHandler[] Opcodes = new OpcodeHandler[256];
	// There is jamming behavior to be implemented
	private bool IsJammed;
	
	public enum Flags : byte
	{
		C = 0x01, Z = 0x02, I = 0x04, D = 0x08, B = 0x10, V = 0x40, N = 0x80
	}

	private const ushort		NMI_VEC = 0xfffa,       // non-maskable interrupt vector		RST_VEC = 0xfffc,       // reset vector		IRQ_VEC = 0xfffe;       // interrupt request vector	public ulong Clock;
	// 16-bit register	public ushort		PC;         // program counter
	// 8-bit registers	public byte		A,          // accumulator		X,          // x index register		Y,          // y index register		S,          // stack pointer		P;          // processor status
	public M6502DASM Disassembler;

	public void Reset() {		IsJammed = false;
		// clear the stack		S = 0xff;
		// reset the program counter		PC = WORD(Mem[RST_VEC], Mem[RST_VEC + 1]);	}
	public override String ToString() {		return "M6502 CPU";	}
	public void Execute(int count) {		int n;		instruction_count = count;		while (instruction_count-- > 0) {						// Handle Interrupts			n = machine.interrupt();			if (n == 2) Trigger_NMI_interrupt();			if (n == 1 && !fI) Trigger_IRQ_interrupt();			if (IsJammed) {				break;			} else {				Opcodes[Mem[PC++]]();			}		}	}	public void Stop() {		instruction_count = 0;	}

	public void Trigger_IRQ_interrupt() {		interrupt(IRQ_VEC, true);	}
	public void Trigger_NMI_interrupt() {		interrupt(NMI_VEC, true);	}	public M6502(AddressSpace mem) {		Mem = mem;
		InstallOpcodes();
		// be safe; some devices capture clocks w/negative offsets		Clock = 9;
		// force explicit Reset() to get CPU going		IsJammed = false;
		// initialize processor status, bit 5 is always set		P = 1 << 5;		Disassembler = new M6502DASM(mem, this);
		
		machine = mem.machine;	}
	byte MSB(ushort u16) {		return (byte)(u16 >> 8);	}
	byte LSB(ushort u16) {		return (byte)u16;	}
	ushort WORD(byte lsb, byte msb) {		return (ushort)(lsb | msb << 8);	}
	// Processor Status Flag Bits	//

	// Flag bit setters and getters
	void fset(byte flag, bool value) {		P = (byte)(value ? P | flag : P & ~flag);	}
	bool fget(byte flag) {		return (P & flag) != 0;	}	// Carry: set if the add produced a carry, if the subtraction	//      produced a borrow.  Also used in shift instructions.
	bool fC {		get {   return fget(1 << 0);  }		set {   fset(1 << 0, value);  }	}	
	// Zero: set if the result of the last operation was zero
	bool fZ {		get {   return fget(1 << 1);  }		set {   fset(1 << 1, value);  }	}
	// Irq Disable: set if maskable interrupts are disabled
	bool fI {		get {   return fget(1 << 2);  }		set {   fset(1 << 2, value);  }	}
	// Decimal Mode: set if decimal mode active
	bool fD {		get {   return fget(1 << 3);  }		set {   fset(1 << 3, value);  }	}
	// Brk: set if an interrupt caused by a BRK instruction,	//      reset if caused by an internal interrupt
	bool fB {		get {   return fget(1 << 4);  }		set {   fset(1 << 4, value);  }	}
	// Overflow: set if the addition of two-like-signed numbers	//      or the subtraction of two unlike-signed numbers	//      produces a result greater than +127 or less than -128.
	bool fV {		get {   return fget(1 << 6);  }		set {   fset(1 << 6, value);  }	}
	// Negative: set if bit 7 of the accumulator is set
	bool fN {		get {   return fget(1 << 7);  }		set {   fset(1 << 7, value);  }	}
	void set_fNZ(byte u8) {		fN = (u8 & 0x80) != 0;		fZ = (u8 & 0xff) == 0;	}
	byte pull() {		S++;		return Mem[(ushort)(0x0100 + S)];	}
	void push(byte data) {		Mem[(ushort)(0x0100 + S)] = data;		S--;	}
	void clk(int ticks) {		Clock += (ulong)ticks;	}
	void interrupt(ushort intr_vector, bool isExternal) {		if (isExternal) {			fB = false;			clk(7);   // charge clks for external interrupts		} else {			fB = true;			PC++;		}		push(MSB(PC));		push(LSB(PC));		push(P);		fI = true;		byte lsb = Mem[intr_vector];		intr_vector++;		byte msb = Mem[intr_vector];		PC = WORD(lsb, msb);	}
	void br(bool cond, ushort ea) {		if (cond) {			clk( (MSB(PC) == MSB(ea)) ? 1 : 2 );			PC = ea;		}	}

	// Relative: Bxx $aa  (branch instructions only)	ushort aREL() {		sbyte bo = (sbyte)Mem[PC];		PC++;		return (ushort)(PC + bo);	}
	// Zero Page: $aa	ushort aZPG() {		return WORD(Mem[PC++], 0x00);	}
	// Zero Page Indexed,X: $aa,X	ushort aZPX() {		return WORD((byte)(Mem[PC++] + X), 0x00);	}
	// Zero Page Indexed,Y: $aa,Y	ushort aZPY() {		return WORD((byte)(Mem[PC++] + Y), 0x00);	}
	// Absolute: $aaaa	ushort aABS() {		byte lsb = Mem[PC++];		byte msb = Mem[PC++];		return WORD(lsb, msb);	}
	// Absolute Indexed,X: $aaaa,X	ushort aABX(int eclk) {		ushort ea = aABS();
		if (LSB(ea) + X > 0xff) {			clk(eclk);		}		return (ushort)(ea + X);	}
	// Absolute Indexed,Y: $aaaa,Y	ushort aABY(int eclk) {		ushort ea = aABS();
		if (LSB(ea) + Y > 0xff) {			clk(eclk);		}
		return (ushort)(ea + Y);	}
	// Indexed Indirect: ($aa,X)	ushort aIDX() {;		byte zpa = (byte)(Mem[PC++] + X);		byte lsb = Mem[zpa++];		byte msb = Mem[zpa];		return WORD(lsb, msb);
	}
	// Indirect Indexed: ($aa),Y	ushort aIDY(int eclk) {		byte zpa = Mem[PC++];		byte lsb = Mem[zpa++];		byte msb = Mem[zpa];
		if (lsb + Y > 0xff) {			clk(eclk);		}
		return (ushort)(WORD(lsb, msb) + Y);	}
	// Indirect Absolute: ($aaaa)    (only used by JMP)	ushort aIND() {		ushort ea = aABS();		byte lsb = Mem[ea];		ea = WORD((byte)(LSB(ea) + 1), MSB(ea));  // emulate bug		byte msb = Mem[ea];		return WORD(lsb, msb);	}
	// aACC = Accumulator	// aIMM = Immediate	// aIMP = Implied
	// ADC: Add with carry	void iADC(byte mem) {		int c = fC ? 1 : 0;		if (fD) {			int lo = (A & 0x0f) + (mem & 0x0f) + c;			int hi = (A & 0xf0) + (mem & 0xf0);			fZ = ((lo + hi) & 0xff) == 0;			if (lo > 0x09) {				lo += 0x06;				hi += 0x10;			}			fN = (hi & 0x80) != 0;			fV = (~(A^mem) & (A^hi) & 0x80) != 0;			if (hi > 0x90) {				hi += 0x60;			}			fC = (hi & 0xff00) != 0;			A = (byte)((lo & 0x0f) | (hi & 0xf0));		} else {			int sum = A + mem + c;			fV = (~(A^mem) & (A^sum) & 0x80) != 0;			fC = (sum & 0x100) != 0;			A = (byte)sum;			set_fNZ(A);		}	}
	// AND: Logical and	void iAND(byte mem) {		A &= mem;		set_fNZ(A);	}
	// ASL: Arithmetic shift left: C <- [7][6][5][4][3][2][1][0] <- 0	byte iASL(byte mem) {		fC = (mem & 0x80) != 0;		mem <<= 1;		set_fNZ(mem);		return mem;	}
	// BIT: Bit test	void iBIT(byte mem) {		fN = (mem & 0x80) != 0;		fV = (mem & 0x40) != 0;		fZ = (mem & A) == 0;	}
	// BRK Force Break  (cause software interrupt)	void iBRK() {		interrupt(IRQ_VEC, false);	}
	// CLC: Clear carry flag	void iCLC() {		fC = false;	}
	// CLD: Clear decimal mode	void iCLD() {		fD = false;	}
	// CLI: Clear interrupt disable */	void iCLI() {		fI = false;	}
	// CLV: Clear overflow flag	void iCLV() {		fV = false;	}
	// CMP: Compare accumulator	void iCMP(byte mem) {		fC = A >= mem;		set_fNZ((byte)(A - mem));	}
	// CPX: Compare index X	void iCPX(byte mem) {		fC = X >= mem;		set_fNZ((byte)(X - mem));	}
	// CPY: Compare index Y	void iCPY(byte mem) {		fC = Y >= mem;		set_fNZ((byte)(Y - mem));	}
	// DEC: Decrement memory	byte iDEC(byte mem) {		mem--;		set_fNZ(mem);		return mem;	}
	// DEX: Decrement index x	void iDEX() {		X--;		set_fNZ(X);	}
	// DEY: Decrement index y	void iDEY() {		Y--;		set_fNZ(Y);	}
	// EOR: Logical exclusive or	void iEOR(byte mem) {		A ^= mem;		set_fNZ(A);	}
	// INC: Increment memory	byte iINC(byte mem) {		mem++;		set_fNZ(mem);		return mem;	}
	// INX: Increment index x	void iINX() {		X++;		set_fNZ(X);	}
	// INY: Increment index y	void iINY() {		Y++;		set_fNZ(Y);	}
	// JMP Jump to address	void iJMP(ushort ea) {		PC = ea;	}
	// JSR Jump to subroutine	void iJSR(ushort ea) {		PC--;           // Yes, the 6502/7 really does this		push(MSB(PC));		push(LSB(PC));		PC = ea;	}
	// LDA: Load accumulator	void iLDA(byte mem) {		A = mem;		set_fNZ(A);	}
	// LDX: Load index X	void iLDX(byte mem) {		X = mem;		set_fNZ(X);	}
	// LDY: Load index Y	void iLDY(byte mem) {		Y = mem;		set_fNZ(Y);	}
	// LSR: Logic shift right: 0 -> [7][6][5][4][3][2][1][0] -> C	byte iLSR(byte mem) {		fC = (mem & 0x01) != 0;		mem >>= 1;		set_fNZ(mem);		return mem;	}
	// NOP: No operation	void iNOP() {	}
	// ORA: Logical inclusive or	void iORA(byte mem) {		A |= mem;		set_fNZ(A);	}
	// PHA: Push accumulator	void iPHA() {		push(A);	}
	// PHP: Push processor status (flags)	void iPHP() {		push(P);	}
	// PLA: Pull accumuator	void iPLA() {		A = pull();		set_fNZ(A);	}
	// PLP: Pull processor status (flags)	void iPLP() {		P = pull();		fB = true;	}
	// ROL: Rotate left: new C <- [7][6][5][4][3][2][1][0] <- C	byte iROL(byte mem) {		byte d0 = (byte)(fC ? 0x01 : 0x00);
		fC = (mem & 0x80) != 0;		mem <<= 1;		mem |= d0;		set_fNZ(mem);		return mem;	}
	// ROR: Rotate right: C -> [7][6][5][4][3][2][1][0] -> new C	byte iROR(byte mem) {		byte d7 = (byte)(fC ? 0x80 : 0x00);
		fC = (mem & 0x01) != 0;		mem >>= 1;		mem |= d7;		set_fNZ(mem);		return mem;	}
	// RTI: Return from interrupt	void iRTI() {		P = pull();		byte lsb = pull();		byte msb = pull();		PC = WORD(lsb, msb);		fB = true;	}
	// RTS: Return from subroutine	void iRTS() {		byte lsb = pull();		byte msb = pull();		PC = WORD(lsb, msb);		PC++;                   // Yes, the 6502/7 really does this	}
	// SBC: Subtract with carry (borrow)	void iSBC(byte mem) {		int c   = fC ? 0 : 1;		int sum = A - mem - c;
		if (fD) {			int lo  = (A & 0x0f) - (mem & 0x0f) - c;			int hi  = (A & 0xf0) - (mem & 0xf0);			if ((lo & 0x10) != 0) {				lo -= 0x06;				hi -= 0x01;			}			fV = ((A^mem) & 0x80) != 0 && ((sum^mem) & 0x80) == 0;			if ((hi & 0x0100) != 0) {				hi -= 0x60;			}			A = (byte)((lo & 0x0f) | (hi & 0xf0));		} else {			fV = ((A^mem) & 0x80) != 0 && ((sum^mem) & 0x80) == 0;	 		A = (byte)sum;		}		fC = (sum & 0x100) == 0;		set_fNZ(A);	}
	// SEC: Set carry flag	void iSEC() {		fC = true;	}
	// SED: Set decimal mode	void iSED() {		fD = true;	}
	// SEI: Set interrupt disable	void iSEI() {		fI = true;	}
	// STA: Store accumulator	byte iSTA() {		return A;	}
	// STX: Store index X	byte iSTX() {		return X;	}
	// STY: Store index Y	byte iSTY() {		return Y;	}
	// TAX: Transfer accumlator to index X	void iTAX() {		X = A;		set_fNZ(X);	}
	// TAY: Transfer accumlator to index Y	void iTAY() {		Y = A;		set_fNZ(Y);	}
	// TSX: Transfer stack to index X	void iTSX() {		X = S;		set_fNZ(X);	}
	// TXA: Transfer index X to accumlator	void iTXA() {		A = X;		set_fNZ(A);	}
	// TXS: Transfer index X to stack	void iTXS() {		S = X;		// No flags set..!  Weird, huh?	}
	// TYA: Transfer index Y to accumulator	void iTYA() {		A = Y;		set_fNZ(A);	}
	private ushort EA;
	void op65() { EA = aZPG();  clk(3); iADC(Mem[EA]); }	void op75() { EA = aZPX();  clk(4); iADC(Mem[EA]); }	void op61() { EA = aIDX();  clk(6); iADC(Mem[EA]); }	void op71() { EA = aIDY(1); clk(5); iADC(Mem[EA]); }	void op79() { EA = aABY(1); clk(4); iADC(Mem[EA]); }	void op6d() { EA = aABS();  clk(4); iADC(Mem[EA]); }	void op7d() { EA = aABX(1); clk(4); iADC(Mem[EA]); }	void op69() { /*aIMM*/      clk(2); iADC(Mem[PC++]);  }	void op25() { EA = aZPG();  clk(3); iAND(Mem[EA]); }	void op35() { EA = aZPX();  clk(4); iAND(Mem[EA]); }	void op21() { EA = aIDX();  clk(6); iAND(Mem[EA]); }	void op31() { EA = aIDY(1); clk(5); iAND(Mem[EA]); }	void op2d() { EA = aABS();  clk(4); iAND(Mem[EA]); }	void op39() { EA = aABY(1); clk(4); iAND(Mem[EA]); }	void op3d() { EA = aABX(1); clk(4); iAND(Mem[EA]); }	void op29() {    /*aIMM*/   clk(2); iAND(Mem[PC++]);  }	void op06() { EA = aZPG();  clk(5); Mem[EA] = iASL(Mem[EA]); }	void op16() { EA = aZPX();  clk(6); Mem[EA] = iASL(Mem[EA]); }	void op0e() { EA = aABS();  clk(6); Mem[EA] = iASL(Mem[EA]); }	void op1e() { EA = aABX(0); clk(7); Mem[EA] = iASL(Mem[EA]); }	void op0a() {    /*aACC*/   clk(2);      A = iASL(A);        }
	void op24() { EA = aZPG();  clk(3); iBIT(Mem[EA]); }	void op2c() { EA = aABS();  clk(4); iBIT(Mem[EA]); }
	void op10() { EA = aREL();  clk(2); br(!fN, EA); /* BPL */ }	void op30() { EA = aREL();  clk(2); br( fN, EA); /* BMI */ }	void op50() { EA = aREL();  clk(2); br(!fV, EA); /* BVC */ }	void op70() { EA = aREL();  clk(2); br( fV, EA); /* BVS */ }	void op90() { EA = aREL();  clk(2); br(!fC, EA); /* BCC */ }	void opb0() { EA = aREL();  clk(2); br( fC, EA); /* BCS */ }	void opd0() { EA = aREL();  clk(2); br(!fZ, EA); /* BNE */ }	void opf0() { EA = aREL();  clk(2); br( fZ, EA); /* BEQ */ }
	void op00() {    /*aIMP*/   clk(7); iBRK(); }	void op18() {    /*aIMP*/   clk(2); iCLC(); }
	void opd8() {    /*aIMP*/   clk(2); iCLD(); }
	void op58() {    /*aIMP*/   clk(2); iCLI(); }
	void opb8() {    /*aIMP*/   clk(2); iCLV(); }
	void opc5() { EA = aZPG();  clk(3); iCMP(Mem[EA]); }	void opd5() { EA = aZPX();  clk(4); iCMP(Mem[EA]); }	void opc1() { EA = aIDX();  clk(6); iCMP(Mem[EA]); }	void opd1() { EA = aIDY(1); clk(5); iCMP(Mem[EA]); }	void opcd() { EA = aABS();  clk(4); iCMP(Mem[EA]); }	void opdd() { EA = aABX(1); clk(4); iCMP(Mem[EA]); }	void opd9() { EA = aABY(1); clk(4); iCMP(Mem[EA]); }	void opc9() { /*aIMM*/      clk(2); iCMP(Mem[PC++]);  }
	void ope4() { EA = aZPG();  clk(3); iCPX(Mem[EA]); }	void opec() { EA = aABS();  clk(4); iCPX(Mem[EA]); }	void ope0() { /*aIMM*/      clk(2); iCPX(Mem[PC++]);  }
	void opc4() { EA = aZPG();  clk(3); iCPY(Mem[EA]); }	void opcc() { EA = aABS();  clk(4); iCPY(Mem[EA]); }	void opc0() { /*aIMM*/      clk(2); iCPY(Mem[PC++]);  }
	void opc6() { EA = aZPG();  clk(5); Mem[EA] = iDEC(Mem[EA]); }	void opd6() { EA = aZPX();  clk(6); Mem[EA] = iDEC(Mem[EA]); }	void opce() { EA = aABS();  clk(6); Mem[EA] = iDEC(Mem[EA]); }	void opde() { EA = aABX(0); clk(7); Mem[EA] = iDEC(Mem[EA]); }
	void opca() {    /*aIMP*/   clk(2); iDEX(); }
	void op88() {    /*aIMP*/   clk(2); iDEY(); }
	void op45() { EA = aZPG();  clk(3); iEOR(Mem[EA]); }	void op55() { EA = aZPX();  clk(4); iEOR(Mem[EA]); }	void op41() { EA = aIDX();  clk(6); iEOR(Mem[EA]); }	void op51() { EA = aIDY(1); clk(5); iEOR(Mem[EA]); }	void op4d() { EA = aABS();  clk(4); iEOR(Mem[EA]); }	void op5d() { EA = aABX(1); clk(4); iEOR(Mem[EA]); }	void op59() { EA = aABY(1); clk(4); iEOR(Mem[EA]); }	void op49() {    /*aIMM*/   clk(2); iEOR(Mem[PC++]);   }
	void ope6() { EA = aZPG();  clk(5); Mem[EA] = iINC(Mem[EA]); }	void opf6() { EA = aZPX();  clk(6); Mem[EA] = iINC(Mem[EA]); }	void opee() { EA = aABS();  clk(6); Mem[EA] = iINC(Mem[EA]); }	void opfe() { EA = aABX(0); clk(7); Mem[EA] = iINC(Mem[EA]); }
	void ope8() {    /*aIMP*/   clk(2); iINX(); }
	void opc8() {    /*aIMP*/   clk(2); iINY(); }
	void opa5() { EA = aZPG();  clk(3); iLDA(Mem[EA]); }	void opb5() { EA = aZPX();  clk(4); iLDA(Mem[EA]); }	void opa1() { EA = aIDX();  clk(6); iLDA(Mem[EA]); }	void opb1() { EA = aIDY(1); clk(5); iLDA(Mem[EA]); }	void opad() { EA = aABS();  clk(4); iLDA(Mem[EA]); }	void opbd() { EA = aABX(1); clk(4); iLDA(Mem[EA]); }	void opb9() { EA = aABY(1); clk(4); iLDA(Mem[EA]); }	void opa9() {    /*aIMM*/   clk(2); iLDA(Mem[PC++]);  }
	void opa6() { EA = aZPG();  clk(3); iLDX(Mem[EA]); }	void opb6() { EA = aZPY();  clk(4); iLDX(Mem[EA]); }	void opae() { EA = aABS();  clk(4); iLDX(Mem[EA]); }	void opbe() { EA = aABY(1); clk(4); iLDX(Mem[EA]); }	void opa2() {    /*aIMM*/   clk(2); iLDX(Mem[PC++]);  }
	void opa4() { EA = aZPG();  clk(3); iLDY(Mem[EA]); }	void opb4() { EA = aZPX();  clk(4); iLDY(Mem[EA]); }	void opac() { EA = aABS();  clk(4); iLDY(Mem[EA]); }	void opbc() { EA = aABX(1); clk(4); iLDY(Mem[EA]); }	void opa0() {    /*aIMM*/   clk(2); iLDY(Mem[PC++]);  }
	void op46() { EA = aZPG();  clk(5); Mem[EA] = iLSR(Mem[EA]); }	void op56() { EA = aZPX();  clk(6); Mem[EA] = iLSR(Mem[EA]); }	void op4e() { EA = aABS();  clk(6); Mem[EA] = iLSR(Mem[EA]); }	void op5e() { EA = aABX(0); clk(7); Mem[EA] = iLSR(Mem[EA]); }	void op4a() {    /*aACC*/   clk(2);       A = iLSR(A);         }
	void op4c() { EA = aABS();  clk(3); iJMP(EA); }	void op6c() { EA = aIND();  clk(5); iJMP(EA); }
	void op20() { EA = aABS();  clk(6); iJSR(EA); }
	void opea() {    /*aIMP*/   clk(2); iNOP(); }
	void op05() { EA = aZPG();  clk(3); iORA(Mem[EA]); }	void op15() { EA = aZPX();  clk(4); iORA(Mem[EA]); }	void op01() { EA = aIDX();  clk(6); iORA(Mem[EA]); }	void op11() { EA = aIDY(1); clk(5); iORA(Mem[EA]); }	void op0d() { EA = aABS();  clk(4); iORA(Mem[EA]); }	void op1d() { EA = aABX(1); clk(4); iORA(Mem[EA]); }	void op19() { EA = aABY(1); clk(4); iORA(Mem[EA]); }	void op09() {    /*aIMM*/   clk(2); iORA(Mem[PC++]);  }
	void op48() {    /*aIMP*/   clk(3); iPHA(); }
	void op68() {    /*aIMP*/   clk(4); iPLA(); }
	void op08() {    /*aIMP*/   clk(3); iPHP(); }
	void op28() {    /*aIMP*/   clk(4); iPLP(); }
	void op26() { EA = aZPG();  clk(5); Mem[EA] = iROL(Mem[EA]); }	void op36() { EA = aZPX();  clk(6); Mem[EA] = iROL(Mem[EA]); }	void op2e() { EA = aABS();  clk(6); Mem[EA] = iROL(Mem[EA]); }	void op3e() { EA = aABX(0); clk(7); Mem[EA] = iROL(Mem[EA]); }	void op2a() {    /*aACC*/   clk(2);       A = iROL(A);       }
	void op66() { EA = aZPG();  clk(5); Mem[EA] = iROR(Mem[EA]); }	void op76() { EA = aZPX();  clk(6); Mem[EA] = iROR(Mem[EA]); }	void op6e() { EA = aABS();  clk(6); Mem[EA] = iROR(Mem[EA]); }	void op7e() { EA = aABX(0); clk(7); Mem[EA] = iROR(Mem[EA]); }	void op6a() {    /*aACC*/   clk(2);       A = iROR(A);       }
	void op40() {    /*aIMP*/   clk(6); iRTI(); }
	void op60() {    /*aIMP*/   clk(6); iRTS(); }
	void ope5() { EA = aZPG();  clk(3); iSBC(Mem[EA]); }	void opf5() { EA = aZPX();  clk(4); iSBC(Mem[EA]); }	void ope1() { EA = aIDX();  clk(6); iSBC(Mem[EA]); }	void opf1() { EA = aIDY(1); clk(5); iSBC(Mem[EA]); }	void oped() { EA = aABS();  clk(4); iSBC(Mem[EA]); }	void opfd() { EA = aABX(1); clk(4); iSBC(Mem[EA]); }	void opf9() { EA = aABY(1); clk(4); iSBC(Mem[EA]); }	void ope9() {    /*aIMM*/   clk(2); iSBC(Mem[PC++]);  }
	void op38() {    /*aIMP*/   clk(2); iSEC(); }
	void opf8() {    /*aIMP*/   clk(2); iSED(); }
	void op78() {    /*aIMP*/   clk(2); iSEI(); }
	void op85() { EA = aZPG();  clk(3); Mem[EA] = iSTA(); }	void op95() { EA = aZPX();  clk(4); Mem[EA] = iSTA(); }	void op81() { EA = aIDX();  clk(6); Mem[EA] = iSTA(); }	void op91() { EA = aIDY(0); clk(6); Mem[EA] = iSTA(); }	void op8d() { EA = aABS();  clk(4); Mem[EA] = iSTA(); }	void op99() { EA = aABY(0); clk(5); Mem[EA] = iSTA(); }	void op9d() { EA = aABX(0); clk(5); Mem[EA] = iSTA(); }
	void op86() { EA = aZPG();  clk(3); Mem[EA] = iSTX(); }	void op96() { EA = aZPY();  clk(4); Mem[EA] = iSTX(); }	void op8e() { EA = aABS();  clk(4); Mem[EA] = iSTX(); }
	void op84() { EA = aZPG();  clk(3); Mem[EA] = iSTY(); }	void op94() { EA = aZPX();  clk(4); Mem[EA] = iSTY(); }	void op8c() { EA = aABS();  clk(4); Mem[EA] = iSTY(); }
	void opaa() {    /*aIMP*/   clk(2); iTAX(); }
	void opa8() {    /*aIMP*/   clk(2); iTAY(); }
	void opba() {    /*aIMP*/   clk(2); iTSX(); }
	void op8a() {    /*aIMP*/   clk(2); iTXA(); }
	void op9a() {    /*aIMP*/   clk(2); iTXS(); }
	void op98() {    /*aIMP*/   clk(2); iTYA(); }
	void opXX() {	}
	private void InstallOpcodes() {		Opcodes[0x65] = new OpcodeHandler(op65);		Opcodes[0x75] = new OpcodeHandler(op75);		Opcodes[0x61] = new OpcodeHandler(op61);		Opcodes[0x71] = new OpcodeHandler(op71);		Opcodes[0x79] = new OpcodeHandler(op79);		Opcodes[0x6d] = new OpcodeHandler(op6d);		Opcodes[0x7d] = new OpcodeHandler(op7d);		Opcodes[0x69] = new OpcodeHandler(op69);		Opcodes[0x25] = new OpcodeHandler(op25);		Opcodes[0x35] = new OpcodeHandler(op35);		Opcodes[0x21] = new OpcodeHandler(op21);		Opcodes[0x31] = new OpcodeHandler(op31);		Opcodes[0x2d] = new OpcodeHandler(op2d);		Opcodes[0x39] = new OpcodeHandler(op39);		Opcodes[0x3d] = new OpcodeHandler(op3d);		Opcodes[0x29] = new OpcodeHandler(op29);		Opcodes[0x06] = new OpcodeHandler(op06);		Opcodes[0x16] = new OpcodeHandler(op16);		Opcodes[0x0e] = new OpcodeHandler(op0e);		Opcodes[0x1e] = new OpcodeHandler(op1e);		Opcodes[0x0a] = new OpcodeHandler(op0a);		Opcodes[0x24] = new OpcodeHandler(op24);		Opcodes[0x2c] = new OpcodeHandler(op2c);		Opcodes[0x10] = new OpcodeHandler(op10);		Opcodes[0x30] = new OpcodeHandler(op30);		Opcodes[0x50] = new OpcodeHandler(op50);		Opcodes[0x70] = new OpcodeHandler(op70);		Opcodes[0x90] = new OpcodeHandler(op90);		Opcodes[0xb0] = new OpcodeHandler(opb0);		Opcodes[0xd0] = new OpcodeHandler(opd0);		Opcodes[0xf0] = new OpcodeHandler(opf0);		Opcodes[0x00] = new OpcodeHandler(op00);		Opcodes[0x18] = new OpcodeHandler(op18);		Opcodes[0xd8] = new OpcodeHandler(opd8);		Opcodes[0x58] = new OpcodeHandler(op58);		Opcodes[0xb8] = new OpcodeHandler(opb8);		Opcodes[0xc5] = new OpcodeHandler(opc5);		Opcodes[0xd5] = new OpcodeHandler(opd5);		Opcodes[0xc1] = new OpcodeHandler(opc1);		Opcodes[0xd1] = new OpcodeHandler(opd1);		Opcodes[0xcd] = new OpcodeHandler(opcd);		Opcodes[0xdd] = new OpcodeHandler(opdd);		Opcodes[0xd9] = new OpcodeHandler(opd9);		Opcodes[0xc9] = new OpcodeHandler(opc9);		Opcodes[0xe4] = new OpcodeHandler(ope4);		Opcodes[0xec] = new OpcodeHandler(opec);		Opcodes[0xe0] = new OpcodeHandler(ope0);		Opcodes[0xc4] = new OpcodeHandler(opc4);		Opcodes[0xcc] = new OpcodeHandler(opcc);		Opcodes[0xc0] = new OpcodeHandler(opc0);		Opcodes[0xc6] = new OpcodeHandler(opc6);		Opcodes[0xd6] = new OpcodeHandler(opd6);		Opcodes[0xce] = new OpcodeHandler(opce);		Opcodes[0xde] = new OpcodeHandler(opde);		Opcodes[0xca] = new OpcodeHandler(opca);		Opcodes[0x88] = new OpcodeHandler(op88);		Opcodes[0x45] = new OpcodeHandler(op45);		Opcodes[0x55] = new OpcodeHandler(op55);		Opcodes[0x41] = new OpcodeHandler(op41);		Opcodes[0x51] = new OpcodeHandler(op51);		Opcodes[0x4d] = new OpcodeHandler(op4d);		Opcodes[0x5d] = new OpcodeHandler(op5d);		Opcodes[0x59] = new OpcodeHandler(op59);		Opcodes[0x49] = new OpcodeHandler(op49);		Opcodes[0xe6] = new OpcodeHandler(ope6);		Opcodes[0xf6] = new OpcodeHandler(opf6);		Opcodes[0xee] = new OpcodeHandler(opee);		Opcodes[0xfe] = new OpcodeHandler(opfe);		Opcodes[0xe8] = new OpcodeHandler(ope8);		Opcodes[0xc8] = new OpcodeHandler(opc8);		Opcodes[0xa5] = new OpcodeHandler(opa5);		Opcodes[0xb5] = new OpcodeHandler(opb5);		Opcodes[0xa1] = new OpcodeHandler(opa1);		Opcodes[0xb1] = new OpcodeHandler(opb1);		Opcodes[0xad] = new OpcodeHandler(opad);		Opcodes[0xbd] = new OpcodeHandler(opbd);		Opcodes[0xb9] = new OpcodeHandler(opb9);		Opcodes[0xa9] = new OpcodeHandler(opa9);		Opcodes[0xa6] = new OpcodeHandler(opa6);		Opcodes[0xb6] = new OpcodeHandler(opb6);		Opcodes[0xae] = new OpcodeHandler(opae);		Opcodes[0xbe] = new OpcodeHandler(opbe);		Opcodes[0xa2] = new OpcodeHandler(opa2);		Opcodes[0xa4] = new OpcodeHandler(opa4);		Opcodes[0xb4] = new OpcodeHandler(opb4);		Opcodes[0xac] = new OpcodeHandler(opac);		Opcodes[0xbc] = new OpcodeHandler(opbc);		Opcodes[0xa0] = new OpcodeHandler(opa0);		Opcodes[0x46] = new OpcodeHandler(op46);		Opcodes[0x56] = new OpcodeHandler(op56);		Opcodes[0x4e] = new OpcodeHandler(op4e);		Opcodes[0x5e] = new OpcodeHandler(op5e);		Opcodes[0x4a] = new OpcodeHandler(op4a);		Opcodes[0x4c] = new OpcodeHandler(op4c);		Opcodes[0x6c] = new OpcodeHandler(op6c);		Opcodes[0x20] = new OpcodeHandler(op20);		Opcodes[0xea] = new OpcodeHandler(opea);		Opcodes[0x05] = new OpcodeHandler(op05);		Opcodes[0x15] = new OpcodeHandler(op15);		Opcodes[0x01] = new OpcodeHandler(op01);		Opcodes[0x11] = new OpcodeHandler(op11);		Opcodes[0x0d] = new OpcodeHandler(op0d);		Opcodes[0x1d] = new OpcodeHandler(op1d);		Opcodes[0x19] = new OpcodeHandler(op19);		Opcodes[0x09] = new OpcodeHandler(op09);		Opcodes[0x48] = new OpcodeHandler(op48);		Opcodes[0x68] = new OpcodeHandler(op68);		Opcodes[0x08] = new OpcodeHandler(op08);		Opcodes[0x28] = new OpcodeHandler(op28);		Opcodes[0x26] = new OpcodeHandler(op26);		Opcodes[0x36] = new OpcodeHandler(op36);		Opcodes[0x2e] = new OpcodeHandler(op2e);		Opcodes[0x3e] = new OpcodeHandler(op3e);		Opcodes[0x2a] = new OpcodeHandler(op2a);		Opcodes[0x66] = new OpcodeHandler(op66);		Opcodes[0x76] = new OpcodeHandler(op76);		Opcodes[0x6e] = new OpcodeHandler(op6e);		Opcodes[0x7e] = new OpcodeHandler(op7e);		Opcodes[0x6a] = new OpcodeHandler(op6a);		Opcodes[0x40] = new OpcodeHandler(op40);		Opcodes[0x60] = new OpcodeHandler(op60);		Opcodes[0xe5] = new OpcodeHandler(ope5);		Opcodes[0xf5] = new OpcodeHandler(opf5);		Opcodes[0xe1] = new OpcodeHandler(ope1);		Opcodes[0xf1] = new OpcodeHandler(opf1);		Opcodes[0xed] = new OpcodeHandler(oped);		Opcodes[0xfd] = new OpcodeHandler(opfd);		Opcodes[0xf9] = new OpcodeHandler(opf9);		Opcodes[0xe9] = new OpcodeHandler(ope9);		Opcodes[0x38] = new OpcodeHandler(op38);		Opcodes[0xf8] = new OpcodeHandler(opf8);		Opcodes[0x78] = new OpcodeHandler(op78);		Opcodes[0x85] = new OpcodeHandler(op85);		Opcodes[0x95] = new OpcodeHandler(op95);		Opcodes[0x81] = new OpcodeHandler(op81);		Opcodes[0x91] = new OpcodeHandler(op91);		Opcodes[0x8d] = new OpcodeHandler(op8d);		Opcodes[0x99] = new OpcodeHandler(op99);		Opcodes[0x9d] = new OpcodeHandler(op9d);		Opcodes[0x86] = new OpcodeHandler(op86);		Opcodes[0x96] = new OpcodeHandler(op96);		Opcodes[0x8e] = new OpcodeHandler(op8e);		Opcodes[0x84] = new OpcodeHandler(op84);		Opcodes[0x94] = new OpcodeHandler(op94);		Opcodes[0x8c] = new OpcodeHandler(op8c);		Opcodes[0xaa] = new OpcodeHandler(opaa);		Opcodes[0xa8] = new OpcodeHandler(opa8);		Opcodes[0xba] = new OpcodeHandler(opba);		Opcodes[0x8a] = new OpcodeHandler(op8a);		Opcodes[0x9a] = new OpcodeHandler(op9a);		Opcodes[0x98] = new OpcodeHandler(op98);		for (int i=0; i < Opcodes.Length; i++) {			if (Opcodes[i] == null) {				Opcodes[i] = new OpcodeHandler(opXX);			}		}	}}}