/*
 * IDevice.cs 
 *
 * Defines interface for devices accessable via the AddressSpace class.
 *
 * Copyright (c) 2003 Mike Murphy
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
    public interface IDevice
    {
        /// <summary>
        /// 
        /// </summary>
        void Reset();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        Byte this[UInt16 addr]
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        void DebugWrite(UInt16 addr, Byte data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        Byte DebugRead(UInt16 addr);

    }
}
