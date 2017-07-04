namespace ChurchTimer.Presentation
{
    partial class TimePlanView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tmvCurrentTimer = new ChurchTimer.Presentation.SimpleTimerView();
            this.tmvNextTimer = new ChurchTimer.Presentation.SimpleTimerView();
            this.tlpOuterLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpOuterLayout
            // 
            this.tlpOuterLayout.ColumnCount = 3;
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.Controls.Add(this.tmvCurrentTimer, 1, 1);
            this.tlpOuterLayout.Controls.Add(this.tmvNextTimer, 1, 2);
            this.tlpOuterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuterLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpOuterLayout.Name = "tlpOuterLayout";
            this.tlpOuterLayout.RowCount = 4;
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.Size = new System.Drawing.Size(337, 217);
            this.tlpOuterLayout.TabIndex = 0;
            // 
            // tmvCurrentTimer
            // 
            this.tmvCurrentTimer.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tmvCurrentTimer.BlinkInterval = 500;
            this.tmvCurrentTimer.CommandIssuer = null;
            this.tmvCurrentTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmvCurrentTimer.IsPreviewMode = false;
            this.tmvCurrentTimer.Location = new System.Drawing.Point(58, 51);
            this.tmvCurrentTimer.Name = "tmvCurrentTimer";
            this.tmvCurrentTimer.ShowLabel = true;
            this.tmvCurrentTimer.Size = new System.Drawing.Size(220, 81);
            this.tmvCurrentTimer.TabIndex = 1;
            this.tmvCurrentTimer.TimerColor = System.Drawing.SystemColors.ControlText;
            this.tmvCurrentTimer.TimerFont = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmvCurrentTimer.TimerState = ChurchTimer.Presentation.TimerState.Stopped;
            // 
            // tmvNextTimer
            // 
            this.tmvNextTimer.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tmvNextTimer.BlinkInterval = 500;
            this.tmvNextTimer.CommandIssuer = null;
            this.tmvNextTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmvNextTimer.IsPreviewMode = false;
            this.tmvNextTimer.Location = new System.Drawing.Point(58, 138);
            this.tmvNextTimer.Name = "tmvNextTimer";
            this.tmvNextTimer.ShowLabel = false;
            this.tmvNextTimer.Size = new System.Drawing.Size(220, 27);
            this.tmvNextTimer.TabIndex = 2;
            this.tmvNextTimer.TimerColor = System.Drawing.SystemColors.ControlText;
            this.tmvNextTimer.TimerFont = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmvNextTimer.TimerState = ChurchTimer.Presentation.TimerState.Stopped;
            // 
            // TimePlanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpOuterLayout);
            this.Name = "TimePlanView";
            this.Size = new System.Drawing.Size(337, 217);
            this.tlpOuterLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOuterLayout;
        private SimpleTimerView tmvCurrentTimer;
        private SimpleTimerView tmvNextTimer;

    }
}
