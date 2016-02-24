/*
 * Memory.cs 
 *
 * Generic memory device.
 *
 * Copyright (c) 2004 Dan Boris
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */

using System;

namespace sim6502
{

	public class Memory : IDevice
	{
		private byte[] mem; 
		private int memsize;
		public bool isROM;

		public Memory(int size)
		{	
			memsize = size;
			mem = new byte[size];
			isROM = false;
		}

		public void Reset() { 
			for (int i=0; i<memsize; i++) mem[i] = 0;
		}


		public override string ToString() 
		{
			return "Memory";
		}

		public void DebugWrite(ushort addr, byte data)		{			mem[addr] = data;		}		public byte DebugRead(ushort addr)
		{
			return mem[addr];
		}

		public byte this[ushort addr] 
		{
			get 
			{
				return mem[addr];
			}
			set 
			{
				if (!isROM) mem[addr] = value;
			}
		}
	}
}
