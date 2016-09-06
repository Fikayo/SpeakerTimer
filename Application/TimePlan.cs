using System;
using System.Collections.Generic;
using System.Text;

namespace SpeakerTimer
{
    public class TimePlan
    {
        private const int CurrentTimerFontSize = 30;
        private const int NextTimerFontSize = 15;

        private static readonly TimerViewSettings GeneralSetting = TimerViewSettings.Default;

        private int currentTimerIndex;
        private readonly List<TimerViewSettings> plan;

        public TimePlan()
        {
            this.currentTimerIndex = -1;
            this.plan = new List<TimerViewSettings>();
        }

        public int PlanLength
        {
            get { return this.plan.Count; }
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
                var nextIndex = this.currentTimerIndex + 1;
                //if (nextIndex >= this.plan.Count) return null;

                return this.plan[(nextIndex) % this.plan.Count];
            }
        }

        public bool AtLastTimer
        {
            get { return this.currentTimerIndex == this.plan.Count - 1; }
        }

        public void AddTimer(string timerString)
        {
            this.AddTimer(TimerViewSettings.ParseCsv(timerString));
        }

        public void AddTimer(TimerViewSettings timer)
        {
            timer.CounterMode = TimerViewSettings.TimerCounterMode.CountDownToMinus;
            timer.DisplayMode = TimerViewSettings.TimerDisplayMode.FullWidth;

            if (!this.plan.Contains(timer))
            {
                this.plan.Add(timer);
            }
        }

        public bool RemoveTimer(TimerViewSettings timer)
        {
            return this.plan.Remove(timer);
        }

        public bool RemoveTimer(string timerString)
        {
            return this.RemoveTimer(TimerViewSettings.ParseCsv(timerString));
        }

        public void ClearPlan()
        {
            this.plan.Clear();
        }

        public bool Advance()
        {
            this.currentTimerIndex++;
            if (this.currentTimerIndex >= this.plan.Count) return false;


            this.CurrentTimer.SetFont(string.Empty, TimePlan.CurrentTimerFontSize);
            var nextTimer = this.NextTimer;
            if (nextTimer != null)
            {
                nextTimer.SetFont(string.Empty, TimePlan.NextTimerFontSize);
            }

            return true;
        }
    }
}
