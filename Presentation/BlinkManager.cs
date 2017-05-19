﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SpeakerTimer
{
    internal class BlinkManager
    {
        private System.Timers.Timer timer;
        ////private Timer timer;

        public BlinkManager()
        {
            this.timer = new System.Timers.Timer(700);
            this.timer.Elapsed += Timer_Elapsed;

            ////this.timer = new Timer();
            ////this.timer.Tick += Timer_Tick;
            ////this.timer.Interval = 700;

            this.IsBlinking = false;
        }
        
        public event EventHandler Blink;

        /// <summary>
        /// Gets when the text is visible during blink
        /// </summary>
        public bool BlinkOn { get; private set; }

        public bool IsBlinking { get; private set; }

        public int Interval
        {
            //get { return (int)this.timer.Interval; }
            //set { this.timer.Interval = value; }
            get;set;
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
            Console.WriteLine("Blink: " + this.BlinkOn);
            this.OnBlink();
            this.BlinkOn = !this.BlinkOn;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Blink: " + this.BlinkOn + " - " + e.SignalTime);
            this.OnBlink();
            this.BlinkOn = !this.BlinkOn;
        }  
    }
}
