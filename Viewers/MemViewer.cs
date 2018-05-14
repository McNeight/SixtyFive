/*
 * MemViewer.cs
 *
 * Sim6502 Memory Viewer Form
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

namespace SixtyFive
{
   // Memory viewer form
   public partial class MemViewer : Form
   {
      public UInt16 curAddress = 0;    // Currently displayed address
      public AddressSpace mem;      // Memory space to view

      // Drawing style objects
      SolidBrush NormalFontBrush;
      Font NormalFont;

      // Text sizes
      int LineHeight;
      int AddrWidth;
      int DataWidth;

      // Graphics objects
      private Bitmap gr;
      private Graphics g;

      // Editing 
      UInt16 EditAddress;

      // Memory viewer init 
      public MemViewer(AddressSpace Mem)
      {
         InitializeComponent();
         mem = Mem;

         // Setup drawing objects
         NormalFontBrush = new SolidBrush(Color.Black);
         NormalFont = new Font("Courier New", 10);

         // Setup bitmap
         gr = new System.Drawing.Bitmap(100, 100);
         g = Graphics.FromImage(gr);

         // Determine the size of the text
         SizeF size;
         size = g.MeasureString("00 ", NormalFont);
         LineHeight = (int)Math.Ceiling(size.Height);
         DataWidth = (int)Math.Ceiling(size.Width);
         size = g.MeasureString("0000:", NormalFont);
         AddrWidth = (int)Math.Ceiling(size.Width);
      }

      public void SetSize()
      {
         // Set picture box width
         pbMem.Width = AddrWidth + (16 * DataWidth);

         // Set form width based on picture box width
         this.Width = pbMem.Width + vsAddress.Width + 10;

         // Setup address scroller
         vsAddress.Left = pbMem.Width;

         // Re-create graphics objects
         gr = new System.Drawing.Bitmap(pbMem.Width, pbMem.Height);
         g = Graphics.FromImage(gr);

         // Refresh the display
         update();
         pbMem.Refresh();
      }

      private void MemViewer_Load(object sender, System.EventArgs e)
      {
      }

      // Repaint memory display
      private void pbMem_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         e.Graphics.DrawImage(gr, 0, 0);
      }

      // Redraw bitmap
      public void update()
      {
         int x, y, xp, lines;
         string s;
         UInt16 addr;
         bool overflow = false;

         // Clear bitmap
         g.Clear(Color.LightGray);

         // Determine the number of lines that will fit in the box
         lines = (int)Math.Floor((double)(pbMem.Height / LineHeight));

         addr = curAddress;
         for (y = 0; y < lines; y++) {
            // Format and display address
            s = string.Format("{0:X4}:", addr);
            g.DrawString(s, NormalFont, NormalFontBrush, 0, y * LineHeight);

            // Starting position of data
            xp = (int)g.MeasureString(s, NormalFont).Width;

            // Display data
            for (x = 0; x < 16; x++) {
               // Format and display data
               s = string.Format("{0:X2} ", mem.DebugRead(addr));

               g.DrawString(s, NormalFont, NormalFontBrush, xp, y * LineHeight);
               xp = xp + DataWidth;
               // If not at the end of memory, increment address
               if (addr != 0xFFFF)
                  addr++;
               else
                  overflow = true;

               // If we are past the end of memory, then exit
               if (overflow) break;
            }
            if (overflow) break;
         }
         pbMem.Refresh();
      }

      public void SetCurrentAddress(UInt16 ad)
      {
         vsAddress.Value = (int)(ad / 16);
      }

      // Scrollbar change
      private void vsAddress_ValueChanged(object sender, System.EventArgs e)
      {
         // If there is an active edit, then finish it
         if (txtInput.Visible) {
            GetInput();
            txtInput.Visible = false;
         }

         curAddress = (UInt16)(vsAddress.Value * 16);
         update();
      }


      private void pbMem_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         int row, col;

         // If there was already an active edit, then finish it
         if (txtInput.Visible) GetInput();

         // Be sure we clicked in the data area
         if (e.X < AddrWidth) return;

         // Calculate position of click
         row = (int)Math.Floor((double)(e.Y / LineHeight));
         col = (int)Math.Floor((double)((e.X - AddrWidth) / DataWidth));

         // Setup editing box
         txtInput.Top = row * LineHeight;
         txtInput.Left = col * DataWidth + AddrWidth + 2;
         txtInput.Visible = true;

         // Calculate address being edited
         EditAddress = (UInt16)(curAddress + (row * 16) + col);
         txtInput.Text = string.Format("{0:X2}", mem.DebugRead(EditAddress));
      }

      private void txtInput_Leave(object sender, System.EventArgs e)
      {
         GetInput();
         txtInput.Visible = false;
      }

      private void GetInput()
      {
         mem.DebugWrite(EditAddress, Convert.ToByte(txtInput.Text.Trim(), 16));
         update();
      }

      private void MemViewer_Resize(object sender, System.EventArgs e)
      {
         if (this.WindowState != FormWindowState.Minimized) SetSize();
      }

      private void MemViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         MainForm parentFrm = (MainForm)this.MdiParent;

         if (parentFrm.bClosingEventFromParent == false) {
            this.Hide();
            e.Cancel = true;
         }
      }
   }
}
