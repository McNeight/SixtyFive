/*
 * frmRangeInput.cs 
 *
 * Form for input address ranges
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

namespace SixtyFive
{
    public enum RangeInputType { OneAddress, TwoAddress, TwoAddressData }

    public partial class frmRangeInput : System.Windows.Forms.Form
    {
        public UInt16 start;
        public UInt16 end;
        public Byte data;
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
                start = Convert.ToUInt16(txtStartAddress.Text.Trim(), 16);
            }
            catch
            {
                MessageBox.Show("Invalid start address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                valid = false;
            }

            // Get end address from form
            if (txtEndAddress.Visible)
            {
                try
                {
                    end = Convert.ToUInt16(txtEndAddress.Text.Trim(), 16);
                }
                catch
                {
                    MessageBox.Show("Invalid end address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                    valid = false;
                }
            }

            // Get data from form
            if (txtData.Visible)
            {
                try
                {
                    data = Convert.ToByte(txtData.Text.Trim(), 16);
                }
                catch
                {
                    MessageBox.Show("Invalid data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
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
