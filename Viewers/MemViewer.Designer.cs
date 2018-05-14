/*
 * MemViewer.Designer.cs
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
   public partial class MemViewer : Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;
      private System.Windows.Forms.PictureBox pbMem;
      private System.Windows.Forms.TextBox txtInput;
      private System.Windows.Forms.VScrollBar vsAddress;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.pbMem = new System.Windows.Forms.PictureBox();
         this.vsAddress = new System.Windows.Forms.VScrollBar();
         this.txtInput = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.pbMem)).BeginInit();
         this.SuspendLayout();
         // 
         // pbMem
         // 
         this.pbMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
         this.pbMem.Location = new System.Drawing.Point(0, 0);
         this.pbMem.Name = "pbMem";
         this.pbMem.Size = new System.Drawing.Size(400, 400);
         this.pbMem.TabIndex = 0;
         this.pbMem.TabStop = false;
         this.pbMem.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMem_Paint);
         this.pbMem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMem_MouseDown);
         // 
         // vsAddress
         // 
         this.vsAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
         this.vsAddress.LargeChange = 16;
         this.vsAddress.Location = new System.Drawing.Point(400, 0);
         this.vsAddress.Maximum = 4096;
         this.vsAddress.Name = "vsAddress";
         this.vsAddress.Size = new System.Drawing.Size(16, 400);
         this.vsAddress.TabIndex = 1;
         this.vsAddress.ValueChanged += new System.EventHandler(this.vsAddress_ValueChanged);
         // 
         // txtInput
         // 
         this.txtInput.BackColor = System.Drawing.Color.Yellow;
         this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.txtInput.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((Byte)(0)));
         this.txtInput.Location = new System.Drawing.Point(312, 368);
         this.txtInput.MaxLength = 2;
         this.txtInput.Name = "txtInput";
         this.txtInput.Size = new System.Drawing.Size(16, 16);
         this.txtInput.TabIndex = 2;
         this.txtInput.Visible = false;
         this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
         // 
         // MemViewer
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
         this.ClientSize = new System.Drawing.Size(416, 398);
         this.Controls.Add(this.txtInput);
         this.Controls.Add(this.vsAddress);
         this.Controls.Add(this.pbMem);
         this.Font = new System.Drawing.Font("Courier New", 9.75F);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "MemViewer";
         this.Text = "Memory Viewer";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MemViewer_Closing);
         this.Load += new System.EventHandler(this.MemViewer_Load);
         this.Resize += new System.EventHandler(this.MemViewer_Resize);
         ((System.ComponentModel.ISupportInitialize)(this.pbMem)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();
      }

      #endregion
   }
}