namespace SpeakerTimer
{
    partial class TimerView
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
            this.lblTimer = new System.Windows.Forms.Label();
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentTimer = new System.Windows.Forms.Label();
            this.tlpOuterLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimer.Location = new System.Drawing.Point(88, 71);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(174, 45);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimer.DoubleClick += new System.EventHandler(this.lblTimer_DoubleClick);
            // 
            // tlpOuterLayout
            // 
            this.tlpOuterLayout.ColumnCount = 3;
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.Controls.Add(this.lblTimer, 1, 2);
            this.tlpOuterLayout.Controls.Add(this.lblCurrentTimer, 1, 1);
            this.tlpOuterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuterLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpOuterLayout.Name = "tlpOuterLayout";
            this.tlpOuterLayout.RowCount = 4;
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuterLayout.Size = new System.Drawing.Size(350, 171);
            this.tlpOuterLayout.TabIndex = 1;
            this.tlpOuterLayout.DoubleClick += new System.EventHandler(this.tlpOuterLayout_DoubleClick);
            // 
            // lblCurrentTimer
            // 
            this.lblCurrentTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTimer.AutoSize = true;
            this.lblCurrentTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTimer.Location = new System.Drawing.Point(88, 54);
            this.lblCurrentTimer.Name = "lblCurrentTimer";
            this.lblCurrentTimer.Size = new System.Drawing.Size(174, 17);
            this.lblCurrentTimer.TabIndex = 1;
            this.lblCurrentTimer.Text = "Current Timer";
            this.lblCurrentTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpOuterLayout);
            this.Name = "TimerView";
            this.Size = new System.Drawing.Size(350, 171);
            this.Leave += new System.EventHandler(this.TimerView_Leave);
            this.tlpOuterLayout.ResumeLayout(false);
            this.tlpOuterLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TableLayoutPanel tlpOuterLayout;
        private System.Windows.Forms.Label lblCurrentTimer;
    }
}
