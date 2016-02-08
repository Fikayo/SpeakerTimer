using System;
using System.Collections.Generic;
using System.Text;

namespace SpeakerTimer
{
    public class TimePlan
    {
        private static readonly TimerViewSettings GeneralSetting = TimerViewSettings.Default;

        private int currentTimerIndex;
        private readonly List<TimerViewSettings> plan;

        public TimePlan()
        {
            this.currentTimerIndex = -1;
            this.plan = new List<TimerViewSettings>();
        }

        public TimerViewSettings CurrentTimer
        {
            get
            {
                return this.plan[this.currentTimerIndex % this.plan.Count];
            }
        }

        public TimerViewSettings NextTimer
        {
            get
            {
                return this.plan[(this.currentTimerIndex + 1) % this.plan.Count];
            }
        }


        public void AddTimer(string timerString)
        {
            this.AddTimer(TimerViewSettings.ParseCsv(timerString));
        }

        public void AddTimer(TimerViewSettings timer)
        {
            timer.CounterMode = TimerViewSettings.TimerCounterMode.CountDownToMinus;
            timer.DisplayMode = TimerViewSettings.TimerDisplayMode.FullWidth;
            this.plan.Add(timer);
        }

        public bool RemoveTimer(TimerViewSettings timer)
        {
            return this.plan.Remove(timer);
        }

        public bool RemoveTimer(string timerString)
        {
            return this.RemoveTimer(TimerViewSettings.ParseCsv(timerString));
        }

        public void Advance()
        {
            this.currentTimerIndex++;

            this.CurrentTimer.SetFont(string.Empty, 30);
            this.NextTimer.SetFont(string.Empty, 15);
        }
    }
}
