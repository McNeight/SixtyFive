/*
 * frmAbout.cs 
 *
 * Form describing the application
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

namespace SixtyFive
{
    /// <summary>
    /// Summary description for About.
    /// </summary>
    public partial class frmAbout : System.Windows.Forms.Form
    {
        public frmAbout()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

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
