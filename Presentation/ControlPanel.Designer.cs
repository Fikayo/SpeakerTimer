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
            SpeakerTimer.TimerViewSettings.TimerVisualSettings timerVisualSettings1 = new SpeakerTimer.TimerViewSettings.TimerVisualSettings();
            SpeakerTimer.TimerViewSettings timerViewSettings2 = new SpeakerTimer.TimerViewSettings();
            SpeakerTimer.TimerViewSettings.TimerVisualSettings timerVisualSettings2 = new SpeakerTimer.TimerViewSettings.TimerVisualSettings();
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ptsToolStrip = new SpeakerTimer.PresetationToolStrip();
            this.timerPreview2 = new SpeakerTimer.TimerPreview();
            this.timerPreview1 = new SpeakerTimer.TimerPreview();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsiMainDisplay = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmShowDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLivePreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKeepPreviewOnTop = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tlpOuterLayout.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpOuterLayout
            // 
            this.tlpOuterLayout.ColumnCount = 1;
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOuterLayout.Controls.Add(this.ptsToolStrip, 0, 2);
            this.tlpOuterLayout.Controls.Add(this.timerPreview2, 0, 4);
            this.tlpOuterLayout.Controls.Add(this.timerPreview1, 0, 3);
            this.tlpOuterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuterLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpOuterLayout.Name = "tlpOuterLayout";
            this.tlpOuterLayout.RowCount = 5;
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.Size = new System.Drawing.Size(1015, 715);
            this.tlpOuterLayout.TabIndex = 0;
            // 
            // ptsToolStrip
            // 
            this.ptsToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptsToolStrip.LivePreviewForm = null;
            this.ptsToolStrip.Location = new System.Drawing.Point(3, 43);
            this.ptsToolStrip.Name = "ptsToolStrip";
            this.ptsToolStrip.PresentForm = null;
            this.ptsToolStrip.ShowDisplayMenu = true;
            this.ptsToolStrip.ShowTimePlanMenu = true;
            this.ptsToolStrip.ShowTimerSettingsMenu = true;
            this.ptsToolStrip.Size = new System.Drawing.Size(1009, 24);
            this.ptsToolStrip.TabIndex = 2;
            this.ptsToolStrip.PresentFormEventsRequired += new System.EventHandler(this.ptsToolStrip_PresentFormEventsRequired);
            this.ptsToolStrip.PresetsLoaded += new System.EventHandler<SpeakerTimer.PresetEventArgs>(this.ptsToolStrip_PresetsLoaded);
            this.ptsToolStrip.TimersSettingsOpened += new System.EventHandler<SpeakerTimer.PresetEventArgs>(this.ptsToolStrip_TimersSettingsOpened);
            this.ptsToolStrip.TimersSettingsDeleted += new System.EventHandler<SpeakerTimer.PresetEventArgs>(this.ptsToolStrip_TimersSettingsDeleted);
            // 
            // timerPreview2
            // 
            this.timerPreview2.DisplayName = "Untitled9";
            this.timerPreview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview2.IsLive = true;
            this.timerPreview2.Location = new System.Drawing.Point(3, 395);
            this.timerPreview2.Name = "timerPreview2";
            timerViewSettings1.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings1.BlinkOnExpired = false;
            timerViewSettings1.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings1.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings1.Duration = 0D;
            timerViewSettings1.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings1.FinalMessage = null;
            timerViewSettings1.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings1.Name = "Untitled9";
            timerViewSettings1.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings1.RunningColor = System.Drawing.Color.White;
            timerViewSettings1.SecondWarningColor = System.Drawing.Color.Orange;
            timerViewSettings1.SecondWarningTime = 0D;
            timerViewSettings1.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings1.TimerColor = System.Drawing.Color.White;
            timerViewSettings1.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings1.Title = "Untitled";
            timerVisualSettings1.BackgroundColor = System.Drawing.Color.Black;
            timerVisualSettings1.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerVisualSettings1.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerVisualSettings1.ExpiredColor = System.Drawing.Color.Red;
            timerVisualSettings1.MessageColor = System.Drawing.Color.DodgerBlue;
            timerVisualSettings1.PausedColor = System.Drawing.Color.Cyan;
            timerVisualSettings1.RunningColor = System.Drawing.Color.White;
            timerVisualSettings1.SecondWarningColor = System.Drawing.Color.Orange;
            timerVisualSettings1.StoppedColor = System.Drawing.Color.Silver;
            timerVisualSettings1.TimerColor = System.Drawing.Color.White;
            timerVisualSettings1.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerVisualSettings1.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings1.VisualSettings = timerVisualSettings1;
            timerViewSettings1.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings1.WarningTime = 0D;
            this.timerPreview2.Settings = timerViewSettings1;
            this.timerPreview2.Size = new System.Drawing.Size(1009, 317);
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
            this.timerPreview1.Location = new System.Drawing.Point(3, 73);
            this.timerPreview1.Name = "timerPreview1";
            timerViewSettings2.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings2.BlinkOnExpired = false;
            timerViewSettings2.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings2.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings2.Duration = 0D;
            timerViewSettings2.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings2.FinalMessage = null;
            timerViewSettings2.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings2.Name = "Untitled11";
            timerViewSettings2.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings2.RunningColor = System.Drawing.Color.White;
            timerViewSettings2.SecondWarningColor = System.Drawing.Color.Orange;
            timerViewSettings2.SecondWarningTime = 0D;
            timerViewSettings2.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings2.TimerColor = System.Drawing.Color.White;
            timerViewSettings2.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings2.Title = "Untitled";
            timerVisualSettings2.BackgroundColor = System.Drawing.Color.Black;
            timerVisualSettings2.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerVisualSettings2.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerVisualSettings2.ExpiredColor = System.Drawing.Color.Red;
            timerVisualSettings2.MessageColor = System.Drawing.Color.DodgerBlue;
            timerVisualSettings2.PausedColor = System.Drawing.Color.Cyan;
            timerVisualSettings2.RunningColor = System.Drawing.Color.White;
            timerVisualSettings2.SecondWarningColor = System.Drawing.Color.Orange;
            timerVisualSettings2.StoppedColor = System.Drawing.Color.Silver;
            timerVisualSettings2.TimerColor = System.Drawing.Color.White;
            timerVisualSettings2.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerVisualSettings2.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings2.VisualSettings = timerVisualSettings2;
            timerViewSettings2.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings2.WarningTime = 0D;
            this.timerPreview1.Settings = timerViewSettings2;
            this.timerPreview1.Size = new System.Drawing.Size(1009, 316);
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
            this.toolStrip1.Size = new System.Drawing.Size(1015, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsiMainDisplay
            // 
            this.tsiMainDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDisplay,
            this.tsmShowLivePreview,
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
            this.tsmShowDisplay.Size = new System.Drawing.Size(229, 22);
            this.tsmShowDisplay.Text = "Show Display Window";
            this.tsmShowDisplay.Click += new System.EventHandler(this.tsmShowDisplay_Click);
            // 
            // tsmShowLivePreview
            // 
            this.tsmShowLivePreview.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmKeepPreviewOnTop});
            this.tsmShowLivePreview.Name = "tsmShowLivePreview";
            this.tsmShowLivePreview.Size = new System.Drawing.Size(229, 22);
            this.tsmShowLivePreview.Text = "Show Live Preview";
            this.tsmShowLivePreview.Click += new System.EventHandler(this.tsmShowLivePreview_Click);
            // 
            // tsmKeepPreviewOnTop
            // 
            this.tsmKeepPreviewOnTop.Name = "tsmKeepPreviewOnTop";
            this.tsmKeepPreviewOnTop.Size = new System.Drawing.Size(185, 22);
            this.tsmKeepPreviewOnTop.Text = "Keep Preview on Top";
            this.tsmKeepPreviewOnTop.Click += new System.EventHandler(this.tsmKeepPreviewOnTop_Click);
            // 
            // tsmKeepOnTop
            // 
            this.tsmKeepOnTop.Enabled = false;
            this.tsmKeepOnTop.Name = "tsmKeepOnTop";
            this.tsmKeepOnTop.Size = new System.Drawing.Size(229, 22);
            this.tsmKeepOnTop.Text = "Keep Display Window on Top";
            this.tsmKeepOnTop.Click += new System.EventHandler(this.tsmKeepOnTop_Click);
            // 
            // tsmFullScreen
            // 
            this.tsmFullScreen.Enabled = false;
            this.tsmFullScreen.Name = "tsmFullScreen";
            this.tsmFullScreen.Size = new System.Drawing.Size(229, 22);
            this.tsmFullScreen.Text = "Full Screen Display";
            this.tsmFullScreen.Click += new System.EventHandler(this.tsmFullScreen_Click);
            // 
            // tsmChangeDisplayScreen
            // 
            this.tsmChangeDisplayScreen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRefreshScreens});
            this.tsmChangeDisplayScreen.Enabled = false;
            this.tsmChangeDisplayScreen.Name = "tsmChangeDisplayScreen";
            this.tsmChangeDisplayScreen.Size = new System.Drawing.Size(229, 22);
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
            this.tsmMaximizeDisplay.Size = new System.Drawing.Size(229, 22);
            this.tsmMaximizeDisplay.Text = "Maximize Display";
            this.tsmMaximizeDisplay.Click += new System.EventHandler(this.tsmMaximizeDisplay_Click);
            // 
            // tsmRemoveDisplayBorder
            // 
            this.tsmRemoveDisplayBorder.Enabled = false;
            this.tsmRemoveDisplayBorder.Name = "tsmRemoveDisplayBorder";
            this.tsmRemoveDisplayBorder.Size = new System.Drawing.Size(229, 22);
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
            this.tsmOpenSettings.Click += new System.EventHandler(this.tsmOpenSettings_Click);
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
            this.tslMakeTimePlan.Click += new System.EventHandler(this.tslMakeTimePlan_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 715);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tlpOuterLayout);
            this.KeyPreview = true;
            this.Name = "ControlPanel";
            this.Text = "Speaker Timer - Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ControlPanel_PreviewKeyDown);
            this.tlpOuterLayout.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOuterLayout;
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
        private System.Windows.Forms.ToolStripMenuItem tsmShowLivePreview;
        private System.Windows.Forms.ToolStripMenuItem tsmKeepPreviewOnTop;
        private PresetationToolStrip ptsToolStrip;
    }
}