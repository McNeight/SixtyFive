/*
 * machine.cs 
 *
 * Handles the virtual machine being simulated
 *
 * Copyright (c) 2004 Dan Boris
 * 
 *  
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 *
 */

using System;
using System.Drawing;
using System.IO;
using System.Collections;

namespace sim6502
{
	public class Machine 
	{	
		// CPU
		public M6502 cpu;
		public AddressSpace mem;
		public ArrayList Devices;

		// Execution control
		public bool stopped = false;
		public BreakPoints breakpoint;

		public Trace trace;
		
		// Machine object constructor
		public Machine() 
		{	
			// Setup address spave
			mem = new AddressSpace();
			mem.machine = this;

			// Setup CPU
			cpu = new M6502(mem);	
			breakpoint = new BreakPoints();
			trace = new Trace();
			mem.breakpoint = breakpoint;

			Devices = new ArrayList();
		}
		
		public int interrupt()
		{
			return 0;
		}

		// Run 1 instruction
		public void stepcpu()
		{
						// Handle tracing			if (trace.traceon) trace.write(cpu.Disassembler.Disassemble(cpu.PC));

			// Handle breakpoints
			if (breakpoint.CheckAddrBreak(cpu.PC)) 
			{
				stopped = true;
				return;
			}

			cpu.Execute(1);
		}
		
		// Reset the machine
		public void Reset()
		{
			cpu.Reset();
			stopped = false;
		}
		
		// Device handling

		public void AddDevice(IDevice dev)
		{
			Devices.Add(dev);
		}

		public void RemoveAllDevices()
		{
			Devices.Clear();
		}


	}
}
