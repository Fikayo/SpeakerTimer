namespace ChurchTimer.Application.Settings
{
    public class TimerDurationSettings
    {
        private readonly int id;

        public TimerDurationSettings() :
            this(-1, 0, -1, -1)
        { }

        public TimerDurationSettings(int durationId, double duration, double warningTime, double secondWarningTime)
        {
            this.id = durationId;
            this.Duration = duration;
            this.FirstWarningTime = warningTime;
            this.SecondWarningTime = secondWarningTime;
        }

        public TimerDurationSettings(int durationId, TimerDurationSettings copy) :
            this(durationId, copy.Duration, copy.FirstWarningTime, copy.SecondWarningTime)
        {
        }

        public int DurationId { get { return this.id; } }
        
        public double Duration { get; set; } // In seconds

        public double FirstWarningTime { get; set; }

        public double SecondWarningTime { get; set; }

        public bool HasFirstWarning { get { return this.FirstWarningTime > 0; } }

        public bool HasSecondWarning { get { return this.SecondWarningTime > 0; } }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            TimerDurationSettings that = obj as TimerDurationSettings;
            if (that == null) return false;

            return this.id.Equals(that.id)
                && this.Duration.Equals(that.Duration)
                && this.FirstWarningTime.Equals(that.FirstWarningTime)
                && this.SecondWarningTime.Equals(that.SecondWarningTime);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
