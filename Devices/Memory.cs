/*
 * Memory.cs 
 *
 * Generic memory device.
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
    public class Memory : IDevice
    {
        private Byte[] mem;
        private int memsize;

        /// <summary>
        /// 
        /// </summary>
        public bool isROM;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public Memory(int size)
        {
            memsize = size;
            mem = new Byte[size];
            isROM = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < memsize; i++)
                mem[i] = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Memory";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        public void DebugWrite(UInt16 addr, Byte data)
        {
            mem[addr] = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public Byte DebugRead(UInt16 addr)
        {
            return mem[addr];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public Byte this[UInt16 addr]
        {
            get
            {
                return mem[addr];
            }
            set
            {
                if (!isROM)
                    mem[addr] = value;
            }
        }
    }
}
