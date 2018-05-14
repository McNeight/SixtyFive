/*
 * AddressSpace.cs
 *
 * The class modeling an AddressSpace.
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
using System.Collections;

namespace SixtyFive
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AddressSpace
    {
        private Byte dataBusState;
        private ArrayList devices;
        public Machine machine;
        public BreakPoints breakpoint;

        /// <summary>
        /// 
        /// </summary>
        public Byte DataBusState
        {
            get
            {
                return dataBusState;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "AdrSpc";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        public void DebugWrite(UInt16 addr, Byte data)
        {
            AddressRange range;

            for (int i = 0; i < devices.Count; i++)
            {
                range = (AddressRange)devices[i];
                if (addr >= range.startAddress && addr <= range.endAddress)
                {
                    range.device.DebugWrite((UInt16)(addr - range.startAddress), data);
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public Byte DebugRead(UInt16 addr)
        {
            AddressRange range;
            Byte d = 0xFF;
            int i;

            for (i = 0; i < devices.Count; i++)
            {
                range = (AddressRange)devices[i];
                if (addr >= range.startAddress && addr <= range.endAddress)
                {
                    d = range.device.DebugRead((UInt16)(addr - range.startAddress));
                    break;
                }
            }
            return d;
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
                AddressRange range;
                int i;

                dataBusState = 0xFF;
                for (i = 0; i < devices.Count; i++)
                {
                    range = (AddressRange)devices[i];
                    if (addr >= range.startAddress && addr <= range.endAddress)
                    {
                        dataBusState = range.device[(UInt16)(addr - range.startAddress)];
                        break;
                    }
                }

                // Check for breakpoint
                if (breakpoint.CheckDataBreak(addr, 'R', dataBusState))
                    machine.stopped = true;

                return dataBusState;
            }
            set
            {
                AddressRange range;

                dataBusState = value;

                // Check for breakpoint
                if (breakpoint.CheckDataBreak(addr, 'W', dataBusState))
                    machine.stopped = true;

                for (int i = 0; i < devices.Count; i++)
                {
                    range = (AddressRange)devices[i];
                    if (addr >= range.startAddress && addr <= range.endAddress)
                    {
                        range.device[(UInt16)(addr - range.startAddress)] = dataBusState;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basea"></param>
        /// <param name="size"></param>
        /// <param name="device"></param>
        public void Map(UInt16 basea, int size, IDevice device)
        {
            AddressRange addr = new AddressRange
            {
                startAddress = basea,
                endAddress = (UInt16)(basea + size - 1),
                device = device
            };
            devices.Add(addr);
        }

        /// <summary>
        /// 
        /// </summary>
        public AddressSpace()
        {
            devices = new ArrayList();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearMem()
        {
            FillMem(0x0000, 0xFFFF, 0x00);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void ClearMem(UInt16 start, UInt16 end)
        {
            FillMem(start, end, 0x00);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="data"></param>
        public void FillMem(UInt16 start, UInt16 end, Byte data)
        {
            int i;

            for (i = start; i <= end; i++)
                this.DebugWrite((UInt16)i, data);
        }
    }
}
