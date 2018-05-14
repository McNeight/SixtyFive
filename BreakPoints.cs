/*
 * BreakPoint.cs 
 *
 * Breakpoint handling
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
    [Serializable]
    public class DataBreak
    {
        public UInt16 address;      // Address of break point
        public Byte data;           // Data to watch for
        public bool anydata;        // True = look for any data
        public char readwrite;      // R = read, W = write

        // Generate a key for this break point
        public string key()
        {
            string k;

            k = string.Format("{0}{1:X4}", readwrite, address);
            if (!anydata)
                k = k + string.Format("{0:X2}", data);
            return k;
        }

        // Generate a display of this break point
        public override string ToString()
        {
            string s;

            s = string.Format("{0}: {1:X4}", readwrite, address);
            if (!anydata)
                s = s + string.Format(" {0:X2}", data);
            return s;
        }
    }

    public class BreakPoints
    {
        public Hashtable AddressBreak;      // Table of address breaks
        public bool enableAddressBreak;     // True = use address breaks
        public Hashtable DataBreak;         // Table of data breaks
        public bool enableDataBreak;        // True = use data breaks

        public BreakPoints()
        {
            AddressBreak = new Hashtable();
            DataBreak = new Hashtable();
            enableAddressBreak = false;
            enableDataBreak = false;
        }

        #region "DataBreaks"

        /*-------------------------------------------------------------------------
		 * CheckDataBreak(addr, readwrite, data)
		 *	Function: Checks for a data break
		 *  Parameters: addr = address of read or write
		 *				readwrite: R = Read/W = Write
		 *				data = data to look for
		 * ------------------------------------------------------------------------*/
        public bool CheckDataBreak(UInt16 addr, char readwrite, Byte data)
        {
            string key;

            // Check if data breaks are enables
            if (!enableDataBreak)
                return false;

            // Check for non-data dependant break
            key = string.Format("{0}{1:X4}", readwrite, addr);
            if (DataBreak.ContainsKey(key))
                return true;

            // Check for data dependant break
            key = key + string.Format("{0:X2}", data);
            if (DataBreak.ContainsKey(key))
                return true;

            // No break found
            return false;
        }

        /*---------------------------------------------------------------------------
		 * AddDateBreak(addr, readwrite, data, anydata)
		 *	Function: Adds a new data break
		 *	Parameters: addr = address
		 *				readwrite: R = read/W = write
		 *				data: Data to look for
		 *				anydata: true = look for any data
		 *---------------------------------------------------------------------------*/

        public void AddDataBreak(UInt16 addr, char readwrite, Byte data, bool anydata)
        {
            DataBreak db = new DataBreak
            {
                address = addr,
                readwrite = readwrite,
                data = data,
                anydata = anydata
            };
            DataBreak.Add(db.key(), db);
        }

        /*---------------------------------------------------------------------------
		 * RemoveDataBreak(key)
		 *	Function: Removes a specific data break
		 *	Parameters: key = key of break to remove
		 *---------------------------------------------------------------------------*/
        public void RemoveDataBreak(string key)
        {
            if (DataBreak.ContainsKey(key))
                DataBreak.Remove(key);
        }

        /*---------------------------------------------------------------------------
		 * RemoveAllDataBreak(key)
		 *	Function: Removes all data breaks
		 *---------------------------------------------------------------------------*/
        public void RemoveAllDataBreak()
        {
            DataBreak.Clear();
        }

        #endregion

        #region "AddressBreaks"

        public bool CheckAddrBreak(UInt16 a)
        {
            if (!enableAddressBreak)
                return false;
            if (AddressBreak.ContainsKey(a))
                return true;
            return false;
        }

        public void AddAddressBreak(UInt16 a)
        {
            AddressBreak.Add(a, a);
        }

        public void RemoveAddressBreak(UInt16 a)
        {
            if (AddressBreak.ContainsKey(a))
                AddressBreak.Remove(a);
        }

        public void RemoveAllAddressBreak()
        {
            AddressBreak.Clear();
        }

        #endregion

    }
}
