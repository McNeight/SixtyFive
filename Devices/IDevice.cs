/*
 * IDevice.cs 
 *
 * Defines interface for devices accessable via the AddressSpace class.
 *
 * Copyright (c) 2003 Mike Murphy
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */

using System;

namespace SixtyFive {

	public interface IDevice 
	{
		void Reset();

		byte this[ushort addr] 
		{
			get;
			set;
		}

		void DebugWrite(ushort addr, byte data);		byte DebugRead(ushort addr);
		

	}
}
