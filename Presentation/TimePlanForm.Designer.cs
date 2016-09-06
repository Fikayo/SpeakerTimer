namespace SpeakerTimer
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
        private void InitializeComponent()
        {
            this.ptsToolStrip = new SpeakerTimer.PresetationToolStrip();
            this.timePlanControl = new SpeakerTimer.TimePlanControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptsToolStrip
            // 
            this.ptsToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptsToolStrip.LivePreviewForm = null;
            this.ptsToolStrip.Location = new System.Drawing.Point(3, 3);
            this.ptsToolStrip.Name = "ptsToolStrip";
            this.ptsToolStrip.PresentForm = null;
            this.ptsToolStrip.ShowDisplayMenu = true;
            this.ptsToolStrip.ShowTimePlanMenu = true;
            this.ptsToolStrip.ShowTimerSettingsMenu = true;
            this.ptsToolStrip.Size = new System.Drawing.Size(520, 30);
            this.ptsToolStrip.TabIndex = 7;
            this.ptsToolStrip.PresentFormRequired += new System.EventHandler(this.ptsToolStrip_PresentFormRequired);
            this.ptsToolStrip.LivePreviewFormRequired += new System.EventHandler(this.ptsToolStrip_LivePreviewFormRequired);
            this.ptsToolStrip.PresentFormEventsRequired += new System.EventHandler(this.ptsToolStrip_PresentFormEventsRequired);
            this.ptsToolStrip.TimersSettingsOpened += new System.EventHandler<SpeakerTimer.PresetEventArgs>(this.ptsToolStrip_TimersSettingsOpened);
            // 
            // timePlanControl
            // 
            this.timePlanControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timePlanControl.IsLive = true;
            this.timePlanControl.Location = new System.Drawing.Point(3, 39);
            this.timePlanControl.Name = "timePlanControl";
            this.timePlanControl.Size = new System.Drawing.Size(520, 248);
            this.timePlanControl.TabIndex = 6;
            this.timePlanControl.LiveStateChanged += new System.EventHandler(this.timePlanControl_LiveStateChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ptsToolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.timePlanControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 290);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // TimePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(526, 290);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimePlanForm";
            this.Text = "TimePlanForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TimePlanControl timePlanControl;
        private PresetationToolStrip ptsToolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}