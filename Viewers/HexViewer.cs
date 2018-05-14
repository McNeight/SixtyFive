/*
 * HexViewer.cs
 *
 * SixtyFive Hex Viewer Form
 * 
 * Copyright © 2018 Neil McNeight
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Byte;
using Be.Windows.Forms;

namespace SixtyFive
{
    public partial class HexViewer : Form
    {
        public UInt16 curAddress = 0;    // Currently displayed address
        public AddressSpace mem;      // Memory space to view

        // Editing 
        UInt16 EditAddress;

        MemoryByteProvider mb = new MemoryByteProvider();

        public HexViewer(AddressSpace Mem)
        {
            InitializeComponent();
            mem = Mem;

            hexBox1.ByteProvider = mb;
        }
    }
}
