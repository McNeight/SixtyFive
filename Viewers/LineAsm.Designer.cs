namespace SixtyFive.Viewers
{
    partial class LineAsm
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

        private void InitializeComponent()
        {
            this.lbList = new System.Windows.Forms.ListBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.btClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbList
            // 
            this.lbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
               | System.Windows.Forms.AnchorStyles.Left)
               | System.Windows.Forms.AnchorStyles.Right)));
            this.lbList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbList.ItemHeight = 14;
            this.lbList.Location = new System.Drawing.Point(0, 38);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(411, 354);
            this.lbList.TabIndex = 0;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(12, 12);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(96, 20);
            this.txtAddr.TabIndex = 1;
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(114, 12);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(288, 20);
            this.txtLine.TabIndex = 2;
            this.txtLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLine_KeyPress);
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClear.Location = new System.Drawing.Point(12, 403);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 3;
            this.btClear.Text = "Clear";
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // LineAsm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(411, 438);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.lbList);
            this.Controls.Add(this.btClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LineAsm";
            this.Text = "Line Assembler";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LineAsm_Closing);
            this.Load += new System.EventHandler(this.LineAsm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox lbList;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Button btClear;

        #endregion
    }
}
