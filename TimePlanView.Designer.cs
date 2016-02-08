namespace SpeakerTimer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tmvCurrentTimer = new SpeakerTimer.TimerView();
            this.tmvNextTimer = new SpeakerTimer.TimerView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tmvCurrentTimer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tmvNextTimer, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 217);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // 
            // TimePlanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimePlanView";
            this.Size = new System.Drawing.Size(337, 217);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TimerView tmvCurrentTimer;
        private TimerView tmvNextTimer;

    }
}
