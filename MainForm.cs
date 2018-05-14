/*
 * MainForm.cs
 *
 * SixtyFive Main Form
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
using SixtyFive.Viewers;

namespace SixtyFive
{
    // Main MDI form
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        const int WM_SYSCOMMAND = 0x0112;
        const int SC_CLOSE = 0xF060;
        public bool bClosingEventFromParent = false;


        // Execution control variables
        private enum RunModes { stopped, run, start };
        private RunModes runmode;
        private Timer rundelay;
        private int[] runspeeds = { 10, 50, 100, 200, 300, 500, 1000, 2000 };

        // Machine
        private Machine machine;        // Machine to simulate

        // Viewer
        private MemViewer memview;      // Memory viewer window
        private DisasmViewer dasmview;  // Disassembly viewer window
        private CPUViewer cpuview;      // CPU register viewer window
        private LineAsm lineasm;		// Line Assembler
        private HexViewer hexview;
        private MachineBuilder mBuilder;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && m.WParam == (IntPtr)SC_CLOSE)
            {
                bClosingEventFromParent = true;
            }
            base.WndProc(ref m);
        }

        // Main startup routine, pass control to Main Form
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        // Load Main MDI form
        private void MainForm_Load(object sender, System.EventArgs e)
        {

            // Create new machine
            machine = new Machine();
            mBuilder = new MachineBuilder(machine);
            mBuilder.LoadMachine("machine.xml");

            // Create hex viewer form
            hexview = new HexViewer(machine.mem)
            {
                MdiParent = this
            };

            // Create memory viewer form
            memview = new MemViewer(machine.mem)
            {
                MdiParent = this
            };

            // Create disassembly viewer form
            dasmview = new DisasmViewer(machine.mem, machine.cpu)
            {
                MdiParent = this
            };

            // Create line assembler form
            lineasm = new LineAsm(machine.mem, machine.cpu)
            {
                MdiParent = this
            };

            // Create cpu register viewer form
            cpuview = new CPUViewer(machine.cpu)
            {
                MdiParent = this
            };
            cpuview.Unlock();

            // Setup run timer
            runmode = RunModes.stopped;
            rundelay = new Timer
            {
                Enabled = false,
                Interval = runspeeds[6]
            };
            rundelay.Tick += new EventHandler(rundelay_Tick);

            RestoreFormPositions();
            this.Show();
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void RestoreFormPositions()
        {
            FormState.GetFormPosition(this);
            FormState.GetFormPosition(dasmview);
            FormState.GetFormPosition(cpuview);
            FormState.GetFormPosition(lineasm);
            FormState.GetFormPosition(memview);
            FormState.GetFormPosition(hexview);
            dasmview.update();
            memview.SetSize();
        }

        private void SaveFormPositions()
        {
            FormState.SaveFormPosition(this);
            FormState.SaveFormPosition(dasmview);
            FormState.SaveFormPosition(cpuview);
            FormState.SaveFormPosition(lineasm);
            FormState.SaveFormPosition(memview);
            FormState.SaveFormPosition(hexview);
        }

        private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    Step();
                    break;
            }
        }

        #region Run control
        private void Step()
        {
            machine.stepcpu();
            updateForms();
        }

        private void Animate()
        {
            runmode = RunModes.run;
            toolbarMode();
            cpuview.Lock();
            rundelay.Enabled = true;
            rundelay.Start();
        }

        private void Stop()
        {
            btAnimate.Pushed = false;
            runmode = RunModes.stopped;
            toolbarMode();
            cpuview.Unlock();
            rundelay.Stop();
            rundelay.Enabled = false;
            machine.stopped = true;
        }

        private void Reset()
        {
            Stop();
            machine.Reset();
            updateForms();
        }

        private void Start()
        {
            machine.stopped = false;
            runmode = RunModes.start;
            toolbarMode();
            while (runmode == RunModes.start && machine.stopped == false)
            {
                machine.stepcpu();
                Application.DoEvents();
            }
            Stop();
            updateForms();
        }

        // Run delay timer handler
        private void rundelay_Tick(Object myObject, EventArgs myEventArgs)
        {
            machine.stepcpu();
            updateForms();
        }

        private void updateForms()
        {
            if (dasmview.Visible == true)
                dasmview.runupdate();
            if (cpuview.Visible == true)
                cpuview.update();
            if (memview.Visible == true)
                memview.update();
            //if (hexview.Visible == true)
            //hexview.update();
        }

        #endregion

        #region Toolbar handlers
        private void toolbarMode()
        {
            for (int i = 0; i < tbMain.Buttons.Count; i++)
            {
                tbMain.Buttons[i].Enabled = true;
            }

            switch (runmode)
            {
                case RunModes.stopped:
                    btStop.Enabled = false;
                    break;
                case RunModes.run:
                case RunModes.start:
                    btAnimate.Enabled = false;
                    btStart.Enabled = false;
                    btStep.Enabled = false;
                    break;
            }
        }


        private void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {

            switch (e.Button.Tag.ToString())
            {
                case "btAnimate":
                    Animate();
                    break;
                case "btStop":
                    Stop();
                    break;
                case "btStep":
                    Step();
                    break;
                case "btStart":
                    Start();
                    break;
                case "btReset":
                    Reset();
                    break;
            }
        }

        private void miSpeed_Select(object sender, System.EventArgs e)
        {
            MenuItem item;

            // Clear checks on existing items
            for (int i = 0; i < cmSpeed.MenuItems.Count; i++)
                cmSpeed.MenuItems[i].Checked = false;

            // Get item that was clicked
            item = (MenuItem)sender;
            item.Checked = true;
            rundelay.Interval = runspeeds[item.Index];
        }

        #endregion

        #region Menu handlers
        private void itmTraceOn_Click(object sender, System.EventArgs e)
        {
            machine.trace.Start();
            itmTraceOn.Checked = true;
            itmTraceOff.Checked = false;
        }

        private void itmTraceOff_Click(object sender, System.EventArgs e)
        {
            machine.trace.Stop();
            itmTraceOn.Checked = false;
            itmTraceOff.Checked = true;
        }

        private void breakpoints_Click(object sender, System.EventArgs e)
        {
            frmBreak frmBreakPoints = new frmBreak(machine.breakpoint);
            frmBreakPoints.ShowDialog();
        }

        private void miExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void miStop_Click(object sender, System.EventArgs e)
        {
            Stop();
        }

        private void miStart_Click(object sender, System.EventArgs e)
        {
            Start();
        }

        private void miStep_Click(object sender, System.EventArgs e)
        {
            Step();
        }

        private void miRun_Click(object sender, System.EventArgs e)
        {
            Animate();
        }

        private void miReset_Click(object sender, System.EventArgs e)
        {
            Reset();
        }

        private void miLoad_Click(object sender, System.EventArgs e)
        {
            string f;
            UInt16 start = 0;

            // Setup filters
            f = "Raw Binary (*.*)|*.*|";
            f = f + "Org Binary (*.*)|*.*|";
            f = f + "RAS Binary (*.*)|*.*";
            dlgOpenFile.Filter = f;

            // Show file open dialog box
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                FileReader fl = new FileReader(machine.mem);
                FileType ft;


                // Determine file type 
                ft = FileType.BinaryRAW;

                switch (dlgOpenFile.FilterIndex)
                {
                    case 1:
                        // Get start address from user
                        frmRangeInput ri = new frmRangeInput(RangeInputType.OneAddress);
                        ri.ShowDialog();
                        start = ri.start;
                        ri.Close();
                        ri = null;

                        ft = FileType.BinaryRAW;
                        break;
                    case 2:
                        ft = FileType.BinaryORG;
                        break;
                    case 3:
                        ft = FileType.RAS;
                        break;
                }

                // Attempt to load file
                if (!fl.LoadFile(dlgOpenFile.FileName, ft, start))
                {
                    MessageBox.Show(fl.errmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                }
            }
            updateForms();
        }

        private void miClearAll_Click(object sender, System.EventArgs e)
        {
            machine.mem.ClearMem();
            updateForms();
        }

        private void miFill_Click(object sender, System.EventArgs e)
        {
            // Get the fill parameters from the user
            frmRangeInput ri = new frmRangeInput(RangeInputType.TwoAddressData);
            ri.ShowDialog();
            ri.Close();

            // If user didn't cancel, do the fill
            if (!ri.cancel)
                machine.mem.FillMem(ri.start, ri.end, ri.data);

            // Cleanup
            ri = null;
            updateForms();
        }

        private void miViewMemory_Click(object sender, System.EventArgs e)
        {
            memview.Show();
            memview.update();
        }

        private void miViewRegisters_Click(object sender, System.EventArgs e)
        {
            cpuview.Show();
            cpuview.update();
        }

        private void miViewDissaembly_Click(object sender, System.EventArgs e)
        {
            dasmview.Show();
            dasmview.update();
        }

        private void miViewAssembler_Click(object sender, System.EventArgs e)
        {
            lineasm.Show();
        }

        private void miMemGoto_Click(object sender, System.EventArgs e)
        {
            UInt16 addr;

            // Exit if memory view and dasmviewer don't have focus
            if (memview.Focused == false && dasmview.Focused == false)
                return;

            // Get address from user
            frmRangeInput ri = new frmRangeInput(RangeInputType.OneAddress);
            ri.ShowDialog();

            // Check if user clicked cancel
            if (ri.cancel)
                return;

            addr = ri.start;
            ri.Close();
            ri = null;

            if (memview.Focused == true)
                memview.SetCurrentAddress(addr);
            if (dasmview.Focused == true)
                dasmview.SetCurrentAddress(addr);

        }

        private void miHelp_Click(object sender, System.EventArgs e)
        {
            Help.ShowHelp(this, "sim6502.chm");
        }

        private void miAbout_Click(object sender, System.EventArgs e)
        {
            frmAbout abt = new frmAbout();
            abt.ShowDialog();
        }

        private void miTile_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            cpuview.SetSize();
            dasmview.SetSize();
        }

        private void miCascade_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
            cpuview.SetSize();
            dasmview.SetSize();
        }

        #endregion

        private void miSavePositions_Click(object sender, System.EventArgs e)
        {
            SaveFormPositions();
        }

        private void miRestorePositions_Click(object sender, System.EventArgs e)
        {
            RestoreFormPositions();
        }
    }
}
