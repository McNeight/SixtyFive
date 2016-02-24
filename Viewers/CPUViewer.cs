/* * CPUView.cs * * Sim6502 CPU Register Viewer * 
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
using System.Text;

namespace SixtyFive
{

	public class CPUViewer : System.Windows.Forms.Form
	{

		#region Windows Form Designer generated code

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPC;
		private System.Windows.Forms.TextBox txtAreg;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtXreg;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtYreg;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSreg;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox nFlag;
		private System.Windows.Forms.CheckBox vFlag;
		private System.Windows.Forms.CheckBox bFlag;
		private System.Windows.Forms.CheckBox dFlag;
		private System.Windows.Forms.CheckBox iFlag;
		private System.Windows.Forms.CheckBox zFlag;
		private System.Windows.Forms.CheckBox cFlag;
		private System.ComponentModel.Container components = null;

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtPC = new System.Windows.Forms.TextBox();
			this.txtAreg = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtXreg = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtYreg = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSreg = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nFlag = new System.Windows.Forms.CheckBox();
			this.vFlag = new System.Windows.Forms.CheckBox();
			this.bFlag = new System.Windows.Forms.CheckBox();
			this.dFlag = new System.Windows.Forms.CheckBox();
			this.iFlag = new System.Windows.Forms.CheckBox();
			this.zFlag = new System.Windows.Forms.CheckBox();
			this.cFlag = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "PC:";
			// 
			// txtPC
			// 
			this.txtPC.BackColor = System.Drawing.SystemColors.Control;
			this.txtPC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPC.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPC.Location = new System.Drawing.Point(32, 0);
			this.txtPC.MaxLength = 4;
			this.txtPC.Name = "txtPC";
			this.txtPC.Size = new System.Drawing.Size(32, 15);
			this.txtPC.TabIndex = 3;
			this.txtPC.Text = "0000";
			this.txtPC.LostFocus += new System.EventHandler(this.txt_LostFocus);
			this.txtPC.GotFocus += new System.EventHandler(this.txt_GotFocus);
			this.txtPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPC_KeyPress);
			// 
			// txtAreg
			// 
			this.txtAreg.BackColor = System.Drawing.SystemColors.Control;
			this.txtAreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtAreg.Location = new System.Drawing.Point(94, 0);
			this.txtAreg.MaxLength = 2;
			this.txtAreg.Name = "txtAreg";
			this.txtAreg.Size = new System.Drawing.Size(16, 15);
			this.txtAreg.TabIndex = 5;
			this.txtAreg.Text = "00";
			this.txtAreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
			this.txtAreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
			this.txtAreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAreg_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(72, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "A:";
			// 
			// txtXreg
			// 
			this.txtXreg.BackColor = System.Drawing.SystemColors.Control;
			this.txtXreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtXreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtXreg.Location = new System.Drawing.Point(143, 0);
			this.txtXreg.MaxLength = 2;
			this.txtXreg.Name = "txtXreg";
			this.txtXreg.Size = new System.Drawing.Size(16, 15);
			this.txtXreg.TabIndex = 7;
			this.txtXreg.Text = "00";
			this.txtXreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
			this.txtXreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
			this.txtXreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXreg_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(120, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 18);
			this.label3.TabIndex = 6;
			this.label3.Text = "X:";
			// 
			// txtYreg
			// 
			this.txtYreg.BackColor = System.Drawing.SystemColors.Control;
			this.txtYreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtYreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtYreg.Location = new System.Drawing.Point(191, 0);
			this.txtYreg.MaxLength = 2;
			this.txtYreg.Name = "txtYreg";
			this.txtYreg.Size = new System.Drawing.Size(16, 15);
			this.txtYreg.TabIndex = 9;
			this.txtYreg.Text = "00";
			this.txtYreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
			this.txtYreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
			this.txtYreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYreg_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(168, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 18);
			this.label4.TabIndex = 8;
			this.label4.Text = "Y:";
			// 
			// txtSreg
			// 
			this.txtSreg.BackColor = System.Drawing.SystemColors.Control;
			this.txtSreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSreg.Location = new System.Drawing.Point(240, 0);
			this.txtSreg.MaxLength = 2;
			this.txtSreg.Name = "txtSreg";
			this.txtSreg.Size = new System.Drawing.Size(16, 15);
			this.txtSreg.TabIndex = 11;
			this.txtSreg.Text = "00";
			this.txtSreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
			this.txtSreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
			this.txtSreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSreg_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(216, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(21, 18);
			this.label5.TabIndex = 10;
			this.label5.Text = "S:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(0, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(206, 18);
			this.label6.TabIndex = 12;
			this.label6.Text = "N   V   B   D   I   Z   C";
			// 
			// nFlag
			// 
			this.nFlag.Location = new System.Drawing.Point(16, 24);
			this.nFlag.Name = "nFlag";
			this.nFlag.Size = new System.Drawing.Size(16, 24);
			this.nFlag.TabIndex = 13;
			this.nFlag.Click += new System.EventHandler(this.nFlag_Click);
			// 
			// vFlag
			// 
			this.vFlag.Location = new System.Drawing.Point(48, 24);
			this.vFlag.Name = "vFlag";
			this.vFlag.Size = new System.Drawing.Size(16, 24);
			this.vFlag.TabIndex = 14;
			this.vFlag.Click += new System.EventHandler(this.vFlag_Click);
			// 
			// bFlag
			// 
			this.bFlag.Location = new System.Drawing.Point(80, 24);
			this.bFlag.Name = "bFlag";
			this.bFlag.Size = new System.Drawing.Size(16, 24);
			this.bFlag.TabIndex = 15;
			this.bFlag.Click += new System.EventHandler(this.bFlag_Click);
			// 
			// dFlag
			// 
			this.dFlag.Location = new System.Drawing.Point(112, 24);
			this.dFlag.Name = "dFlag";
			this.dFlag.Size = new System.Drawing.Size(16, 24);
			this.dFlag.TabIndex = 16;
			this.dFlag.Click += new System.EventHandler(this.dFlag_Click);
			// 
			// iFlag
			// 
			this.iFlag.Location = new System.Drawing.Point(144, 24);
			this.iFlag.Name = "iFlag";
			this.iFlag.Size = new System.Drawing.Size(16, 24);
			this.iFlag.TabIndex = 17;
			this.iFlag.Click += new System.EventHandler(this.iFlag_Click);
			// 
			// zFlag
			// 
			this.zFlag.Location = new System.Drawing.Point(176, 24);
			this.zFlag.Name = "zFlag";
			this.zFlag.Size = new System.Drawing.Size(16, 24);
			this.zFlag.TabIndex = 18;
			this.zFlag.Click += new System.EventHandler(this.zFlag_Click);
			// 
			// cFlag
			// 
			this.cFlag.Location = new System.Drawing.Point(208, 24);
			this.cFlag.Name = "cFlag";
			this.cFlag.Size = new System.Drawing.Size(16, 24);
			this.cFlag.TabIndex = 19;
			this.cFlag.Click += new System.EventHandler(this.cFlag_Click);
			// 
			// CPUViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 54);
			this.Controls.Add(this.cFlag);
			this.Controls.Add(this.zFlag);
			this.Controls.Add(this.iFlag);
			this.Controls.Add(this.dFlag);
			this.Controls.Add(this.bFlag);
			this.Controls.Add(this.vFlag);
			this.Controls.Add(this.nFlag);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtSreg);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtYreg);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtXreg);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtAreg);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPC);
			this.Controls.Add(this.label1);
			this.Name = "CPUViewer";
			this.Text = "CPU Register Viewer";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.CPUViewer_Closing);
			this.Load += new System.EventHandler(this.CPUView_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public M6502 CPU;

		public CPUViewer(M6502 cpu)
		{
			InitializeComponent();
			CPU = cpu;
		}

		public void SetSize()
		{
			this.Width = 272;
			this.Height = 88;
		}

		public void update()
		{
			// Registers
			txtPC.Text = string.Format("{0:x4}",CPU.PC);
			txtAreg.Text = string.Format("{0:x2}",CPU.A);			txtXreg.Text = string.Format("{0:x2}",CPU.X);			txtYreg.Text = string.Format("{0:x2}",CPU.Y);			txtSreg.Text = string.Format("{0:x2}",CPU.S);			
			// Flags
			if ((CPU.P & (byte)M6502.Flags.C) == 0) 
				cFlag.Checked = false;
			else
				cFlag.Checked = true;
	
			if  ((CPU.P & (byte)M6502.Flags.Z) == 0) 
				zFlag.Checked = false;
			else
				zFlag.Checked = true;

			if ((CPU.P & (byte)M6502.Flags.I) == 0) 
				iFlag.Checked = false;
			else
				iFlag.Checked = true;

			if ((CPU.P & (byte)M6502.Flags.D) == 0) 
				dFlag.Checked = false;
			else
				dFlag.Checked = true;

			if ((CPU.P & (byte)M6502.Flags.B) == 0) 
				bFlag.Checked = false;
			else
				bFlag.Checked = true;

			if ((CPU.P & (byte)M6502.Flags.V) == 0) 
				vFlag.Checked = false;
			else
				vFlag.Checked = true;

			if ((CPU.P & (byte)M6502.Flags.N) == 0) 
				nFlag.Checked = false;
			else
				nFlag.Checked = true;
		
		}

		public void Lock()
		{
			txtPC.ReadOnly = true;
			txtAreg.ReadOnly = true;
			txtXreg.ReadOnly = true;
			txtYreg.ReadOnly = true;
			txtSreg.ReadOnly = true;

			cFlag.Enabled = false;
			zFlag.Enabled = false;
			iFlag.Enabled = false;
			dFlag.Enabled = false;
			bFlag.Enabled = false;
			vFlag.Enabled = false;
			nFlag.Enabled = false;
		}

		public void Unlock()
		{
			txtPC.ReadOnly = false;
			txtAreg.ReadOnly = false;
			txtXreg.ReadOnly = false;
			txtYreg.ReadOnly = false;
			txtSreg.ReadOnly = false;

			cFlag.Enabled = true;
			zFlag.Enabled = true;
			iFlag.Enabled = true;
			dFlag.Enabled = true;
			bFlag.Enabled = true;
			vFlag.Enabled = true;
			nFlag.Enabled = true;
		}


#region "Form Events"
		private void CPUView_Load(object sender, System.EventArgs e)
		{
			update();
		}

		private void CPUView_Resize(object sender, System.EventArgs e)
		{
			SetSize();
		}

		private void CPUViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MainForm parentFrm=(MainForm)this.MdiParent; 

			if(parentFrm.bClosingEventFromParent==false)
			{
				this.Hide();
				e.Cancel = true;	
			}
		}	
#endregion

#region "Handle register changes"

		private void txt_LostFocus(object sender, System.EventArgs e)
		{
			TextBox txt= (TextBox)sender;
			txt.BackColor = SystemColors.Control;	
		}

		private void txt_GotFocus(object sender, System.EventArgs e)
		{
			TextBox txt= (TextBox)sender;
			txt.BackColor = Color.White;
		}

		// Handle changes to PC
		private void txtPC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r') return;
			try 
			{
				CPU.PC = Convert.ToUInt16(txtPC.Text.Trim(),16);
				txtPC.BackColor = SystemColors.Control;
			}
			catch 
			{
				MessageBox.Show("Invalid PC value");
				update();
			}
		}

		// Handle changes to A
		private void txtAreg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r') return;
			try 
			{
				CPU.A= Convert.ToByte(txtAreg.Text.Trim(),16);
				txtAreg.BackColor = SystemColors.Control;
			}
			catch 
			{
				MessageBox.Show("Invalid accumulator value");
				update();
			}
		}

		// Handle changes to Y
		private void txtYreg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r') return;
			try 
			{
				CPU.Y = Convert.ToByte(txtYreg.Text.Trim(),16);
				txtYreg.BackColor = SystemColors.Control;
			}
			catch 
			{
				MessageBox.Show("Invalid Y register value");
				update();
			}
		}

		// Handle changes to X
		private void txtXreg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r') return;
			try 
			{
				CPU.X = Convert.ToByte(txtXreg.Text.Trim(),16);
				txtXreg.BackColor = SystemColors.Control;
			}
			catch 
			{
				MessageBox.Show("Invalid X register value");
				update();
			}
		}

		private void txtSreg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r') return;
			try 
			{
				CPU.S = Convert.ToByte(txtSreg.Text.Trim(),16);
				txtSreg.BackColor = SystemColors.Control;
			}
			catch 
			{
				MessageBox.Show("Invalid stack pointer value");
				update();
			}
		}
	#endregion

#region "Handle flag controls"
		private void nFlag_Click(object sender, System.EventArgs e)
		{
			if (nFlag.Checked) 
				CPU.P |= (byte)M6502.Flags.N;
			else
				CPU.P &= ((byte)M6502.Flags.N ^ 0xFF);
		}

		private void vFlag_Click(object sender, System.EventArgs e)
		{
			if (vFlag.Checked) 
				CPU.P |= (byte)M6502.Flags.V;
			else
				CPU.P &= ((byte)M6502.Flags.V ^ 0xFF);
		}

		private void bFlag_Click(object sender, System.EventArgs e)
		{
			if (bFlag.Checked) 
				CPU.P |= (byte)M6502.Flags.B;
			else
				CPU.P &= ((byte)M6502.Flags.B ^ 0xFF);
		}

		private void dFlag_Click(object sender, System.EventArgs e)
		{
			if (dFlag.Checked) 
				CPU.P |= (byte)M6502.Flags.D;
			else
				CPU.P &= ((byte)M6502.Flags.D ^ 0xFF);
		}

		private void iFlag_Click(object sender, System.EventArgs e)
		{
			if (iFlag.Checked) 
				CPU.P |= (byte)M6502.Flags.I;
			else
				CPU.P &= ((byte)M6502.Flags.I ^ 0xFF);
		}

		private void zFlag_Click(object sender, System.EventArgs e)
		{
			if (zFlag.Checked) 
				CPU.P |= (byte)M6502.Flags.Z;
			else
				CPU.P &= ((byte)M6502.Flags.Z ^ 0xFF);
		}

		private void cFlag_Click(object sender, System.EventArgs e)
		{
			if (cFlag.Checked) 
				CPU.P |= (byte)M6502.Flags.C;
			else
				CPU.P &= ((byte)M6502.Flags.C ^ 0xFF);
		}
	}	
	#endregion
}
