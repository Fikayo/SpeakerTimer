namespace ChurchTimer.Presentation
{
    partial class TimePlanForm
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
        private void InitializeComponent(Application.SettingsManager<Application.SequenceTimerSettings> settingsManager)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimePlanForm));
            this.timePlanControl = new ChurchTimer.Presentation.TimePlanControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.displayToolStripItem = new ChurchTimer.Presentation.DisplayToolStripItem();
            this.savedTimersTSDDButton = new ChurchTimer.Presentation.SavedTimersTSDDButton<Application.SequenceTimerSettings>(settingsManager);
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timePlanControl
            // 
            this.timePlanControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timePlanControl.IsLive = true;
            this.timePlanControl.Location = new System.Drawing.Point(3, 3);
            this.timePlanControl.Name = "timePlanControl";
            this.timePlanControl.Size = new System.Drawing.Size(520, 256);
            this.timePlanControl.TabIndex = 6;
            this.timePlanControl.LiveStateChanged += new System.EventHandler(this.timePlanControl_LiveStateChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.timePlanControl, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 262);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripItem,
            this.savedTimersTSDDButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 25);
            this.toolStrip1.TabIndex = 9;
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
            // savedTimersTSDDButton
            // 
            this.savedTimersTSDDButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.savedTimersTSDDButton.Image = ((System.Drawing.Image)(resources.GetObject("savedTimersTSDDButton.Image")));
            this.savedTimersTSDDButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savedTimersTSDDButton.Name = "savedTimersTSDDButton";
            this.savedTimersTSDDButton.Size = new System.Drawing.Size(56, 22);
            this.savedTimersTSDDButton.Text = "Timers";
            this.savedTimersTSDDButton.TimersSettingsOpened += new System.EventHandler<ChurchTimer.Application.PresetEventArgs<Application.SequenceTimerSettings>>(this.savedTimersTSDDButton_TimersSettingsOpened);
            // 
            // TimePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(526, 290);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimePlanForm";
            this.Text = "TimePlanForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TimePlanControl timePlanControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Presentation.DisplayToolStripItem displayToolStripItem;
        private Presentation.SavedTimersTSDDButton<Application.SequenceTimerSettings> savedTimersTSDDButton;
    }
}