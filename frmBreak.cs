/*
 * frmBreak.cs 
 *
 * Form for configuring breakpoints
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
using System.Collections;
using System.Windows.Forms;

namespace SixtyFive
{
    public partial class frmBreak : System.Windows.Forms.Form
    {
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
