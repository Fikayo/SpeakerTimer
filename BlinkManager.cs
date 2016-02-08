using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SpeakerTimer
{
    internal class BlinkManager
    {
        private Timer timer;

        public BlinkManager()
        {
            this.timer = new Timer();
            this.timer.Tick += Timer_Tick;
            this.Interval = 700;

            this.IsBlinking = false;
        }
        
        public event EventHandler Blink;

        public bool BlinkOn { get; private set; }

        public bool IsBlinking { get; private set; }

        public int Interval
        {
            get { return this.timer.Interval; }
            set { this.timer.Interval = value; }
        }

        public void StartBlinking()
        {
            this.BlinkOn = true;
            this.IsBlinking = true;
            this.timer.Start();
        }

        public void StopBlinking()
        {
            this.timer.Stop();
            this.IsBlinking = false;
        }

        private void OnBlink()
        {
            var handler = this.Blink;
            if (handler!=null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.OnBlink();
            this.BlinkOn = !this.BlinkOn;
        }
    }
}
