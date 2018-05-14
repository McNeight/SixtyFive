/*
 * CPUView.cs
 *
 * SixtyFive CPU Register Viewer
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
    public partial class CPUViewer : System.Windows.Forms.Form
	{
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
			txtAreg.Text = string.Format("{0:x2}",CPU.A);
			txtXreg.Text = string.Format("{0:x2}",CPU.X);
			txtYreg.Text = string.Format("{0:x2}",CPU.Y);
			txtSPreg.Text = string.Format("{0:x2}",CPU.SP);
			
			// Flags
			if ((CPU.P & (Byte)M6502.Flags.C) == 0) 
				cFlag.Checked = false;
			else
				cFlag.Checked = true;
	
			if  ((CPU.P & (Byte)M6502.Flags.Z) == 0) 
				zFlag.Checked = false;
			else
				zFlag.Checked = true;

			if ((CPU.P & (Byte)M6502.Flags.I) == 0) 
				iFlag.Checked = false;
			else
				iFlag.Checked = true;

			if ((CPU.P & (Byte)M6502.Flags.D) == 0) 
				dFlag.Checked = false;
			else
				dFlag.Checked = true;

			if ((CPU.P & (Byte)M6502.Flags.B) == 0) 
				bFlag.Checked = false;
			else
				bFlag.Checked = true;

			if ((CPU.P & (Byte)M6502.Flags.V) == 0) 
				vFlag.Checked = false;
			else
				vFlag.Checked = true;

			if ((CPU.P & (Byte)M6502.Flags.N) == 0) 
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
			txtSPreg.ReadOnly = true;

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
			txtSPreg.ReadOnly = false;

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
				CPU.SP = Convert.ToByte(txtSPreg.Text.Trim(),16);
				txtSPreg.BackColor = SystemColors.Control;
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
				CPU.P |= (Byte)M6502.Flags.N;
			else
				CPU.P &= ((Byte)M6502.Flags.N ^ 0xFF);
		}

		private void vFlag_Click(object sender, System.EventArgs e)
		{
			if (vFlag.Checked) 
				CPU.P |= (Byte)M6502.Flags.V;
			else
				CPU.P &= ((Byte)M6502.Flags.V ^ 0xFF);
		}

		private void bFlag_Click(object sender, System.EventArgs e)
		{
			if (bFlag.Checked) 
				CPU.P |= (Byte)M6502.Flags.B;
			else
				CPU.P &= ((Byte)M6502.Flags.B ^ 0xFF);
		}

		private void dFlag_Click(object sender, System.EventArgs e)
		{
			if (dFlag.Checked) 
				CPU.P |= (Byte)M6502.Flags.D;
			else
				CPU.P &= ((Byte)M6502.Flags.D ^ 0xFF);
		}

		private void iFlag_Click(object sender, System.EventArgs e)
		{
			if (iFlag.Checked) 
				CPU.P |= (Byte)M6502.Flags.I;
			else
				CPU.P &= ((Byte)M6502.Flags.I ^ 0xFF);
		}

		private void zFlag_Click(object sender, System.EventArgs e)
		{
			if (zFlag.Checked) 
				CPU.P |= (Byte)M6502.Flags.Z;
			else
				CPU.P &= ((Byte)M6502.Flags.Z ^ 0xFF);
		}

		private void cFlag_Click(object sender, System.EventArgs e)
		{
			if (cFlag.Checked) 
				CPU.P |= (Byte)M6502.Flags.C;
			else
				CPU.P &= ((Byte)M6502.Flags.C ^ 0xFF);
		}
	}	
	#endregion
}
