namespace SixtyFive.Viewers
{
    partial class CPUViewer
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
            this.lblPC = new System.Windows.Forms.Label();
            this.txtPC = new System.Windows.Forms.TextBox();
            this.txtAreg = new System.Windows.Forms.TextBox();
            this.lblAreg = new System.Windows.Forms.Label();
            this.txtXreg = new System.Windows.Forms.TextBox();
            this.lblXreg = new System.Windows.Forms.Label();
            this.txtYreg = new System.Windows.Forms.TextBox();
            this.lblYreg = new System.Windows.Forms.Label();
            this.txtSPreg = new System.Windows.Forms.TextBox();
            this.lblSPreg = new System.Windows.Forms.Label();
            this.nFlag = new System.Windows.Forms.CheckBox();
            this.vFlag = new System.Windows.Forms.CheckBox();
            this.bFlag = new System.Windows.Forms.CheckBox();
            this.dFlag = new System.Windows.Forms.CheckBox();
            this.iFlag = new System.Windows.Forms.CheckBox();
            this.zFlag = new System.Windows.Forms.CheckBox();
            this.cFlag = new System.Windows.Forms.CheckBox();
            this.gbFlags = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbRegisters = new System.Windows.Forms.GroupBox();
            this.gbFlags.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbRegisters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPC
            // 
            this.lblPC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPC.Location = new System.Drawing.Point(3, 2);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(32, 16);
            this.lblPC.TabIndex = 2;
            this.lblPC.Text = "PC:";
            this.lblPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPC
            // 
            this.txtPC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPC.BackColor = System.Drawing.SystemColors.Control;
            this.txtPC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPC.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPC.Location = new System.Drawing.Point(41, 3);
            this.txtPC.MaxLength = 4;
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(32, 15);
            this.txtPC.TabIndex = 3;
            this.txtPC.Text = "0000";
            this.txtPC.GotFocus += new System.EventHandler(this.txt_GotFocus);
            this.txtPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPC_KeyPress);
            this.txtPC.LostFocus += new System.EventHandler(this.txt_LostFocus);
            // 
            // txtAreg
            // 
            this.txtAreg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAreg.BackColor = System.Drawing.SystemColors.Control;
            this.txtAreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAreg.Location = new System.Drawing.Point(41, 24);
            this.txtAreg.MaxLength = 2;
            this.txtAreg.Name = "txtAreg";
            this.txtAreg.Size = new System.Drawing.Size(16, 15);
            this.txtAreg.TabIndex = 5;
            this.txtAreg.Text = "00";
            this.txtAreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
            this.txtAreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAreg_KeyPress);
            this.txtAreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
            // 
            // lblAreg
            // 
            this.lblAreg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAreg.AutoSize = true;
            this.lblAreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAreg.Location = new System.Drawing.Point(11, 23);
            this.lblAreg.Name = "lblAreg";
            this.lblAreg.Size = new System.Drawing.Size(24, 16);
            this.lblAreg.TabIndex = 4;
            this.lblAreg.Text = "A:";
            this.lblAreg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtXreg
            // 
            this.txtXreg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtXreg.BackColor = System.Drawing.SystemColors.Control;
            this.txtXreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtXreg.Location = new System.Drawing.Point(41, 45);
            this.txtXreg.MaxLength = 2;
            this.txtXreg.Name = "txtXreg";
            this.txtXreg.Size = new System.Drawing.Size(16, 15);
            this.txtXreg.TabIndex = 7;
            this.txtXreg.Text = "00";
            this.txtXreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
            this.txtXreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXreg_KeyPress);
            this.txtXreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
            // 
            // lblXreg
            // 
            this.lblXreg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblXreg.AutoSize = true;
            this.lblXreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblXreg.Location = new System.Drawing.Point(11, 44);
            this.lblXreg.Name = "lblXreg";
            this.lblXreg.Size = new System.Drawing.Size(24, 16);
            this.lblXreg.TabIndex = 6;
            this.lblXreg.Text = "X:";
            this.lblXreg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYreg
            // 
            this.txtYreg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtYreg.BackColor = System.Drawing.SystemColors.Control;
            this.txtYreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtYreg.Location = new System.Drawing.Point(41, 66);
            this.txtYreg.MaxLength = 2;
            this.txtYreg.Name = "txtYreg";
            this.txtYreg.Size = new System.Drawing.Size(16, 15);
            this.txtYreg.TabIndex = 9;
            this.txtYreg.Text = "00";
            this.txtYreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
            this.txtYreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYreg_KeyPress);
            this.txtYreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
            // 
            // lblYreg
            // 
            this.lblYreg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblYreg.AutoSize = true;
            this.lblYreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYreg.Location = new System.Drawing.Point(11, 65);
            this.lblYreg.Name = "lblYreg";
            this.lblYreg.Size = new System.Drawing.Size(24, 16);
            this.lblYreg.TabIndex = 8;
            this.lblYreg.Text = "Y:";
            this.lblYreg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSPreg
            // 
            this.txtSPreg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSPreg.BackColor = System.Drawing.SystemColors.Control;
            this.txtSPreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSPreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSPreg.Location = new System.Drawing.Point(41, 87);
            this.txtSPreg.MaxLength = 2;
            this.txtSPreg.Name = "txtSPreg";
            this.txtSPreg.Size = new System.Drawing.Size(16, 15);
            this.txtSPreg.TabIndex = 11;
            this.txtSPreg.Text = "00";
            this.txtSPreg.GotFocus += new System.EventHandler(this.txt_GotFocus);
            this.txtSPreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSreg_KeyPress);
            this.txtSPreg.LostFocus += new System.EventHandler(this.txt_LostFocus);
            // 
            // lblSPreg
            // 
            this.lblSPreg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSPreg.AutoSize = true;
            this.lblSPreg.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSPreg.Location = new System.Drawing.Point(3, 86);
            this.lblSPreg.Name = "lblSPreg";
            this.lblSPreg.Size = new System.Drawing.Size(32, 16);
            this.lblSPreg.TabIndex = 10;
            this.lblSPreg.Text = "SP:";
            this.lblSPreg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nFlag
            // 
            this.nFlag.AutoSize = true;
            this.nFlag.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.nFlag.Location = new System.Drawing.Point(6, 19);
            this.nFlag.Name = "nFlag";
            this.nFlag.Size = new System.Drawing.Size(123, 20);
            this.nFlag.TabIndex = 13;
            this.nFlag.Text = "(N) Negative";
            this.nFlag.Click += new System.EventHandler(this.nFlag_Click);
            // 
            // vFlag
            // 
            this.vFlag.AutoSize = true;
            this.vFlag.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.vFlag.Location = new System.Drawing.Point(6, 45);
            this.vFlag.Name = "vFlag";
            this.vFlag.Size = new System.Drawing.Size(123, 20);
            this.vFlag.TabIndex = 14;
            this.vFlag.Text = "(V) Overflow";
            this.vFlag.Click += new System.EventHandler(this.vFlag_Click);
            // 
            // bFlag
            // 
            this.bFlag.AutoSize = true;
            this.bFlag.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.bFlag.Location = new System.Drawing.Point(6, 71);
            this.bFlag.Name = "bFlag";
            this.bFlag.Size = new System.Drawing.Size(99, 20);
            this.bFlag.TabIndex = 15;
            this.bFlag.Text = "(B) Break";
            this.bFlag.Click += new System.EventHandler(this.bFlag_Click);
            // 
            // dFlag
            // 
            this.dFlag.AutoSize = true;
            this.dFlag.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.dFlag.Location = new System.Drawing.Point(6, 97);
            this.dFlag.Name = "dFlag";
            this.dFlag.Size = new System.Drawing.Size(155, 20);
            this.dFlag.TabIndex = 16;
            this.dFlag.Text = "(D) Decimal Mode";
            this.dFlag.Click += new System.EventHandler(this.dFlag_Click);
            // 
            // iFlag
            // 
            this.iFlag.AutoSize = true;
            this.iFlag.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.iFlag.Location = new System.Drawing.Point(6, 123);
            this.iFlag.Name = "iFlag";
            this.iFlag.Size = new System.Drawing.Size(147, 20);
            this.iFlag.TabIndex = 17;
            this.iFlag.Text = "(I) IRQ Disable";
            this.iFlag.Click += new System.EventHandler(this.iFlag_Click);
            // 
            // zFlag
            // 
            this.zFlag.AutoSize = true;
            this.zFlag.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.zFlag.Location = new System.Drawing.Point(6, 149);
            this.zFlag.Name = "zFlag";
            this.zFlag.Size = new System.Drawing.Size(91, 20);
            this.zFlag.TabIndex = 18;
            this.zFlag.Text = "(Z) Zero";
            this.zFlag.Click += new System.EventHandler(this.zFlag_Click);
            // 
            // cFlag
            // 
            this.cFlag.AutoSize = true;
            this.cFlag.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.cFlag.Location = new System.Drawing.Point(6, 175);
            this.cFlag.Name = "cFlag";
            this.cFlag.Size = new System.Drawing.Size(99, 20);
            this.cFlag.TabIndex = 19;
            this.cFlag.Text = "(C) Carry";
            this.cFlag.Click += new System.EventHandler(this.cFlag_Click);
            // 
            // gbFlags
            // 
            this.gbFlags.AutoSize = true;
            this.gbFlags.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbFlags.Controls.Add(this.nFlag);
            this.gbFlags.Controls.Add(this.vFlag);
            this.gbFlags.Controls.Add(this.bFlag);
            this.gbFlags.Controls.Add(this.dFlag);
            this.gbFlags.Controls.Add(this.iFlag);
            this.gbFlags.Controls.Add(this.zFlag);
            this.gbFlags.Controls.Add(this.cFlag);
            this.gbFlags.Location = new System.Drawing.Point(12, 161);
            this.gbFlags.Name = "gbFlags";
            this.gbFlags.Size = new System.Drawing.Size(167, 216);
            this.gbFlags.TabIndex = 20;
            this.gbFlags.TabStop = false;
            this.gbFlags.Text = "Flags";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblPC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPC, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAreg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAreg, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblXreg, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtXreg, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblYreg, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtYreg, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSPreg, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtSPreg, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(76, 105);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // gbRegisters
            // 
            this.gbRegisters.AutoSize = true;
            this.gbRegisters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbRegisters.Controls.Add(this.tableLayoutPanel1);
            this.gbRegisters.Location = new System.Drawing.Point(12, 12);
            this.gbRegisters.Name = "gbRegisters";
            this.gbRegisters.Size = new System.Drawing.Size(88, 145);
            this.gbRegisters.TabIndex = 22;
            this.gbRegisters.TabStop = false;
            this.gbRegisters.Text = "Registers";
            // 
            // CPUViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(192, 390);
            this.Controls.Add(this.gbRegisters);
            this.Controls.Add(this.gbFlags);
            this.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CPUViewer";
            this.Text = "CPU Register Viewer";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CPUViewer_Closing);
            this.Load += new System.EventHandler(this.CPUView_Load);
            this.gbFlags.ResumeLayout(false);
            this.gbFlags.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbRegisters.ResumeLayout(false);
            this.gbRegisters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.TextBox txtAreg;
        private System.Windows.Forms.Label lblAreg;
        private System.Windows.Forms.TextBox txtXreg;
        private System.Windows.Forms.Label lblXreg;
        private System.Windows.Forms.TextBox txtYreg;
        private System.Windows.Forms.Label lblYreg;
        private System.Windows.Forms.TextBox txtSPreg;
        private System.Windows.Forms.Label lblSPreg;
        private System.Windows.Forms.CheckBox nFlag;
        private System.Windows.Forms.CheckBox vFlag;
        private System.Windows.Forms.CheckBox bFlag;
        private System.Windows.Forms.CheckBox dFlag;
        private System.Windows.Forms.CheckBox iFlag;
        private System.Windows.Forms.CheckBox zFlag;
        private System.Windows.Forms.CheckBox cFlag;
        private System.Windows.Forms.GroupBox gbFlags;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbRegisters;

    }
}
