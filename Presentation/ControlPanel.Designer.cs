namespace SpeakerTimer.Presentation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.timerPreview2 = new SpeakerTimer.Presentation.TimerPreview();
            this.timerPreview1 = new SpeakerTimer.Presentation.TimerPreview();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.displayToolStripItem = new SpeakerTimer.Presentation.DisplayToolStripItem();
            this.savedTimersToolStripItem = new SpeakerTimer.Presentation.SavedTimersTSDDButton();
            this.tsbCreateSequence = new System.Windows.Forms.ToolStripButton();
            this.tsdHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openControlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpOuterLayout.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
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
            this.tlpOuterLayout.Size = new System.Drawing.Size(1054, 522);
            this.tlpOuterLayout.TabIndex = 0;
            // 
            // timerPreview2
            // 
            this.timerPreview2.DisplayName = "Un-named-2";
            this.timerPreview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview2.IsLive = true;
            this.timerPreview2.Location = new System.Drawing.Point(3, 274);
            this.timerPreview2.MinimumSize = new System.Drawing.Size(0, 195);
            this.timerPreview2.Name = "timerPreview2";
            this.timerPreview2.Size = new System.Drawing.Size(1048, 245);
            this.timerPreview2.TabIndex = 1;
            this.timerPreview2.LoadRequested += new System.EventHandler<SpeakerTimer.Application.SettingIOEventArgs>(this.timerPreview_LoadRequested);
            this.timerPreview2.SaveRequested += new System.EventHandler<SpeakerTimer.Application.SettingIOEventArgs>(this.timerPreview_SaveRequested);
            this.timerPreview2.TimeElapsed += new System.EventHandler(this.timerPreview_TimeElapsed);
            this.timerPreview2.LiveStateChanged += new System.EventHandler(this.timerPreview2_LiveStateChanged);
            // 
            // timerPreview1
            // 
            this.timerPreview1.DisplayName = "Un-named-2";
            this.timerPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerPreview1.IsLive = true;
            this.timerPreview1.Location = new System.Drawing.Point(3, 23);
            this.timerPreview1.MinimumSize = new System.Drawing.Size(0, 195);
            this.timerPreview1.Name = "timerPreview1";
            this.timerPreview1.Size = new System.Drawing.Size(1048, 245);
            this.timerPreview1.TabIndex = 0;
            this.timerPreview1.LoadRequested += new System.EventHandler<SpeakerTimer.Application.SettingIOEventArgs>(this.timerPreview_LoadRequested);
            this.timerPreview1.SaveRequested += new System.EventHandler<SpeakerTimer.Application.SettingIOEventArgs>(this.timerPreview_SaveRequested);
            this.timerPreview1.TimeElapsed += new System.EventHandler(this.timerPreview_TimeElapsed);
            this.timerPreview1.LiveStateChanged += new System.EventHandler(this.timerPreview1_LiveStateChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripItem,
            this.savedTimersToolStripItem,
            this.tsbCreateSequence,
            this.tsdHelp});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1054, 25);
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
            this.savedTimersToolStripItem.PresetsLoaded += new System.EventHandler<SpeakerTimer.Application.PresetEventArgs>(this.savedTimersToolStripItem_PresetsLoaded);
            this.savedTimersToolStripItem.TimersSettingsOpened += new System.EventHandler<SpeakerTimer.Application.PresetEventArgs>(this.savedTimersToolStripItem_TimersSettingsOpened);
            this.savedTimersToolStripItem.TimersSettingsDeleted += new System.EventHandler<SpeakerTimer.Application.PresetEventArgs>(this.savedTimersToolStripItem_TimersSettingsDeleted);
            // 
            // tsbCreateSequence
            // 
            this.tsbCreateSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCreateSequence.Enabled = false;
            this.tsbCreateSequence.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateSequence.Image")));
            this.tsbCreateSequence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateSequence.Name = "tsbCreateSequence";
            this.tsbCreateSequence.Size = new System.Drawing.Size(99, 22);
            this.tsbCreateSequence.Text = "Create Sequence";
            this.tsbCreateSequence.Click += new System.EventHandler(this.tsbCreateSequence_Click);
            // 
            // tsdHelp
            // 
            this.tsdHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiAbout});
            this.tsdHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsdHelp.Image")));
            this.tsdHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdHelp.Name = "tsdHelp";
            this.tsdHelp.Size = new System.Drawing.Size(45, 22);
            this.tsdHelp.Text = "Help";
            // 
            // tsiAbout
            // 
            this.tsiAbout.Name = "tsiAbout";
            this.tsiAbout.Size = new System.Drawing.Size(107, 22);
            this.tsiAbout.Text = "About";
            this.tsiAbout.Click += new System.EventHandler(this.tsiAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 500);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(1054, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Image = global::SpeakerTimer.Properties.Resources._46729351_live_images;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openControlPanelToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(179, 26);
            // 
            // openControlPanelToolStripMenuItem
            // 
            this.openControlPanelToolStripMenuItem.Name = "openControlPanelToolStripMenuItem";
            this.openControlPanelToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openControlPanelToolStripMenuItem.Text = "Open Control Panel";
            this.openControlPanelToolStripMenuItem.Click += new System.EventHandler(this.openControlPanelToolStripMenuItem_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 522);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tlpOuterLayout);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1070, 500);
            this.Name = "ControlPanel";
            this.Text = "Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ControlPanel_PreviewKeyDown);
            this.tlpOuterLayout.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripDropDownButton tsdHelp;
        private System.Windows.Forms.ToolStripMenuItem tsiAbout;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openControlPanelToolStripMenuItem;
    }
}