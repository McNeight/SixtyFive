/*
 * FileReader.cs 
 *
 * Handles reading various format files into simulated memory
 *
 * Copyright (c) 2004 Dan Boris
 * Copyright © 2018 Neil McNeight
 *
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */

using System;
using System.IO;

namespace SixtyFive
{
    public enum FileType : int { BinaryRAW, BinaryORG, RAS, Srecord, TEKHex }

    public class FileReader
    {
        // File handler objects
        private FileStream fs;
        private BinaryReader br;
        private StreamReader sr;

        // Load parameters
        private FileType type;
        private UInt16 curAddress;

        // Address space to load into
        private AddressSpace addrspace;

        public string errmsg;

        public void StartAddress(UInt16 addr)
        {
            curAddress = addr;
        }

        public FileReader(AddressSpace addr)
        {
            addrspace = addr;
            errmsg = "";
        }

        public void writemem(UInt16 addr, byte data)
        {
            addrspace.DebugWrite(addr, data);
        }

        // Read a RAS file
        public void readRAS()
        {
            int RASlen = 0;
            byte data;

            while (fs.Position != fs.Length)
            {
                // If this chunk is done, get next header
                if (RASlen == 0)
                {
                    curAddress = readLSBMSB();
                    RASlen = readLSBMSB();
                }

                // Read data
                data = br.ReadByte();
                writemem(curAddress, data);
                curAddress++;
                RASlen--;
            }
        }

        // Read a byte from the current RAW or ORG binary file
        public bool readBinaryRAW()
        {
            byte data;
            bool overflow = false;

            // If ORG file type, get origin address
            if (type == FileType.BinaryORG)
                curAddress = readLSBMSB();

            // Check for EOF
            while (fs.Position != fs.Length)
            {
                // Check for memory overflow
                if (overflow)
                {
                    errmsg = "Load past end of memory";
                    return false;
                }

                // Read byte and write it to memory
                data = br.ReadByte();
                writemem(curAddress, data);

                // Check for overflow then increment address
                if (curAddress == 0xFFFF)
                    overflow = true;
                curAddress++;
            }
            return true;
        }

        // Read an 16-bit value from the file in LSB/MSB format
        public UInt16 readLSBMSB()
        {
            UInt16 a;
            UInt16 d1;

            try
            {
                d1 = (UInt16)br.ReadByte();
                a = (UInt16)((UInt16)br.ReadByte() * 256);
                a = (UInt16)(a + d1);
            }
            catch
            {
                a = 0xFFFF;
            }
            return a;
        }

        // Open a file
        public bool open(string filename)
        {
            // Try to create a file stream
            try
            {
                fs = new FileStream(filename, FileMode.Open);
            }
            catch
            {
                return false;
            }

            // Create the appropriate reader
            if (type == FileType.BinaryORG || type == FileType.BinaryRAW || type == FileType.RAS)
                br = new BinaryReader(fs);
            else
                sr = new StreamReader(fs);

            return true;
        }

        // Close the current file
        public void close()
        {
            if (br != null)
                br.Close();
            if (sr != null)
                sr.Close();
            fs.Close();
        }

        // Load a file into address space
        public bool LoadFile(string file, FileType typ, UInt16 start)
        {
            bool pass = true;

            type = typ;
            curAddress = start;

            // Attempt to open file
            if (!open(file))
            {
                errmsg = "Could not open file.";
                return false;
            }

            switch (type)
            {
                case FileType.BinaryRAW:
                case FileType.BinaryORG:
                    pass = readBinaryRAW();
                    break;
                case FileType.RAS:
                    readRAS();
                    break;
            }

            // Close file
            close();

            return pass;
        }
    }
}
