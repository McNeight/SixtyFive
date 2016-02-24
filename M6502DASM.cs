/*
 * M6502DASM.cs
 * 
 * Provides disassembly services.
 * 
 * Copyright (c) 2003 Mike Murphy
 * 
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */

using System;
using System.Text;

namespace sim6502 {

public class M6502DASM {
	private AddressSpace Mem;
	private M6502 CPU;

	private delegate string OpcodeHandler();
	public string GetRegisters() {
		string flags = "nv0bdizcNV1BDIZC";
		for (int i=0; i < 8; i++) {

	public string Disassemble(ushort atAddr) {
		{

	public string MemDump(ushort atAddr, ushort untilAddr) {

	public M6502DASM(AddressSpace mem, M6502 cpu) {
		Mem = mem;
		CPU = cpu;
		InstallOpcodeHandlers();
	}

	// Relative: Bxx $aa  (branch instructions only)
	// Zero Page Indexed,X: $aa,X
	// Zero Page Indexed,Y: $aa,Y
	// Absolute: $aaaa
		addr |= (ushort)(Mem.DebugRead(dPC++) << 8);
	// Absolute Indexed,X: $aaaa,X
	// Absolute Indexed,Y: $aaaa,Y
	// Indexed Indirect: ($aa,X)
	// Indirect Indexed: ($aa),Y
	// Indirect Absolute: ($aaaa)    (FYI:only used by JMP)
		addr |= (ushort)(Mem.DebugRead(dPC++) << 8);
	// Immediate: #xx
	string opXX() { return "?ILL?"; }
	string op84() { return "STY" + D_ZPG(); }

}