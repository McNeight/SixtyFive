/*
 * DisasmViewer.cs
 *
 * SixtyFive Disassembly Viewer Form
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
using System.Drawing;
using System.Windows.Forms;

namespace SixtyFive.Viewers
{
    public partial class DisasmViewer : System.Windows.Forms.Form
    {
        public AddressSpace mem;
        public M6502 CPU;
        private M6502DASM dasm;

        public UInt16 startAddress;
        public UInt16 endAddress;

        public bool followPC = true;

        // Graphics objects
        private Bitmap gr;
        private Graphics g;

        // Drawing objects
        Font NormalFont;
        SolidBrush NormalFontBrush;
        SolidBrush CurAddressBrush;

        public DisasmViewer(AddressSpace Mem, M6502 Cpu)
        {
            // Setup form
            InitializeComponent();
            mem = Mem;
            CPU = Cpu;

            // Setup Addresses
            startAddress = 0;
            endAddress = startAddress;
            if (followPC)
                startAddress = CPU.PC;

            // Create disassembler object
            dasm = new M6502DASM(mem, CPU);

            // Setup drawing objects
            NormalFontBrush = new SolidBrush(Color.Black);
            CurAddressBrush = new SolidBrush(Color.Yellow);
            NormalFont = new Font("Courier New", 10);

            // Setup bitmap
            gr = new System.Drawing.Bitmap(376, 400);
            g = Graphics.FromImage(gr);
        }


        private void pbMem_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawImage(gr, 0, 0);
        }

        private void DisasmViewer_Load(object sender, System.EventArgs e)
        {
            pbMem.Focus();
        }

        public void SetCurrentAddress(UInt16 ad)
        {
            vsAddress.Value = ad;
        }

        private void vsAddress_ValueChanged(object sender, System.EventArgs e)
        {
            startAddress = (UInt16)(vsAddress.Value);
            update();
        }

        public void runupdate()
        {
            // Update the address if we are following the program counter
            if (followPC)
            {
                if (CPU.PC < startAddress || CPU.PC > endAddress)
                    startAddress = CPU.PC;
            }
            update();
        }

        public void SetSize()
        {
            // Set picture box width
            pbMem.Width = this.Width - 26;
            pbMem.Height = this.Height - 32;

            // Setup address scroller
            vsAddress.Left = pbMem.Width;
            vsAddress.Height = pbMem.Height;

            // Re-create graphics objects
            gr = new System.Drawing.Bitmap(pbMem.Width, pbMem.Height);
            g = Graphics.FromImage(gr);

            // Refresh the display
            update();
            pbMem.Refresh();
        }

        public void update()
        {
            int y, lines;
            string s;
            SizeF size;
            UInt16 addr;

            // Clear bitmap
            g.Clear(Color.LightGray);

            // Determine the size of a Byte
            size = g.MeasureString("0", NormalFont);

            // Determine the number of lines that will fit in the box
            lines = (int)Math.Floor(pbMem.Height / size.Height);

            addr = startAddress;
            for (y = 0; y < lines; y++)
            {
                // Hightlight program counter address
                if (addr == CPU.PC)
                    g.FillRectangle(CurAddressBrush, 0, y * size.Height, pbMem.Width, size.Height);

                // Disassemble and display line
                s = dasm.Disassemble(addr);
                g.DrawString(s, NormalFont, NormalFontBrush, 0, y * size.Height);

                // Check if we are at the end of memory
                if (dasm.dPC < addr)
                {
                    endAddress = 0xFFFF;
                    break;
                }

                endAddress = addr;

                // Next address
                addr = dasm.dPC;
            }
            pbMem.Refresh();
        }

        private void DisasmViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainForm parentFrm = (MainForm)this.MdiParent;

            if (parentFrm.bClosingEventFromParent == false)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void DisasmViewer_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                SetSize();
        }

    }
}
