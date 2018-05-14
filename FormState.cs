/*
 * FormState.cs 
 *
 * Saves the position and size of a form
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
using Microsoft.Win32;
using System.Drawing;

namespace SixtyFive
{
    /// <summary>
    /// 
    /// </summary>
    public class FormState
    {
        /// <summary>
        /// 
        /// </summary>
        public FormState()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public static void SaveFormPosition(System.Windows.Forms.Form form)
        {
            string skey;

            // Create registry key for form
            skey = "Software\\sim6502\\" + form.Name;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(skey, true);

            // The key doesn't exist; create it / open it
            if (key == null)
                key = Registry.CurrentUser.CreateSubKey(skey);

            key.SetValue("X", form.Location.X);
            key.SetValue("Y", form.Location.Y);
            key.SetValue("Width", form.Width);
            key.SetValue("Height", form.Height);

            if (form.Visible)
                key.SetValue("State", "True");
            else
                key.SetValue("State", "False");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public static void GetFormPosition(System.Windows.Forms.Form form)
        {
            string skey;

            // Create registry key for form
            skey = "Software\\sim6502\\" + form.Name;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(skey, true);

            // The key doesn't exist, exit
            if (key == null)
            {
                form.Show();
                return;
            }

            // Get window state
            if (key.GetValue("State") == null)
            {
                form.Show();
            }
            else
            {
                if ((string)key.GetValue("State") == "True")
                    form.Show();
                else
                    form.Hide();
            }

            if (key.GetValue("X") != null && key.GetValue("Y") != null)
            {
                form.Location = new Point((int)key.GetValue("X"), (int)key.GetValue("Y"));
            }

            if (key.GetValue("Width") != null)
            {
                form.Width = (int)key.GetValue("Width");
            }

            if (key.GetValue("Height") != null)
            {
                form.Height = (int)key.GetValue("Height");
            }
        }
    }
}
