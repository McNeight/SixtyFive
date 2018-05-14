using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtyFive.Viewers
{
    partial class DisasmViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            ((System.ComponentModel.ISupportInitialize)(this.pbMem)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMem
            // 
            this.pbMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
               | System.Windows.Forms.AnchorStyles.Left)));
            this.pbMem.Location = new System.Drawing.Point(0, 0);
            this.pbMem.Name = "pbMem";
            this.pbMem.Size = new System.Drawing.Size(376, 400);
            this.pbMem.TabIndex = 0;
            this.pbMem.TabStop = false;
            this.pbMem.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMem_Paint);
            // 
            // vsAddress
            // 
            this.vsAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
               | System.Windows.Forms.AnchorStyles.Left)));
            this.vsAddress.LargeChange = 16;
            this.vsAddress.Location = new System.Drawing.Point(376, 0);
            this.vsAddress.Maximum = 65535;
            this.vsAddress.Name = "vsAddress";
            this.vsAddress.Size = new System.Drawing.Size(16, 400);
            this.vsAddress.TabIndex = 1;
            this.vsAddress.ValueChanged += new System.EventHandler(this.vsAddress_ValueChanged);
            // 
            // DisasmViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(392, 398);
            this.Controls.Add(this.vsAddress);
            this.Controls.Add(this.pbMem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisasmViewer";
            this.Text = "Disassembly Viewer";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DisasmViewer_Closing);
            this.Load += new System.EventHandler(this.DisasmViewer_Load);
            this.Resize += new System.EventHandler(this.DisasmViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbMem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMem;
        private System.Windows.Forms.VScrollBar vsAddress;

    }
}
