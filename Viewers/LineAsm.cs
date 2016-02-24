/* * DisasmViewer.cs * * Sim6502 Disassembly Viewer Form * 
 * Copyright (c) 2004 Dan Boris * *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 * */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace sim6502
{

	public class LineAsm : System.Windows.Forms.Form
	{

#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;	

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			this.lbList = new System.Windows.Forms.ListBox();
			this.txtAddr = new System.Windows.Forms.TextBox();
			this.txtLine = new System.Windows.Forms.TextBox();
			this.btClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbList
			// 
			this.lbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbList.ItemHeight = 14;
			this.lbList.Location = new System.Drawing.Point(0, 40);
			this.lbList.Name = "lbList";
			this.lbList.Size = new System.Drawing.Size(392, 354);
			this.lbList.TabIndex = 0;
			// 
			// txtAddr
			// 
			this.txtAddr.Location = new System.Drawing.Point(0, 8);
			this.txtAddr.Name = "txtAddr";
			this.txtAddr.Size = new System.Drawing.Size(96, 20);
			this.txtAddr.TabIndex = 1;
			this.txtAddr.Text = "";
			// 
			// txtLine
			// 
			this.txtLine.Location = new System.Drawing.Point(104, 8);
			this.txtLine.Name = "txtLine";
			this.txtLine.Size = new System.Drawing.Size(288, 20);
			this.txtLine.TabIndex = 2;
			this.txtLine.Text = "";
			this.txtLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLine_KeyPress);
			// 
			// btClear
			// 
			this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btClear.Location = new System.Drawing.Point(2, 400);
			this.btClear.Name = "btClear";
			this.btClear.TabIndex = 3;
			this.btClear.Text = "Clear";
			this.btClear.Click += new System.EventHandler(this.btClear_Click);
			// 
			// LineAsm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 430);
			this.Controls.Add(this.btClear);
			this.Controls.Add(this.txtLine);
			this.Controls.Add(this.txtAddr);
			this.Controls.Add(this.lbList);
			this.Name = "LineAsm";
			this.Text = "Line Assembler";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.LineAsm_Closing);
			this.Load += new System.EventHandler(this.LineAsm_Load);
			this.ResumeLayout(false);

		}

		private System.Windows.Forms.ListBox lbList;
		private System.Windows.Forms.TextBox txtAddr;
		private System.Windows.Forms.TextBox txtLine;
		private System.Windows.Forms.Button btClear;

		#endregion

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
			dasm = new M6502DASM(mem,CPU);
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
			byte[] b = new byte[3];
			ushort i,addr;
			int n;
			
			// Get address
			try 
			{
				addr = Convert.ToUInt16(txtAddr.Text.Trim(),16);
			}
			catch 
			{
				MessageBox.Show("Error: Invalid address");
				return;
			}
		
			// Assemble line
			if (txtLine.Text.Trim() == "") return;

			n = asm.AsmLine(txtLine.Text,b,addr);

			// Check for errors
			if (n == -1) 
			{
				MessageBox.Show("Error: " + asm.ErrMsg,"Line ASM error");
			}
			else 
			{
				// Write assembled instruction to memory
				for (i=0; i<n; i++) mem.DebugWrite((ushort)(addr+i),b[i]);

				// Update display
				lbList.Items.Add(dasm.Disassemble(addr));
				addr += (ushort)n;
				txtAddr.Text = string.Format("{0:X4} ",addr);
				txtLine.Text = "";
			}
		}

		private void LineAsm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MainForm parentFrm=(MainForm)this.MdiParent; 

			if(parentFrm.bClosingEventFromParent==false)
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
