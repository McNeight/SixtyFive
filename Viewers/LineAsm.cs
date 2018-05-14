/*
 * LineAsm.cs
 *
 * SixtyFive Line Assembler Viewer Form
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
using System.Windows.Forms;

namespace SixtyFive.Viewers
{
    public partial class LineAsm : System.Windows.Forms.Form
    {
        public AddressSpace mem;
        public M6502 CPU;

        private M6502DASM dasm;
        private Assembler asm;

        public LineAsm(AddressSpace Mem, M6502 Cpu)
        {
            // Setup form
            InitializeComponent();
            mem = Mem;
            CPU = Cpu;

            // Create assembler and disassembler objects
            dasm = new M6502DASM(mem, CPU);
            asm = new Assembler();

            // Init form fields
            txtLine.Text = "";
            txtAddr.Text = "1000";
        }


        private void LineAsm_Load(object sender, System.EventArgs e)
        {

        }

        private void txtLine_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // If enter is hit assemble the line
            if (e.KeyChar == (char)13)
            {
                AssembleLine();
            }
        }

        private void AssembleLine()
        {
            Byte[] b = new Byte[3];
            UInt16 i, addr;
            int n;

            // Get address
            try
            {
                addr = Convert.ToUInt16(txtAddr.Text.Trim(), 16);
            }
            catch
            {
                MessageBox.Show("Error: Invalid address");
                return;
            }

            // Assemble line
            if (txtLine.Text.Trim() == "")
                return;

            n = asm.AsmLine(txtLine.Text, b, addr);

            // Check for errors
            if (n == -1)
            {
                MessageBox.Show("Error: " + asm.ErrMsg, "Line ASM error");
            }
            else
            {
                // Write assembled instruction to memory
                for (i = 0; i < n; i++)
                    mem.DebugWrite((UInt16)(addr + i), b[i]);

                // Update display
                lbList.Items.Add(dasm.Disassemble(addr));
                addr += (UInt16)n;
                txtAddr.Text = string.Format("{0:X4} ", addr);
                txtLine.Text = "";
            }
        }

        private void LineAsm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainForm parentFrm = (MainForm)this.MdiParent;

            if (parentFrm.bClosingEventFromParent == false)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void btClear_Click(object sender, System.EventArgs e)
        {
            lbList.Items.Clear();
        }
    }
}
