/*
 * frmRangeInput.cs 
 *
 * Form for input address ranges
 *
 * Copyright (c) 2004 Dan Boris
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 * 
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SixtyFive
{
	public enum RangeInputType {OneAddress,TwoAddress,TwoAddressData}

	public class frmRangeInput : System.Windows.Forms.Form
	{

		#region Windows Form Designer generated code

		private System.Windows.Forms.TextBox txtStartAddress;
		private System.Windows.Forms.TextBox txtEndAddress;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Label lbStart;
		private System.Windows.Forms.Label lbEnd;
		private System.Windows.Forms.Label lbData;

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
			this.txtStartAddress = new System.Windows.Forms.TextBox();
			this.lbStart = new System.Windows.Forms.Label();
			this.lbEnd = new System.Windows.Forms.Label();
			this.txtEndAddress = new System.Windows.Forms.TextBox();
			this.lbData = new System.Windows.Forms.Label();
			this.txtData = new System.Windows.Forms.TextBox();
			this.btOK = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtStartAddress
			// 
			this.txtStartAddress.Location = new System.Drawing.Point(88, 12);
			this.txtStartAddress.Name = "txtStartAddress";
			this.txtStartAddress.TabIndex = 0;
			this.txtStartAddress.Text = "";
			// 
			// lbStart
			// 
			this.lbStart.AutoSize = true;
			this.lbStart.Location = new System.Drawing.Point(8, 16);
			this.lbStart.Name = "lbStart";
			this.lbStart.Size = new System.Drawing.Size(76, 16);
			this.lbStart.TabIndex = 1;
			this.lbStart.Text = "Start Address:";
			// 
			// lbEnd
			// 
			this.lbEnd.AutoSize = true;
			this.lbEnd.Location = new System.Drawing.Point(16, 52);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.Size = new System.Drawing.Size(72, 16);
			this.lbEnd.TabIndex = 3;
			this.lbEnd.Text = "End Address:";
			// 
			// txtEndAddress
			// 
			this.txtEndAddress.Location = new System.Drawing.Point(88, 48);
			this.txtEndAddress.Name = "txtEndAddress";
			this.txtEndAddress.TabIndex = 2;
			this.txtEndAddress.Text = "";
			// 
			// lbData
			// 
			this.lbData.AutoSize = true;
			this.lbData.Location = new System.Drawing.Point(48, 84);
			this.lbData.Name = "lbData";
			this.lbData.Size = new System.Drawing.Size(31, 16);
			this.lbData.TabIndex = 5;
			this.lbData.Text = "Data:";
			// 
			// txtData
			// 
			this.txtData.Location = new System.Drawing.Point(88, 80);
			this.txtData.Name = "txtData";
			this.txtData.TabIndex = 4;
			this.txtData.Text = "";
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(16, 112);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(72, 24);
			this.btOK.TabIndex = 6;
			this.btOK.Text = "OK";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(112, 112);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(72, 24);
			this.btCancel.TabIndex = 7;
			this.btCancel.Text = "Cancel";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// frmRangeInput
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(200, 150);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.lbData);
			this.Controls.Add(this.txtData);
			this.Controls.Add(this.lbEnd);
			this.Controls.Add(this.txtEndAddress);
			this.Controls.Add(this.lbStart);
			this.Controls.Add(this.txtStartAddress);
			this.Name = "frmRangeInput";
			this.Text = "Input";
			this.Load += new System.EventHandler(this.frmRangeInput_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public ushort start;
		public ushort end;
		public byte data;
		public bool cancel;
		public RangeInputType type;
		
		public frmRangeInput(RangeInputType typ)
		{
			InitializeComponent();
			type = typ;
		}

		public frmRangeInput()
		{
			InitializeComponent();
			type = RangeInputType.TwoAddressData;
		}

		private void frmRangeInput_Load(object sender, System.EventArgs e)
		{
			start = 0;
			end = 0;
			data = 0;
			cancel = true;

			switch (type) 
			{
				case RangeInputType.OneAddress:
					lbEnd.Visible = false;
					lbData.Visible = false;
					txtEndAddress.Visible = false;
					txtData.Visible = false;
					break;
				case RangeInputType.TwoAddress:
					lbData.Visible = false;
					txtData.Visible = false;
					break;
			}

		}
		
		private bool GetData() 
		{	
			bool valid = true;

			// Get start address from form
			try 
			{
				start = Convert.ToUInt16(txtStartAddress.Text.Trim(),16);
			}
			catch 
			{
				MessageBox.Show("Invalid start address.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,0);
				valid = false;	
			}
			
			// Get end address from form
			if (txtEndAddress.Visible) 
			{
				try 
				{
					end = Convert.ToUInt16(txtEndAddress.Text.Trim(),16);
				}
				catch 
				{
					MessageBox.Show("Invalid end address.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,0);
					valid = false;	
				}
			}

			// Get data from form
			if (txtData.Visible) 
			{
				try 
				{
					data = Convert.ToByte(txtData.Text.Trim(),16);
				}
				catch 
				{
					MessageBox.Show("Invalid data.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,0);
					valid = false;
				}
			}

			return valid;
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			if (GetData()) 
			{
				cancel = false;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			cancel = true;
			this.Close();
		}	
		
	}
}
