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
            SpeakerTimer.TimerViewSettings timerViewSettings3 = new SpeakerTimer.TimerViewSettings();
            SpeakerTimer.TimerViewSettings.TimerVisualSettings timerVisualSettings3 = new SpeakerTimer.TimerViewSettings.TimerVisualSettings();
            SpeakerTimer.TimerViewSettings timerViewSettings4 = new SpeakerTimer.TimerViewSettings();
            SpeakerTimer.TimerViewSettings.TimerVisualSettings timerVisualSettings4 = new SpeakerTimer.TimerViewSettings.TimerVisualSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpToolStripLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pcbLiveIndicator = new System.Windows.Forms.PictureBox();
            this.timerPreview2 = new SpeakerTimer.TimerPreview();
            this.timerPreview1 = new SpeakerTimer.TimerPreview();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.displayToolStripItem = new SpeakerTimer.Presentation.DisplayToolStripItem();
            this.savedTimersToolStripItem = new SpeakerTimer.Presentation.SavedTimersTSDDButton();
            this.tsbCreateSequence = new System.Windows.Forms.ToolStripButton();
            this.tlpOuterLayout.SuspendLayout();
            this.tlpToolStripLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLiveIndicator)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpOuterLayout
            // 
            this.tlpOuterLayout.ColumnCount = 1;
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOuterLayout.Controls.Add(this.tlpToolStripLayout, 0, 2);
            this.tlpOuterLayout.Controls.Add(this.timerPreview2, 0, 5);
            this.tlpOuterLayout.Controls.Add(this.timerPreview1, 0, 4);
            this.tlpOuterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuterLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpOuterLayout.Name = "tlpOuterLayout";
            this.tlpOuterLayout.RowCount = 6;
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.Size = new System.Drawing.Size(1040, 522);
            this.tlpOuterLayout.TabIndex = 0;
            // 
            // tlpToolStripLayout
            // 
            this.tlpToolStripLayout.ColumnCount = 2;
            this.tlpToolStripLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToolStripLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpToolStripLayout.Controls.Add(this.pcbLiveIndicator, 1, 0);
            this.tlpToolStripLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpToolStripLayout.Location = new System.Drawing.Point(3, 33);
            this.tlpToolStripLayout.Name = "tlpToolStripLayout";
            this.tlpToolStripLayout.RowCount = 1;
            this.tlpToolStripLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToolStripLayout.Size = new System.Drawing.Size(1034, 24);
            this.tlpToolStripLayout.TabIndex = 2;
            // 
            // pcbLiveIndicator
            // 
            this.pcbLiveIndicator.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcbLiveIndicator.Image = global::SpeakerTimer.Properties.Resources.wpid_gfgffh;
            this.pcbLiveIndicator.Location = new System.Drawing.Point(1003, 3);
            this.pcbLiveIndicator.Name = "pcbLiveIndicator";
            this.pcbLiveIndicator.Size = new System.Drawing.Size(28, 18);
            this.pcbLiveIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLiveIndicator.TabIndex = 8;
            this.pcbLiveIndicator.TabStop = false;
            this.pcbLiveIndicator.Visible = false;
            // 
            // timerPreview2
            // 
            this.timerPreview2.DisplayName = "Un-named2";
            this.timerPreview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview2.IsLive = true;
            this.timerPreview2.Location = new System.Drawing.Point(3, 304);
            this.timerPreview2.MinimumSize = new System.Drawing.Size(0, 195);
            this.timerPreview2.Name = "timerPreview2";
            timerViewSettings3.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings3.BlinkOnExpired = false;
            timerViewSettings3.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings3.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings3.Duration = 0D;
            timerViewSettings3.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings3.FinalMessage = null;
            timerViewSettings3.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings3.Name = "Un-named2";
            timerViewSettings3.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings3.RunningColor = System.Drawing.Color.White;
            timerViewSettings3.SecondWarningColor = System.Drawing.Color.Orange;
            timerViewSettings3.SecondWarningTime = 0D;
            timerViewSettings3.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings3.TimerColor = System.Drawing.Color.White;
            timerViewSettings3.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings3.Title = "Untitled";
            timerVisualSettings3.BackgroundColor = System.Drawing.Color.Black;
            timerVisualSettings3.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerVisualSettings3.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerVisualSettings3.ExpiredColor = System.Drawing.Color.Red;
            timerVisualSettings3.MessageColor = System.Drawing.Color.DodgerBlue;
            timerVisualSettings3.PausedColor = System.Drawing.Color.Cyan;
            timerVisualSettings3.RunningColor = System.Drawing.Color.White;
            timerVisualSettings3.SecondWarningColor = System.Drawing.Color.Orange;
            timerVisualSettings3.StoppedColor = System.Drawing.Color.Silver;
            timerVisualSettings3.TimerColor = System.Drawing.Color.White;
            timerVisualSettings3.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerVisualSettings3.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings3.VisualSettings = timerVisualSettings3;
            timerViewSettings3.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings3.WarningTime = 0D;
            this.timerPreview2.Settings = timerViewSettings3;
            this.timerPreview2.Size = new System.Drawing.Size(1034, 215);
            this.timerPreview2.TabIndex = 1;
            this.timerPreview2.LoadRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_LoadRequested);
            this.timerPreview2.SaveRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_SaveRequested);
            this.timerPreview2.LiveStateChanged += new System.EventHandler(this.timerPreview2_LiveStateChanged);
            // 
            // timerPreview1
            // 
            this.timerPreview1.DisplayName = "Un-named3";
            this.timerPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview1.IsLive = true;
            this.timerPreview1.Location = new System.Drawing.Point(3, 83);
            this.timerPreview1.MinimumSize = new System.Drawing.Size(0, 195);
            this.timerPreview1.Name = "timerPreview1";
            timerViewSettings4.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings4.BlinkOnExpired = false;
            timerViewSettings4.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings4.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings4.Duration = 0D;
            timerViewSettings4.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings4.FinalMessage = null;
            timerViewSettings4.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings4.Name = "Un-named3";
            timerViewSettings4.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings4.RunningColor = System.Drawing.Color.White;
            timerViewSettings4.SecondWarningColor = System.Drawing.Color.Orange;
            timerViewSettings4.SecondWarningTime = 0D;
            timerViewSettings4.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings4.TimerColor = System.Drawing.Color.White;
            timerViewSettings4.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings4.Title = "Untitled";
            timerVisualSettings4.BackgroundColor = System.Drawing.Color.Black;
            timerVisualSettings4.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerVisualSettings4.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerVisualSettings4.ExpiredColor = System.Drawing.Color.Red;
            timerVisualSettings4.MessageColor = System.Drawing.Color.DodgerBlue;
            timerVisualSettings4.PausedColor = System.Drawing.Color.Cyan;
            timerVisualSettings4.RunningColor = System.Drawing.Color.White;
            timerVisualSettings4.SecondWarningColor = System.Drawing.Color.Orange;
            timerVisualSettings4.StoppedColor = System.Drawing.Color.Silver;
            timerVisualSettings4.TimerColor = System.Drawing.Color.White;
            timerVisualSettings4.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerVisualSettings4.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings4.VisualSettings = timerVisualSettings4;
            timerViewSettings4.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings4.WarningTime = 0D;
            this.timerPreview1.Settings = timerViewSettings4;
            this.timerPreview1.Size = new System.Drawing.Size(1034, 215);
            this.timerPreview1.TabIndex = 0;
            this.timerPreview1.LoadRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_LoadRequested);
            this.timerPreview1.SaveRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_SaveRequested);
            this.timerPreview1.LiveStateChanged += new System.EventHandler(this.timerPreview1_LiveStateChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripItem,
            this.savedTimersToolStripItem,
            this.tsbCreateSequence});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // displayToolStripItem
            // 
            this.displayToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.displayToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("displayToolStripItem.Image")));
            this.displayToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.displayToolStripItem.LivePreviewForm = null;
            this.displayToolStripItem.Name = "displayToolStripItem";
            this.displayToolStripItem.PresentForm = null;
            this.displayToolStripItem.Size = new System.Drawing.Size(88, 22);
            this.displayToolStripItem.Text = "Main Display";
            this.displayToolStripItem.PresentFormEventsRequired += new System.EventHandler(this.displayToolStripItem_PresentFormEventsRequired);
            this.displayToolStripItem.PresentFormEventsRemoved += new System.EventHandler(this.displayToolStripItem_PresentFormEventsRemoved);
            // 
            // savedTimersToolStripItem
            // 
            this.savedTimersToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.savedTimersToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("savedTimersToolStripItem.Image")));
            this.savedTimersToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savedTimersToolStripItem.Name = "savedTimersToolStripItem";
            this.savedTimersToolStripItem.Size = new System.Drawing.Size(56, 22);
            this.savedTimersToolStripItem.Text = "Timers";
            this.savedTimersToolStripItem.PresetsLoaded += new System.EventHandler<SpeakerTimer.PresetEventArgs>(this.savedTimersToolStripItem_PresetsLoaded);
            this.savedTimersToolStripItem.TimersSettingsOpened += new System.EventHandler<SpeakerTimer.PresetEventArgs>(this.savedTimersToolStripItem_TimersSettingsOpened);
            this.savedTimersToolStripItem.TimersSettingsDeleted += new System.EventHandler<SpeakerTimer.PresetEventArgs>(this.savedTimersToolStripItem_TimersSettingsDeleted);
            // 
            // tsbCreateSequence
            // 
            this.tsbCreateSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCreateSequence.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateSequence.Image")));
            this.tsbCreateSequence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateSequence.Name = "tsbCreateSequence";
            this.tsbCreateSequence.Size = new System.Drawing.Size(99, 22);
            this.tsbCreateSequence.Text = "Create Sequence";
            this.tsbCreateSequence.Click += new System.EventHandler(this.tsbCreateSequence_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 522);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tlpOuterLayout);
            this.KeyPreview = true;
            this.Name = "ControlPanel";
            this.Text = "Speaker Timer - Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ControlPanel_PreviewKeyDown);
            this.tlpOuterLayout.ResumeLayout(false);
            this.tlpToolStripLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLiveIndicator)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tlpToolStripLayout;
        private System.Windows.Forms.PictureBox pcbLiveIndicator;
        private Presentation.DisplayToolStripItem displayToolStripItem;
        private System.Windows.Forms.ToolStripButton tsbCreateSequence;
        private Presentation.SavedTimersTSDDButton savedTimersToolStripItem;
    }
}