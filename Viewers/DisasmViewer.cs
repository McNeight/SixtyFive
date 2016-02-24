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

	public class DisasmViewer : System.Windows.Forms.Form
	{

#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PictureBox pbMem;
		private System.Windows.Forms.VScrollBar vsAddress;	

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
			this.pbMem = new System.Windows.Forms.PictureBox();
			this.vsAddress = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// pbMem
			// 
			this.pbMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.pbMem.Location = new System.Drawing.Point(0, 0);
			this.pbMem.Name = "pbMem";
			this.pbMem.Size = new System.Drawing.Size(376, 400);
			this.pbMem.TabIndex = 0;
			this.pbMem.TabStop = false;
			this.pbMem.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMem_Paint);
			// 
			// vsAddress
			// 
			this.vsAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.vsAddress.LargeChange = 16;
			this.vsAddress.Location = new System.Drawing.Point(376, 0);
			this.vsAddress.Maximum = 65535;
			this.vsAddress.Name = "vsAddress";
			this.vsAddress.Size = new System.Drawing.Size(16, 400);
			this.vsAddress.TabIndex = 1;
			this.vsAddress.ValueChanged += new System.EventHandler(this.vsAddress_ValueChanged);
			// 
			// DisasmViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 398);
			this.Controls.Add(this.vsAddress);
			this.Controls.Add(this.pbMem);
			this.Name = "DisasmViewer";
			this.Text = "Disassembly Viewer";
			this.Resize += new System.EventHandler(this.DisasmViewer_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DisasmViewer_Closing);
			this.Load += new System.EventHandler(this.DisasmViewer_Load);
			this.ResumeLayout(false);

		}
		#endregion

	
		public AddressSpace mem;
		public M6502 CPU;	
		private M6502DASM dasm;

		public ushort startAddress;
		public ushort endAddress;
		
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
			if (followPC) startAddress = CPU.PC;

			// Create disassembler object
			dasm = new M6502DASM(mem,CPU);

			// Setup drawing objects
			NormalFontBrush = new SolidBrush(Color.Black);
			CurAddressBrush = new SolidBrush(Color.Yellow);
		    NormalFont = new Font("Courier New",10);

			// Setup bitmap
			gr = new System.Drawing.Bitmap(376,400);
			g =  Graphics.FromImage(gr);
		}


		private void pbMem_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawImage(gr,0,0);
		}

		private void DisasmViewer_Load(object sender, System.EventArgs e)
		{
			pbMem.Focus();
		}
	
		public void SetCurrentAddress(ushort ad) 
		{
			vsAddress.Value = ad;
		}

		private void vsAddress_ValueChanged(object sender, System.EventArgs e)
		{
			startAddress = (ushort)(vsAddress.Value);
			update();
		}

		public void runupdate() 
		{
			// Update the address if we are following the program counter
			if (followPC) 
			{	
				if (CPU.PC < startAddress || CPU.PC > endAddress) startAddress = CPU.PC;
			}
			update();
		}

		public void SetSize()
		{		
			// Set picture box width
			pbMem.Width = this.Width -26;
			pbMem.Height = this.Height - 32;

			// Setup address scroller
			vsAddress.Left = pbMem.Width;
			vsAddress.Height = pbMem.Height;

			// Re-create graphics objects
			gr = new System.Drawing.Bitmap(pbMem.Width,pbMem.Height);
			g =  Graphics.FromImage(gr);
			
			// Refresh the display
			update();
			pbMem.Refresh();
		}

		public void update() 
		{		
			int y,lines;
			string s;
			SizeF size;
			ushort addr;

			// Clear bitmap
			g.Clear(Color.LightGray);

			// Determine the size of a byte
			size = g.MeasureString("0",NormalFont);
		
			// Determine the number of lines that will fit in the box
			lines = (int)Math.Floor(pbMem.Height / size.Height);
			
			addr = startAddress;
			for (y=0; y<lines; y++) 
			{	
				// Hightlight program counter address
				if (addr == CPU.PC) g.FillRectangle(CurAddressBrush,0,y*size.Height,pbMem.Width,size.Height);
							
				// Disassemble and display line
				s = dasm.Disassemble(addr);
				g.DrawString(s,NormalFont,NormalFontBrush,0,y*size.Height);

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
			MainForm parentFrm=(MainForm)this.MdiParent; 

			if(parentFrm.bClosingEventFromParent == false)
			{
				this.Hide();
				e.Cancel = true;	
			}
		}

		private void DisasmViewer_Resize(object sender, System.EventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized) SetSize();
		}

	}
}
