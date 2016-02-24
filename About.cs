using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace sim6502
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox txtCW;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Label lblVersion;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCW = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(168, 347);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(88, 24);
			this.btOK.TabIndex = 0;
			this.btOK.Text = "OK";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label1.Location = new System.Drawing.Point(121, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(182, 34);
			this.label1.TabIndex = 1;
			this.label1.Text = "SIM6502.NET";
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblVersion.Location = new System.Drawing.Point(180, 51);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(64, 16);
			this.lblVersion.TabIndex = 2;
			this.lblVersion.Text = "Version 1.0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(136, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Copyright (c)  2004 Dan Boris";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(128, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(165, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Copyright (c) 2003 Mike Murphy";
			// 
			// txtCW
			// 
			this.txtCW.Location = new System.Drawing.Point(12, 139);
			this.txtCW.Name = "txtCW";
			this.txtCW.Size = new System.Drawing.Size(400, 200);
			this.txtCW.TabIndex = 5;
			this.txtCW.Text = "";
			// 
			// About
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 382);
			this.Controls.Add(this.txtCW);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btOK);
			this.Name = "About";
			this.Text = "About";
			this.Load += new System.EventHandler(this.About_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void About_Load(object sender, System.EventArgs e)
		{	
			int major = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major;
			int minor = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor;
		    lblVersion.Text = "Version " + major.ToString() + "." + minor.ToString();

			txtCW.Text += "This program is free software; you can redistribute it and/or modify it ";
			txtCW.Text += "under the terms of the GNU General Public License as published by ";
			txtCW.Text += "the Free Software Foundation; either version 2 of the License, or ";
			txtCW.Text += "(at your option) any later version.\n\r";

			txtCW.Text += "This program is distributed in the hope that it will be useful ";
			txtCW.Text += "but WITHOUT ANY WARRANTY; without even the implied warranty of ";
			txtCW.Text += "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the ";
			txtCW.Text += "GNU General Public License for more details.\n\r";

			txtCW.Text += "You should have received a copy of the GNU General Public License ";
			txtCW.Text += "along with this program; if not, write to the Free Software ";
			txtCW.Text += "Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111 USA\n\r";
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
