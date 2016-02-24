/* * AddressSpace.cs * * The class modeling an AddressSpace. * * Copyright (c) 2004 Dan Boris *  
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 * * */using System;using System.Collections;
namespace sim6502 {
public class AddressRange {
	public ushort startAddress;
	public ushort endAddress;
	public IDevice device;
}

public sealed class AddressSpace {	private byte dataBusState;	private ArrayList devices;	public Machine machine;	public BreakPoints breakpoint;	public  byte DataBusState {		get {			return dataBusState;		}	}	public override string ToString() {		return "AdrSpc";	}		public void DebugWrite(ushort addr, byte data) 
	{		AddressRange range;		for (int i=0; i<devices.Count; i++) 
		{			range = (AddressRange)devices[i];			if (addr >= range.startAddress && addr <= range.endAddress) 
			{				range.device.DebugWrite((ushort)(addr - range.startAddress),data);				break;			}		}	}	public byte DebugRead(ushort addr) 	{		AddressRange range;		byte d=0xFF;		int i;					for (i=0; i<devices.Count; i++) 
		{			range = (AddressRange)devices[i];			if (addr >= range.startAddress && addr <= range.endAddress) 
			{				d = range.device.DebugRead((ushort)(addr - range.startAddress));				break;			}		}		return d;	}	public byte this[ushort addr] {		get {			AddressRange range;			int i;						dataBusState = 0xFF;			for (i=0; i<devices.Count; i++) 
			{				range = (AddressRange)devices[i];				if (addr >= range.startAddress && addr <= range.endAddress) {					dataBusState = range.device[(ushort)(addr - range.startAddress)];					break;				}			}						// Check for breakpoint			if (breakpoint.CheckDataBreak(addr,'R',dataBusState)) machine.stopped = true;			return dataBusState;		}		set {			AddressRange range;						dataBusState = value;			// Check for breakpoint			if (breakpoint.CheckDataBreak(addr,'W',dataBusState)) machine.stopped = true;			for (int i=0; i<devices.Count; i++) 
			{				range = (AddressRange)devices[i];				if (addr >= range.startAddress && addr <= range.endAddress) 
				{					range.device[(ushort)(addr - range.startAddress)] = dataBusState;					break;				}			}		}	}	public void Map(ushort basea, int size, IDevice device) {		AddressRange addr = new AddressRange();		addr.startAddress = basea;		addr.endAddress = (ushort)(basea + size-1);		addr.device = device;		devices.Add(addr);	}
	public AddressSpace() {		devices = new ArrayList();	}	public void ClearMem() 	{		FillMem(0x0000,0xFFFF,0x00);	}	public void ClearMem(ushort start, ushort end) 	{		FillMem(start,end,0x00);	}	public void FillMem(ushort start, ushort end, byte data) 	{		int i;				for (i=start; i<=end; i++) this.DebugWrite((ushort)i,data);	}}}
