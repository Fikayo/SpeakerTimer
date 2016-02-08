namespace SpeakerTimer
{
    partial class PresentationTimerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresentationTimerForm));
            this.timerView = new SpeakerTimer.TimerView();
            this.SuspendLayout();
            // 
            // timerView
            // 
            this.timerView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.timerView.CommandIssuer = null;
            this.timerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerView.IsPreviewMode = false;
            this.timerView.Location = new System.Drawing.Point(0, 0);
            this.timerView.Name = "timerView";
            this.timerView.Size = new System.Drawing.Size(484, 249);
            this.timerView.TabIndex = 0;
            this.timerView.TimerColor = System.Drawing.SystemColors.ControlText;
            this.timerView.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timerView_KeyDown);
            // 
            // PresentationTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 249);
            this.Controls.Add(this.timerView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PresentationTimerForm";
            this.Text = "Speaker Timer - Display Window";
            this.ResumeLayout(false);

        }

        #endregion

        private TimerView timerView;
    }
}