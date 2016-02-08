using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpeakerTimer
{
    public partial class PresentationTimerForm : Form
    {
        public const FormBorderStyle BorderStyle = FormBorderStyle.FixedSingle;
        public PresentationTimerForm()
        {
            InitializeComponent();
        }

        public PresentationTimerForm(TimerViewerCommandIssuer commandIssuer)
            : this()
        {
            this.CommandIssuer = commandIssuer;
        }

        public event EventHandler WindowStateChanged;

        public bool IsFullScreen { get; private set; }

        public TimerViewerCommandIssuer CommandIssuer
        {
            get { return this.timerView.CommandIssuer; }

            set { this.timerView.CommandIssuer = value; }
        }

        public void ToggleFullScreen()
        {
            if (this.IsFullScreen)
            {
                this.NormalWindowMode();
                return;
            }

            this.FullScreenWindow();
        }

        public void FullScreenWindow()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.IsFullScreen = true;
            this.OnWindowStateChanged();
        }

        public void NormalWindowMode()
        {
            this.FormBorderStyle = PresentationTimerForm.BorderStyle;
            this.WindowState = FormWindowState.Normal;
            this.IsFullScreen = false;
            this.OnWindowStateChanged();
        }

        public void CheckKeyPress(Keys key)
        {
            switch (key)
            {
                case Keys.Escape:
                    {
                        this.NormalWindowMode();
                        break;
                    }

                case Keys.F11:
                    {
                        this.ToggleFullScreen();
                        break;
                    }

                default:
                    break;
            }
        }

        private void OnWindowStateChanged()
        {
            var handler = this.WindowStateChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void timerView_KeyDown(object sender, KeyEventArgs e)
        {
            this.CheckKeyPress(e.KeyCode);
        }        
    }
}
