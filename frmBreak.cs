/*
 * frmBreak.cs 
 *
 * Form for configuring breakpoints
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
using System.Collections;
using System.Windows.Forms;

namespace SixtyFive
{
    public class frmBreak : System.Windows.Forms.Form
    {

        #region Windows Form Designer generated code

        // Controls
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbAddrBreak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAddrBreakAdd;
        private System.Windows.Forms.Button btAddrBreakDelete;
        private System.Windows.Forms.Button btAddrBreakClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbDataBreak;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbRead;
        private System.Windows.Forms.RadioButton rbWrite;
        private System.Windows.Forms.Button btDataBreakClear;
        private System.Windows.Forms.Button btDataBreakDelete;
        private System.Windows.Forms.Button btDataBreakAdd;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.TextBox txtAddrBreakAddress;
        private System.Windows.Forms.TextBox txtDataBreakData;
        private System.Windows.Forms.TextBox txtDataBreakAddr;
        private System.Windows.Forms.CheckBox ckAddrBreakEnable;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btClearAll;
        private System.Windows.Forms.CheckBox ckDataBreakEnable;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddrBreakAddress = new System.Windows.Forms.TextBox();
            this.btAddrBreakClear = new System.Windows.Forms.Button();
            this.btAddrBreakDelete = new System.Windows.Forms.Button();
            this.btAddrBreakAdd = new System.Windows.Forms.Button();
            this.ckAddrBreakEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAddrBreak = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbWrite = new System.Windows.Forms.RadioButton();
            this.rbRead = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataBreakData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataBreakAddr = new System.Windows.Forms.TextBox();
            this.btDataBreakClear = new System.Windows.Forms.Button();
            this.btDataBreakDelete = new System.Windows.Forms.Button();
            this.btDataBreakAdd = new System.Windows.Forms.Button();
            this.ckDataBreakEnable = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDataBreak = new System.Windows.Forms.ListBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btClearAll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAddrBreakAddress);
            this.panel1.Controls.Add(this.btAddrBreakClear);
            this.panel1.Controls.Add(this.btAddrBreakDelete);
            this.panel1.Controls.Add(this.btAddrBreakAdd);
            this.panel1.Controls.Add(this.ckAddrBreakEnable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbAddrBreak);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 344);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Address:";
            // 
            // txtAddrBreakAddress
            // 
            this.txtAddrBreakAddress.Location = new System.Drawing.Point(16, 304);
            this.txtAddrBreakAddress.Name = "txtAddrBreakAddress";
            this.txtAddrBreakAddress.Size = new System.Drawing.Size(176, 20);
            this.txtAddrBreakAddress.TabIndex = 7;
            this.txtAddrBreakAddress.Text = "";
            // 
            // btAddrBreakClear
            // 
            this.btAddrBreakClear.Location = new System.Drawing.Point(128, 256);
            this.btAddrBreakClear.Name = "btAddrBreakClear";
            this.btAddrBreakClear.Size = new System.Drawing.Size(64, 24);
            this.btAddrBreakClear.TabIndex = 6;
            this.btAddrBreakClear.Text = "Clear";
            this.btAddrBreakClear.Click += new System.EventHandler(this.btAddrBreakClear_Click);
            // 
            // btAddrBreakDelete
            // 
            this.btAddrBreakDelete.Location = new System.Drawing.Point(72, 256);
            this.btAddrBreakDelete.Name = "btAddrBreakDelete";
            this.btAddrBreakDelete.Size = new System.Drawing.Size(56, 24);
            this.btAddrBreakDelete.TabIndex = 5;
            this.btAddrBreakDelete.Text = "Delete";
            this.btAddrBreakDelete.Click += new System.EventHandler(this.btAddrBreakDelete_Click);
            // 
            // btAddrBreakAdd
            // 
            this.btAddrBreakAdd.Location = new System.Drawing.Point(16, 256);
            this.btAddrBreakAdd.Name = "btAddrBreakAdd";
            this.btAddrBreakAdd.Size = new System.Drawing.Size(56, 24);
            this.btAddrBreakAdd.TabIndex = 4;
            this.btAddrBreakAdd.Text = "Add";
            this.btAddrBreakAdd.Click += new System.EventHandler(this.btAddrBreakAdd_Click);
            // 
            // ckAddrBreakEnable
            // 
            this.ckAddrBreakEnable.Location = new System.Drawing.Point(16, 32);
            this.ckAddrBreakEnable.Name = "ckAddrBreakEnable";
            this.ckAddrBreakEnable.Size = new System.Drawing.Size(168, 24);
            this.ckAddrBreakEnable.TabIndex = 3;
            this.ckAddrBreakEnable.Text = "Enabled";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Address Breaks";
            // 
            // lbAddrBreak
            // 
            this.lbAddrBreak.Location = new System.Drawing.Point(16, 56);
            this.lbAddrBreak.Name = "lbAddrBreak";
            this.lbAddrBreak.Size = new System.Drawing.Size(176, 199);
            this.lbAddrBreak.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rbWrite);
            this.panel2.Controls.Add(this.rbRead);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDataBreakData);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDataBreakAddr);
            this.panel2.Controls.Add(this.btDataBreakClear);
            this.panel2.Controls.Add(this.btDataBreakDelete);
            this.panel2.Controls.Add(this.btDataBreakAdd);
            this.panel2.Controls.Add(this.ckDataBreakEnable);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lbDataBreak);
            this.panel2.Location = new System.Drawing.Point(232, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 344);
            this.panel2.TabIndex = 2;
            // 
            // rbWrite
            // 
            this.rbWrite.Location = new System.Drawing.Point(72, 320);
            this.rbWrite.Name = "rbWrite";
            this.rbWrite.Size = new System.Drawing.Size(64, 16);
            this.rbWrite.TabIndex = 12;
            this.rbWrite.Text = "Write";
            // 
            // rbRead
            // 
            this.rbRead.Checked = true;
            this.rbRead.Location = new System.Drawing.Point(16, 320);
            this.rbRead.Name = "rbRead";
            this.rbRead.Size = new System.Drawing.Size(56, 16);
            this.rbRead.TabIndex = 11;
            this.rbRead.TabStop = true;
            this.rbRead.Text = "Read";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data";
            // 
            // txtDataBreakData
            // 
            this.txtDataBreakData.Location = new System.Drawing.Point(16, 288);
            this.txtDataBreakData.Name = "txtDataBreakData";
            this.txtDataBreakData.Size = new System.Drawing.Size(176, 20);
            this.txtDataBreakData.TabIndex = 9;
            this.txtDataBreakData.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address:";
            // 
            // txtDataBreakAddr
            // 
            this.txtDataBreakAddr.Location = new System.Drawing.Point(16, 240);
            this.txtDataBreakAddr.Name = "txtDataBreakAddr";
            this.txtDataBreakAddr.Size = new System.Drawing.Size(176, 20);
            this.txtDataBreakAddr.TabIndex = 7;
            this.txtDataBreakAddr.Text = "";
            // 
            // btDataBreakClear
            // 
            this.btDataBreakClear.Location = new System.Drawing.Point(128, 192);
            this.btDataBreakClear.Name = "btDataBreakClear";
            this.btDataBreakClear.Size = new System.Drawing.Size(64, 24);
            this.btDataBreakClear.TabIndex = 6;
            this.btDataBreakClear.Text = "Clear";
            this.btDataBreakClear.Click += new System.EventHandler(this.btDataBreakClear_Click);
            // 
            // btDataBreakDelete
            // 
            this.btDataBreakDelete.Location = new System.Drawing.Point(72, 192);
            this.btDataBreakDelete.Name = "btDataBreakDelete";
            this.btDataBreakDelete.Size = new System.Drawing.Size(56, 24);
            this.btDataBreakDelete.TabIndex = 5;
            this.btDataBreakDelete.Text = "Delete";
            this.btDataBreakDelete.Click += new System.EventHandler(this.btDataBreakDelete_Click);
            // 
            // btDataBreakAdd
            // 
            this.btDataBreakAdd.Location = new System.Drawing.Point(16, 192);
            this.btDataBreakAdd.Name = "btDataBreakAdd";
            this.btDataBreakAdd.Size = new System.Drawing.Size(56, 24);
            this.btDataBreakAdd.TabIndex = 4;
            this.btDataBreakAdd.Text = "Add";
            this.btDataBreakAdd.Click += new System.EventHandler(this.btDataBreakAdd_Click);
            // 
            // ckDataBreakEnable
            // 
            this.ckDataBreakEnable.Location = new System.Drawing.Point(16, 32);
            this.ckDataBreakEnable.Name = "ckDataBreakEnable";
            this.ckDataBreakEnable.Size = new System.Drawing.Size(168, 24);
            this.ckDataBreakEnable.TabIndex = 3;
            this.ckDataBreakEnable.Text = "Enabled";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data Breaks";
            // 
            // lbDataBreak
            // 
            this.lbDataBreak.Location = new System.Drawing.Point(16, 56);
            this.lbDataBreak.Name = "lbDataBreak";
            this.lbDataBreak.Size = new System.Drawing.Size(176, 134);
            this.lbDataBreak.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(368, 360);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(72, 24);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(288, 360);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(72, 24);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btClearAll
            // 
            this.btClearAll.Location = new System.Drawing.Point(16, 360);
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.TabIndex = 5;
            this.btClearAll.Text = "Clear All";
            this.btClearAll.Click += new System.EventHandler(this.btClearAll_Click);
            // 
            // frmBreak
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(448, 390);
            this.Controls.Add(this.btClearAll);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(456, 424);
            this.MinimumSize = new System.Drawing.Size(456, 424);
            this.Name = "frmBreak";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Breakpoints";
            this.Load += new System.EventHandler(this.frmBreak_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // Private properties
        private BreakPoints breakpoint;

        // Constructor
        public frmBreak(BreakPoints bp)
        {
            breakpoint = bp;
            InitializeComponent();
        }

        private void frmBreak_Load(object sender, System.EventArgs e)
        {
            PutData();
        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            UpdateData();
            this.Close();
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btClearAll_Click(object sender, System.EventArgs e)
        {
            lbAddrBreak.Items.Clear();
            lbDataBreak.Items.Clear();
            ckAddrBreakEnable.Checked = false;
            ckDataBreakEnable.Checked = false;
        }

        //----------------------------------------------------------------------
        // Handle address break section
        //----------------------------------------------------------------------
        #region Address break section

        private void btAddrBreakAdd_Click(object sender, System.EventArgs e)
        {
            UInt16 addr;

            try
            {
                addr = Convert.ToUInt16(txtAddrBreakAddress.Text.Trim(), 16);
                AddAddrBreak(addr);
                txtAddrBreakAddress.Text = "";
            }
            catch
            {
                MessageBox.Show("Invalid address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }

        private void btAddrBreakDelete_Click(object sender, System.EventArgs e)
        {
            if (lbAddrBreak.SelectedIndex == -1)
                return;
            lbAddrBreak.Items.Remove(lbAddrBreak.SelectedItem);
        }

        private void btAddrBreakClear_Click(object sender, System.EventArgs e)
        {
            lbAddrBreak.Items.Clear();
        }

        // Add address to address break list box
        private void AddAddrBreak(UInt16 addr)
        {
            lbAddrBreak.Items.Add(String.Format("{0:X4}", addr));
        }


        #endregion

        //----------------------------------------------------------------------
        // Handle data break section
        //----------------------------------------------------------------------
        #region Data break section

        private void btDataBreakAdd_Click(object sender, System.EventArgs e)
        {
            DataBreak db = new DataBreak();
            bool valid = true;

            // Get address from form
            try
            {
                db.address = Convert.ToUInt16(txtDataBreakAddr.Text.Trim(), 16);
            }
            catch
            {
                MessageBox.Show("Invalid address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                valid = false;
            }

            // Get data from form
            if (txtDataBreakData.Text.Trim() == "")
            {
                db.data = 0;
                db.anydata = true;
            }
            else
            {
                try
                {
                    db.data = Convert.ToByte(txtDataBreakData.Text.Trim(), 16);
                }
                catch
                {
                    MessageBox.Show("Invalid data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                    valid = false;
                }
            }

            // Get read write
            if (rbRead.Checked)
                db.readwrite = 'R';
            else
                db.readwrite = 'W';

            // Add it to the list box
            if (valid)
            {
                AddDataBreak(db);
                txtDataBreakData.Text = "";
                txtDataBreakAddr.Text = "";
            }

        }

        private void btDataBreakDelete_Click(object sender, System.EventArgs e)
        {
            if (lbDataBreak.SelectedIndex == -1)
                return;
            lbDataBreak.Items.Remove(lbDataBreak.SelectedItem);
        }

        private void btDataBreakClear_Click(object sender, System.EventArgs e)
        {
            lbDataBreak.Items.Clear();
        }

        private void AddDataBreak(DataBreak db)
        {
            lbDataBreak.Items.Add(db);
        }

        #endregion

        // Get data from breakpoint object and put it into form
        private void PutData()
        {
            // Set enables
            ckAddrBreakEnable.Checked = breakpoint.enableAddressBreak;
            ckDataBreakEnable.Checked = breakpoint.enableDataBreak;

            // Set address breaks
            foreach (DictionaryEntry de in breakpoint.AddressBreak)
            {
                AddAddrBreak((UInt16)de.Key);
            }

            // Set data breaks
            foreach (DataBreak db in breakpoint.DataBreak)
            {
                AddDataBreak(db);
            }

        }

        // Read data from form and put it in breakpoint object
        private void UpdateData()
        {
            // Get enables
            breakpoint.enableAddressBreak = ckAddrBreakEnable.Checked;
            breakpoint.enableDataBreak = ckDataBreakEnable.Checked;

            // Get address breaks
            breakpoint.RemoveAllAddressBreak();
            foreach (string s in lbAddrBreak.Items)
            {
                breakpoint.AddAddressBreak(Convert.ToUInt16(s, 16));
            }

            // Get data breaks
            breakpoint.RemoveAllDataBreak();
            foreach (DataBreak db in lbDataBreak.Items)
            {
                breakpoint.AddDataBreak(db.address, db.readwrite, db.data, db.anydata);
            }
        }

    }
}
