namespace SpeakerTimer.Application
{
    using System.Collections.Generic;

    public class TimePlan
    {
        private const int CurrentTimerFontSize = 30;
        private const int NextTimerFontSize = 15;

        private static readonly SimpleTimerSettings GeneralSetting = SimpleTimerSettings.Default;

        private int currentTimerIndex;
        private readonly List<SimpleTimerSettings> plan;

        public TimePlan()
        {
            this.currentTimerIndex = -1;
            this.plan = new List<SimpleTimerSettings>();
        }

        public int PlanLength
        {
            get { return this.plan.Count; }
        }

        public SimpleTimerSettings CurrentTimer
        {
            get
            {
                return this.plan[this.currentTimerIndex % this.plan.Count];
            }
        }

        public SimpleTimerSettings NextTimer
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
            this.AddTimer(SimpleTimerSettings.ParseCsv(timerString));
        }

        public void AddTimer(SimpleTimerSettings timer)
        {
            timer.VisualSettings.CounterMode = TimerVisualSettings.TimerCounterMode.CountDownToMinus;
            timer.VisualSettings.DisplayMode = TimerVisualSettings.TimerDisplayMode.FullWidth;

            if (!this.plan.Contains(timer))
            {
                this.plan.Add(timer);
            }
        }

        public bool RemoveTimer(SimpleTimerSettings timer)
        {
            return this.plan.Remove(timer);
        }

        public bool RemoveTimer(string timerString)
        {
            return this.RemoveTimer(SimpleTimerSettings.ParseCsv(timerString));
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
