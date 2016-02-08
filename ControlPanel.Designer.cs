namespace SpeakerTimer
{
    partial class ControlPanel
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
            SpeakerTimer.TimerViewSettings timerViewSettings1 = new SpeakerTimer.TimerViewSettings();
            SpeakerTimer.TimerViewSettings timerViewSettings2 = new SpeakerTimer.TimerViewSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timerPreview2 = new SpeakerTimer.TimerPreview();
            this.timerPreview1 = new SpeakerTimer.TimerPreview();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsiMainDisplay = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmShowDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKeepOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeDisplayScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefreshScreens = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMaximizeDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveDisplayBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.tslTimers = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmOpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefreshList = new System.Windows.Forms.ToolStripMenuItem();
            this.tslMakeTimePlan = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.timerPreview2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.timerPreview1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // timerPreview2
            // 
            this.timerPreview2.DisplayName = "Untitled9";
            this.timerPreview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview2.IsLive = true;
            this.timerPreview2.Location = new System.Drawing.Point(3, 253);
            this.timerPreview2.Name = "timerPreview2";
            timerViewSettings1.AutoPauseTime = 0D;
            timerViewSettings1.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings1.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings1.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings1.Duration = 0D;
            timerViewSettings1.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings1.FinalMessage = null;
            timerViewSettings1.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings1.Name = "Untitled9";
            timerViewSettings1.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings1.RunningColor = System.Drawing.Color.White;
            timerViewSettings1.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings1.TimerColor = System.Drawing.Color.White;
            timerViewSettings1.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings1.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings1.WarningTime = 0D;
            this.timerPreview2.Settings = timerViewSettings1;
            this.timerPreview2.Size = new System.Drawing.Size(877, 244);
            this.timerPreview2.TabIndex = 1;
            this.timerPreview2.LoadRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_LoadRequested);
            this.timerPreview2.SaveRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_SaveRequested);
            this.timerPreview2.LiveStateChanged += new System.EventHandler(this.timerPreview2_LiveStateChanged);
            // 
            // timerPreview1
            // 
            this.timerPreview1.DisplayName = "Untitled11";
            this.timerPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview1.IsLive = true;
            this.timerPreview1.Location = new System.Drawing.Point(3, 3);
            this.timerPreview1.Name = "timerPreview1";
            timerViewSettings2.AutoPauseTime = 0D;
            timerViewSettings2.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings2.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings2.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings2.Duration = 0D;
            timerViewSettings2.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings2.FinalMessage = null;
            timerViewSettings2.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings2.Name = "Untitled11";
            timerViewSettings2.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings2.RunningColor = System.Drawing.Color.White;
            timerViewSettings2.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings2.TimerColor = System.Drawing.Color.White;
            timerViewSettings2.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings2.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings2.WarningTime = 0D;
            this.timerPreview1.Settings = timerViewSettings2;
            this.timerPreview1.Size = new System.Drawing.Size(877, 244);
            this.timerPreview1.TabIndex = 0;
            this.timerPreview1.LoadRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_LoadRequested);
            this.timerPreview1.SaveRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_SaveRequested);
            this.timerPreview1.LiveStateChanged += new System.EventHandler(this.timerPreview1_LiveStateChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiMainDisplay,
            this.tslTimers,
            this.tslMakeTimePlan});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(883, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsiMainDisplay
            // 
            this.tsiMainDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDisplay,
            this.tsmKeepOnTop,
            this.tsmFullScreen,
            this.tsmChangeDisplayScreen,
            this.tsmMaximizeDisplay,
            this.tsmRemoveDisplayBorder});
            this.tsiMainDisplay.Name = "tsiMainDisplay";
            this.tsiMainDisplay.Size = new System.Drawing.Size(88, 22);
            this.tsiMainDisplay.Text = "Main Display";
            // 
            // tsmShowDisplay
            // 
            this.tsmShowDisplay.Name = "tsmShowDisplay";
            this.tsmShowDisplay.Size = new System.Drawing.Size(228, 22);
            this.tsmShowDisplay.Text = "Show Display Window";
            this.tsmShowDisplay.Click += new System.EventHandler(this.tsmShowDisplay_Click);
            // 
            // tsmKeepOnTop
            // 
            this.tsmKeepOnTop.Enabled = false;
            this.tsmKeepOnTop.Name = "tsmKeepOnTop";
            this.tsmKeepOnTop.Size = new System.Drawing.Size(228, 22);
            this.tsmKeepOnTop.Text = "Keep Display Window on Top";
            this.tsmKeepOnTop.Click += new System.EventHandler(this.tsmKeepOnTop_Click);
            // 
            // tsmFullScreen
            // 
            this.tsmFullScreen.Enabled = false;
            this.tsmFullScreen.Name = "tsmFullScreen";
            this.tsmFullScreen.Size = new System.Drawing.Size(228, 22);
            this.tsmFullScreen.Text = "Full Screen Display";
            this.tsmFullScreen.Click += new System.EventHandler(this.tsmFullScreen_Click);
            // 
            // tsmChangeDisplayScreen
            // 
            this.tsmChangeDisplayScreen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRefreshScreens});
            this.tsmChangeDisplayScreen.Enabled = false;
            this.tsmChangeDisplayScreen.Name = "tsmChangeDisplayScreen";
            this.tsmChangeDisplayScreen.Size = new System.Drawing.Size(228, 22);
            this.tsmChangeDisplayScreen.Text = "Change Display Screen";
            this.tsmChangeDisplayScreen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmChangeDisplayScreen_DropDownItemClicked);
            // 
            // tsmRefreshScreens
            // 
            this.tsmRefreshScreens.Name = "tsmRefreshScreens";
            this.tsmRefreshScreens.Size = new System.Drawing.Size(156, 22);
            this.tsmRefreshScreens.Text = "Refresh Screens";
            this.tsmRefreshScreens.Click += new System.EventHandler(this.tsmRefreshScreens_Click);
            // 
            // tsmMaximizeDisplay
            // 
            this.tsmMaximizeDisplay.Enabled = false;
            this.tsmMaximizeDisplay.Name = "tsmMaximizeDisplay";
            this.tsmMaximizeDisplay.Size = new System.Drawing.Size(228, 22);
            this.tsmMaximizeDisplay.Text = "Maximize Display";
            this.tsmMaximizeDisplay.Click += new System.EventHandler(this.tsmMaximizeDisplay_Click);
            // 
            // tsmRemoveDisplayBorder
            // 
            this.tsmRemoveDisplayBorder.Enabled = false;
            this.tsmRemoveDisplayBorder.Name = "tsmRemoveDisplayBorder";
            this.tsmRemoveDisplayBorder.Size = new System.Drawing.Size(228, 22);
            this.tsmRemoveDisplayBorder.Text = "Remove Display Border";
            this.tsmRemoveDisplayBorder.Click += new System.EventHandler(this.tsmRemoveDisplayBorder_Click);
            // 
            // tslTimers
            // 
            this.tslTimers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenSettings,
            this.tsmClearAll,
            this.tsmRefreshList});
            this.tslTimers.Name = "tslTimers";
            this.tslTimers.Size = new System.Drawing.Size(56, 22);
            this.tslTimers.Text = "Timers";
            // 
            // tsmOpenSettings
            // 
            this.tsmOpenSettings.Name = "tsmOpenSettings";
            this.tsmOpenSettings.Size = new System.Drawing.Size(179, 22);
            this.tsmOpenSettings.Text = "Timer Settings";
            this.tsmOpenSettings.Click += new System.EventHandler(this.tsmTimerSettings_Click);
            // 
            // tsmClearAll
            // 
            this.tsmClearAll.Name = "tsmClearAll";
            this.tsmClearAll.Size = new System.Drawing.Size(179, 22);
            this.tsmClearAll.Text = "Clear All Settings";
            this.tsmClearAll.Click += new System.EventHandler(this.tsmClearAll_Click);
            // 
            // tsmRefreshList
            // 
            this.tsmRefreshList.Name = "tsmRefreshList";
            this.tsmRefreshList.Size = new System.Drawing.Size(179, 22);
            this.tsmRefreshList.Text = "Refresh Settings List";
            this.tsmRefreshList.Click += new System.EventHandler(this.tsmRefreshList_Click);
            // 
            // tslMakeTimePlan
            // 
            this.tslMakeTimePlan.Name = "tslMakeTimePlan";
            this.tslMakeTimePlan.Size = new System.Drawing.Size(92, 22);
            this.tslMakeTimePlan.Text = "Make Time Plan";
            this.tslMakeTimePlan.Visible = false;
            this.tslMakeTimePlan.Click += new System.EventHandler(this.tslMakeTimePlan_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 528);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ControlPanel";
            this.Text = "Speaker Timer - Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ControlPanel_PreviewKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TimerPreview timerPreview2;
        private TimerPreview timerPreview1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsiMainDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmKeepOnTop;
        private System.Windows.Forms.ToolStripMenuItem tsmFullScreen;
        private System.Windows.Forms.ToolStripMenuItem tsmMaximizeDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeDisplayScreen;
        private System.Windows.Forms.ToolStripDropDownButton tslTimers;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmRefreshList;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveDisplayBorder;
        private System.Windows.Forms.ToolStripMenuItem tsmRefreshScreens;
        private System.Windows.Forms.ToolStripLabel tslMakeTimePlan;
    }
}