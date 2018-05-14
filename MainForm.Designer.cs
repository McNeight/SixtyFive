namespace SixtyFive
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbMain = new System.Windows.Forms.ToolBar();
            this.btStop = new System.Windows.Forms.ToolBarButton();
            this.btStart = new System.Windows.Forms.ToolBarButton();
            this.btStep = new System.Windows.Forms.ToolBarButton();
            this.btAnimate = new System.Windows.Forms.ToolBarButton();
            this.btSpeed = new System.Windows.Forms.ToolBarButton();
            this.cmSpeed = new System.Windows.Forms.ContextMenu();
            this.miSpeed1 = new System.Windows.Forms.MenuItem();
            this.miSpeed2 = new System.Windows.Forms.MenuItem();
            this.miSpeed3 = new System.Windows.Forms.MenuItem();
            this.miSpeed4 = new System.Windows.Forms.MenuItem();
            this.miSpeed5 = new System.Windows.Forms.MenuItem();
            this.miSpeed6 = new System.Windows.Forms.MenuItem();
            this.miSpeed7 = new System.Windows.Forms.MenuItem();
            this.miSpeed8 = new System.Windows.Forms.MenuItem();
            this.btReset = new System.Windows.Forms.ToolBarButton();
            this.ilToolBar = new System.Windows.Forms.ImageList(this.components);
            this.menuMain = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.miLoad = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.miViewRegisters = new System.Windows.Forms.MenuItem();
            this.miViewMemory = new System.Windows.Forms.MenuItem();
            this.miViewDissaembly = new System.Windows.Forms.MenuItem();
            this.miViewAssembler = new System.Windows.Forms.MenuItem();
            this.menuTrace = new System.Windows.Forms.MenuItem();
            this.itmTraceOn = new System.Windows.Forms.MenuItem();
            this.itmTraceOff = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miBreakpoints = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miStop = new System.Windows.Forms.MenuItem();
            this.miStart = new System.Windows.Forms.MenuItem();
            this.miStep = new System.Windows.Forms.MenuItem();
            this.miRun = new System.Windows.Forms.MenuItem();
            this.miReset = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miClearAll = new System.Windows.Forms.MenuItem();
            this.miFill = new System.Windows.Forms.MenuItem();
            this.miMemGoto = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.miTile = new System.Windows.Forms.MenuItem();
            this.miCascade = new System.Windows.Forms.MenuItem();
            this.miSavePositions = new System.Windows.Forms.MenuItem();
            this.miRestorePositions = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.miHelp = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btStop,
            this.btStart,
            this.btStep,
            this.btAnimate,
            this.btSpeed,
            this.btReset});
            this.tbMain.DropDownArrows = true;
            this.tbMain.ImageList = this.ilToolBar;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.ShowToolTips = true;
            this.tbMain.Size = new System.Drawing.Size(728, 28);
            this.tbMain.TabIndex = 1;
            this.tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbMain_ButtonClick);
            // 
            // btStop
            // 
            this.btStop.ImageIndex = 2;
            this.btStop.Name = "btStop";
            this.btStop.Tag = "btStop";
            this.btStop.ToolTipText = "Stop";
            // 
            // btStart
            // 
            this.btStart.ImageIndex = 4;
            this.btStart.Name = "btStart";
            this.btStart.Tag = "btStart";
            this.btStart.ToolTipText = "Start";
            // 
            // btStep
            // 
            this.btStep.ImageIndex = 0;
            this.btStep.Name = "btStep";
            this.btStep.Tag = "btStep";
            this.btStep.ToolTipText = "Step";
            // 
            // btAnimate
            // 
            this.btAnimate.ImageIndex = 1;
            this.btAnimate.Name = "btAnimate";
            this.btAnimate.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.btAnimate.Tag = "btAnimate";
            this.btAnimate.ToolTipText = "Animate";
            // 
            // btSpeed
            // 
            this.btSpeed.DropDownMenu = this.cmSpeed;
            this.btSpeed.ImageIndex = 3;
            this.btSpeed.Name = "btSpeed";
            this.btSpeed.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            // 
            // cmSpeed
            // 
            this.cmSpeed.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSpeed1,
            this.miSpeed2,
            this.miSpeed3,
            this.miSpeed4,
            this.miSpeed5,
            this.miSpeed6,
            this.miSpeed7,
            this.miSpeed8});
            // 
            // miSpeed1
            // 
            this.miSpeed1.Index = 0;
            this.miSpeed1.Text = "1";
            this.miSpeed1.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // miSpeed2
            // 
            this.miSpeed2.Index = 1;
            this.miSpeed2.Text = "2";
            this.miSpeed2.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // miSpeed3
            // 
            this.miSpeed3.Index = 2;
            this.miSpeed3.Text = "3";
            this.miSpeed3.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // miSpeed4
            // 
            this.miSpeed4.Index = 3;
            this.miSpeed4.Text = "4";
            this.miSpeed4.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // miSpeed5
            // 
            this.miSpeed5.Index = 4;
            this.miSpeed5.Text = "5";
            this.miSpeed5.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // miSpeed6
            // 
            this.miSpeed6.Index = 5;
            this.miSpeed6.Text = "6";
            this.miSpeed6.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // miSpeed7
            // 
            this.miSpeed7.Checked = true;
            this.miSpeed7.DefaultItem = true;
            this.miSpeed7.Index = 6;
            this.miSpeed7.Text = "7";
            this.miSpeed7.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // miSpeed8
            // 
            this.miSpeed8.Index = 7;
            this.miSpeed8.Text = "8";
            this.miSpeed8.Click += new System.EventHandler(this.miSpeed_Select);
            // 
            // btReset
            // 
            this.btReset.ImageIndex = 5;
            this.btReset.Name = "btReset";
            this.btReset.Tag = "btReset";
            this.btReset.ToolTipText = "Reset";
            // 
            // ilToolBar
            // 
            this.ilToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolBar.ImageStream")));
            this.ilToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolBar.Images.SetKeyName(0, "");
            this.ilToolBar.Images.SetKeyName(1, "");
            this.ilToolBar.Images.SetKeyName(2, "");
            this.ilToolBar.Images.SetKeyName(3, "");
            this.ilToolBar.Images.SetKeyName(4, "");
            this.ilToolBar.Images.SetKeyName(5, "");
            // 
            // menuMain
            // 
            this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuItem4,
            this.menuTrace,
            this.menuItem2,
            this.menuItem3,
            this.menuItem6,
            this.menuItem5});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miLoad,
            this.miExit});
            this.menuFile.Text = "&File";
            // 
            // miLoad
            // 
            this.miLoad.Index = 0;
            this.miLoad.Text = "Load...";
            this.miLoad.Click += new System.EventHandler(this.miLoad_Click);
            // 
            // miExit
            // 
            this.miExit.Index = 1;
            this.miExit.Text = "&Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miViewRegisters,
            this.miViewMemory,
            this.miViewDissaembly,
            this.miViewAssembler,
            this.menuItem7});
            this.menuItem4.Text = "&View";
            // 
            // miViewRegisters
            // 
            this.miViewRegisters.Index = 0;
            this.miViewRegisters.Text = "Registers";
            this.miViewRegisters.Click += new System.EventHandler(this.miViewRegisters_Click);
            // 
            // miViewMemory
            // 
            this.miViewMemory.Index = 1;
            this.miViewMemory.Text = "Memory";
            this.miViewMemory.Click += new System.EventHandler(this.miViewMemory_Click);
            // 
            // miViewDissaembly
            // 
            this.miViewDissaembly.Index = 2;
            this.miViewDissaembly.Text = "Disassembly";
            this.miViewDissaembly.Click += new System.EventHandler(this.miViewDissaembly_Click);
            // 
            // miViewAssembler
            // 
            this.miViewAssembler.Index = 3;
            this.miViewAssembler.Text = "Assembler";
            this.miViewAssembler.Click += new System.EventHandler(this.miViewAssembler_Click);
            // 
            // menuTrace
            // 
            this.menuTrace.Index = 2;
            this.menuTrace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmTraceOn,
            this.itmTraceOff,
            this.menuItem1,
            this.miBreakpoints});
            this.menuTrace.Text = "&Debug";
            // 
            // itmTraceOn
            // 
            this.itmTraceOn.Index = 0;
            this.itmTraceOn.RadioCheck = true;
            this.itmTraceOn.ShowShortcut = false;
            this.itmTraceOn.Text = "Trace On";
            this.itmTraceOn.Click += new System.EventHandler(this.itmTraceOn_Click);
            // 
            // itmTraceOff
            // 
            this.itmTraceOff.Checked = true;
            this.itmTraceOff.Index = 1;
            this.itmTraceOff.RadioCheck = true;
            this.itmTraceOff.Text = "Trace Off";
            this.itmTraceOff.Click += new System.EventHandler(this.itmTraceOff_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // miBreakpoints
            // 
            this.miBreakpoints.Index = 3;
            this.miBreakpoints.Text = "Breakpoints...";
            this.miBreakpoints.Click += new System.EventHandler(this.breakpoints_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miStop,
            this.miStart,
            this.miStep,
            this.miRun,
            this.miReset});
            this.menuItem2.Text = "&Run";
            // 
            // miStop
            // 
            this.miStop.Index = 0;
            this.miStop.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.miStop.Text = "Stop";
            this.miStop.Click += new System.EventHandler(this.miStop_Click);
            // 
            // miStart
            // 
            this.miStart.Index = 1;
            this.miStart.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.miStart.Text = "Start";
            this.miStart.Click += new System.EventHandler(this.miStart_Click);
            // 
            // miStep
            // 
            this.miStep.Index = 2;
            this.miStep.Shortcut = System.Windows.Forms.Shortcut.F7;
            this.miStep.Text = "Step";
            this.miStep.Click += new System.EventHandler(this.miStep_Click);
            // 
            // miRun
            // 
            this.miRun.Index = 3;
            this.miRun.Shortcut = System.Windows.Forms.Shortcut.F8;
            this.miRun.Text = "Animate";
            this.miRun.Click += new System.EventHandler(this.miRun_Click);
            // 
            // miReset
            // 
            this.miReset.Index = 4;
            this.miReset.Shortcut = System.Windows.Forms.Shortcut.F12;
            this.miReset.Text = "Reset";
            this.miReset.Click += new System.EventHandler(this.miReset_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miClearAll,
            this.miFill,
            this.miMemGoto});
            this.menuItem3.Text = "&Memory";
            // 
            // miClearAll
            // 
            this.miClearAll.Index = 0;
            this.miClearAll.Text = "Clear All";
            this.miClearAll.Click += new System.EventHandler(this.miClearAll_Click);
            // 
            // miFill
            // 
            this.miFill.Index = 1;
            this.miFill.Text = "Fill...";
            this.miFill.Click += new System.EventHandler(this.miFill_Click);
            // 
            // miMemGoto
            // 
            this.miMemGoto.Index = 2;
            this.miMemGoto.Text = "Goto...";
            this.miMemGoto.Click += new System.EventHandler(this.miMemGoto_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miTile,
            this.miCascade,
            this.miSavePositions,
            this.miRestorePositions});
            this.menuItem6.Text = "Window";
            // 
            // miTile
            // 
            this.miTile.Index = 0;
            this.miTile.Text = "Tile";
            this.miTile.Click += new System.EventHandler(this.miTile_Click);
            // 
            // miCascade
            // 
            this.miCascade.Index = 1;
            this.miCascade.Text = "Cascade";
            this.miCascade.Click += new System.EventHandler(this.miCascade_Click);
            // 
            // miSavePositions
            // 
            this.miSavePositions.Index = 2;
            this.miSavePositions.Text = "Save Positions";
            this.miSavePositions.Click += new System.EventHandler(this.miSavePositions_Click);
            // 
            // miRestorePositions
            // 
            this.miRestorePositions.Index = 3;
            this.miRestorePositions.Text = "Restore Positions";
            this.miRestorePositions.Click += new System.EventHandler(this.miRestorePositions_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miHelp,
            this.miAbout});
            this.menuItem5.Text = "&Help";
            // 
            // miHelp
            // 
            this.miHelp.Index = 0;
            this.miHelp.Text = "Help...";
            this.miHelp.Click += new System.EventHandler(this.miHelp_Click);
            // 
            // miAbout
            // 
            this.miAbout.Index = 1;
            this.miAbout.Text = "About sim6502.net..";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "Hex";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(728, 414);
            this.Controls.Add(this.tbMain);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Menu = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Sim6502";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList ilToolBar;
        private System.Windows.Forms.ToolBarButton btStop;
        private System.Windows.Forms.ToolBar tbMain;
        private System.Windows.Forms.ToolBarButton btSpeed;
        private System.Windows.Forms.ContextMenu cmSpeed;
        private System.Windows.Forms.MainMenu menuMain;
        private System.Windows.Forms.MenuItem miSpeed1;
        private System.Windows.Forms.MenuItem miSpeed2;
        private System.Windows.Forms.MenuItem miSpeed3;
        private System.Windows.Forms.MenuItem miSpeed4;
        private System.Windows.Forms.MenuItem miSpeed5;
        private System.Windows.Forms.MenuItem miSpeed6;
        private System.Windows.Forms.MenuItem miSpeed7;
        private System.Windows.Forms.MenuItem miSpeed8;
        private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.ToolBarButton btStart;
        private System.Windows.Forms.MenuItem menuTrace;
        private System.Windows.Forms.MenuItem itmTraceOn;
        private System.Windows.Forms.MenuItem itmTraceOff;
        private System.Windows.Forms.ToolBarButton btReset;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem miBreakpoints;
        private System.Windows.Forms.MenuItem miLoad;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem miStop;
        private System.Windows.Forms.MenuItem miStart;
        private System.Windows.Forms.MenuItem miStep;
        private System.Windows.Forms.MenuItem miRun;
        private System.Windows.Forms.MenuItem miReset;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem miClearAll;
        private System.Windows.Forms.ToolBarButton btAnimate;
        private System.Windows.Forms.MenuItem miFill;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem miViewRegisters;
        private System.Windows.Forms.MenuItem miViewMemory;
        private System.Windows.Forms.MenuItem miViewDissaembly;
        private System.Windows.Forms.MenuItem miViewAssembler;
        private System.Windows.Forms.MenuItem miMemGoto;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem miHelp;
        private System.Windows.Forms.MenuItem miAbout;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem miTile;
        private System.Windows.Forms.MenuItem miCascade;
        private System.Windows.Forms.MenuItem miSavePositions;
        private System.Windows.Forms.MenuItem miRestorePositions;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.ToolBarButton btStep;

    }
}
