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
            SpeakerTimer.TimerViewSettings timerViewSettings9 = new SpeakerTimer.TimerViewSettings();
            SpeakerTimer.TimerViewSettings.TimerVisualSettings timerVisualSettings9 = new SpeakerTimer.TimerViewSettings.TimerVisualSettings();
            SpeakerTimer.TimerViewSettings timerViewSettings10 = new SpeakerTimer.TimerViewSettings();
            SpeakerTimer.TimerViewSettings.TimerVisualSettings timerVisualSettings10 = new SpeakerTimer.TimerViewSettings.TimerVisualSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.timerPreview2 = new SpeakerTimer.TimerPreview();
            this.timerPreview1 = new SpeakerTimer.TimerPreview();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.displayToolStripItem = new SpeakerTimer.Presentation.DisplayToolStripItem();
            this.savedTimersToolStripItem = new SpeakerTimer.Presentation.SavedTimersTSDDButton();
            this.tsbCreateSequence = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpOuterLayout.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpOuterLayout
            // 
            this.tlpOuterLayout.ColumnCount = 1;
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOuterLayout.Controls.Add(this.timerPreview2, 0, 2);
            this.tlpOuterLayout.Controls.Add(this.timerPreview1, 0, 1);
            this.tlpOuterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuterLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpOuterLayout.Name = "tlpOuterLayout";
            this.tlpOuterLayout.RowCount = 3;
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.Size = new System.Drawing.Size(1040, 522);
            this.tlpOuterLayout.TabIndex = 0;
            // 
            // timerPreview2
            // 
            this.timerPreview2.DisplayName = "Un-named2";
            this.timerPreview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview2.IsLive = true;
            this.timerPreview2.Location = new System.Drawing.Point(3, 274);
            this.timerPreview2.MinimumSize = new System.Drawing.Size(0, 195);
            this.timerPreview2.Name = "timerPreview2";
            timerViewSettings9.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings9.BlinkOnExpired = false;
            timerViewSettings9.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings9.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings9.Duration = 0D;
            timerViewSettings9.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings9.FinalMessage = null;
            timerViewSettings9.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings9.Name = "Un-named2";
            timerViewSettings9.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings9.RunningColor = System.Drawing.Color.White;
            timerViewSettings9.SecondWarningColor = System.Drawing.Color.Orange;
            timerViewSettings9.SecondWarningTime = 0D;
            timerViewSettings9.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings9.TimerColor = System.Drawing.Color.White;
            timerViewSettings9.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings9.Title = "Untitled";
            timerVisualSettings9.BackgroundColor = System.Drawing.Color.Black;
            timerVisualSettings9.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerVisualSettings9.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerVisualSettings9.ExpiredColor = System.Drawing.Color.Red;
            timerVisualSettings9.MessageColor = System.Drawing.Color.DodgerBlue;
            timerVisualSettings9.PausedColor = System.Drawing.Color.Cyan;
            timerVisualSettings9.RunningColor = System.Drawing.Color.White;
            timerVisualSettings9.SecondWarningColor = System.Drawing.Color.Orange;
            timerVisualSettings9.StoppedColor = System.Drawing.Color.Silver;
            timerVisualSettings9.TimerColor = System.Drawing.Color.White;
            timerVisualSettings9.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerVisualSettings9.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings9.VisualSettings = timerVisualSettings9;
            timerViewSettings9.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings9.WarningTime = 0D;
            this.timerPreview2.Settings = timerViewSettings9;
            this.timerPreview2.Size = new System.Drawing.Size(1034, 245);
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
            this.timerPreview1.Location = new System.Drawing.Point(3, 23);
            this.timerPreview1.MinimumSize = new System.Drawing.Size(0, 195);
            this.timerPreview1.Name = "timerPreview1";
            timerViewSettings10.BackgroundColor = System.Drawing.Color.Black;
            timerViewSettings10.BlinkOnExpired = false;
            timerViewSettings10.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerViewSettings10.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerViewSettings10.Duration = 0D;
            timerViewSettings10.ExpiredColor = System.Drawing.Color.Red;
            timerViewSettings10.FinalMessage = null;
            timerViewSettings10.MessageColor = System.Drawing.Color.DodgerBlue;
            timerViewSettings10.Name = "Un-named3";
            timerViewSettings10.PausedColor = System.Drawing.Color.Cyan;
            timerViewSettings10.RunningColor = System.Drawing.Color.White;
            timerViewSettings10.SecondWarningColor = System.Drawing.Color.Orange;
            timerViewSettings10.SecondWarningTime = 0D;
            timerViewSettings10.StoppedColor = System.Drawing.Color.Silver;
            timerViewSettings10.TimerColor = System.Drawing.Color.White;
            timerViewSettings10.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerViewSettings10.Title = "Untitled";
            timerVisualSettings10.BackgroundColor = System.Drawing.Color.Black;
            timerVisualSettings10.CounterMode = SpeakerTimer.TimerViewSettings.TimerCounterMode.CountDownToZero;
            timerVisualSettings10.DisplayMode = SpeakerTimer.TimerViewSettings.TimerDisplayMode.FullWidth;
            timerVisualSettings10.ExpiredColor = System.Drawing.Color.Red;
            timerVisualSettings10.MessageColor = System.Drawing.Color.DodgerBlue;
            timerVisualSettings10.PausedColor = System.Drawing.Color.Cyan;
            timerVisualSettings10.RunningColor = System.Drawing.Color.White;
            timerVisualSettings10.SecondWarningColor = System.Drawing.Color.Orange;
            timerVisualSettings10.StoppedColor = System.Drawing.Color.Silver;
            timerVisualSettings10.TimerColor = System.Drawing.Color.White;
            timerVisualSettings10.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerVisualSettings10.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings10.VisualSettings = timerVisualSettings10;
            timerViewSettings10.WarningColor = System.Drawing.Color.Yellow;
            timerViewSettings10.WarningTime = 0D;
            this.timerPreview1.Settings = timerViewSettings10;
            this.timerPreview1.Size = new System.Drawing.Size(1034, 245);
            this.timerPreview1.TabIndex = 0;
            this.timerPreview1.LoadRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_LoadRequested);
            this.timerPreview1.SaveRequested += new System.EventHandler<SpeakerTimer.SettingIOEventArgs>(this.timerPreview_SaveRequested);
            this.timerPreview1.LiveStateChanged += new System.EventHandler(this.timerPreview1_LiveStateChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripItem,
            this.savedTimersToolStripItem,
            this.tsbCreateSequence});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1040, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
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
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 500);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(1040, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Image = global::SpeakerTimer.Properties.Resources._46729351_live_images;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(55, 17);
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 522);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tlpOuterLayout);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1030, 500);
            this.Name = "ControlPanel";
            this.Text = "Speaker Timer - Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ControlPanel_PreviewKeyDown);
            this.tlpOuterLayout.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOuterLayout;
        private TimerPreview timerPreview2;
        private TimerPreview timerPreview1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private Presentation.DisplayToolStripItem displayToolStripItem;
        private System.Windows.Forms.ToolStripButton tsbCreateSequence;
        private Presentation.SavedTimersTSDDButton savedTimersToolStripItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}