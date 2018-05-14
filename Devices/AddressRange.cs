/*
 * AddressRange.cs
 *
 * The class modeling an AddressRange.
 *
 * Copyright (c) 2004 Dan Boris
 * Copyright © 2018 Neil McNeight
 *  
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */

using System;

namespace SixtyFive
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressRange
    {
        public UInt16 startAddress;
        public UInt16 endAddress;
        public IDevice device;
    }
}
