namespace ChurchTimer.Application.Settings
{
    using System.Windows.Media;

    public class TimerVisualSettings
    {
        private readonly int id;

        public TimerVisualSettings(
            int visualId,
            TimerCounterMode counterMode,
            TimerDisplayMode displayMode,
            string fontFamily,
            float fontSize,
            Brush timerColor,
            Brush runningColor,
            Brush pausedColor,
            Brush warningColor,
            Brush secondWarningColor,
            Brush expiredColor,
            Brush stoppedColor,
            Brush backgroundColor,
            Brush messageColor,
            bool showTimerTitle)
        {
            this.id = visualId;
            this.CounterMode = counterMode;
            this.DisplayMode = displayMode;
            this.TimerFontFamily = new FontFamily(fontFamily);
            this.TimerFontSize = fontSize;
            this.TimerColor = timerColor;
            this.RunningColor = runningColor;
            this.PausedColor = pausedColor;
            this.FirstWarningColor = warningColor;
            this.SecondWarningColor = secondWarningColor;
            this.ExpiredColor = expiredColor;
            this.StoppedColor = stoppedColor;
            this.BackgroundColor = backgroundColor;
            this.MessageColor = messageColor;
            this.ShowTimerTitle = showTimerTitle;
        }

        public TimerVisualSettings(int visualId, TimerVisualSettings copy) :
            this(
                visualId,
                copy.CounterMode,
                copy.DisplayMode,
                copy.TimerFontFamily.ToString(),
                copy.TimerFontSize,
                copy.TimerColor,
                copy.RunningColor,
                copy.PausedColor,
                copy.FirstWarningColor,
                copy.SecondWarningColor,
                copy.ExpiredColor,
                copy.StoppedColor,
                copy.BackgroundColor,
                copy.MessageColor,
                copy.ShowTimerTitle
                )
        {
        }

        public TimerVisualSettings() :
            this(
                -1,
                TimerCounterMode.CountDownToMinus,
                TimerDisplayMode.FullWidth,
                "Arial",
                50f,
                Brushes.White,
                Brushes.White,
                Brushes.Cyan,
                Brushes.Yellow,
                Brushes.Orange,
                Brushes.Red,
                Brushes.Silver,
                Brushes.Black,
                Brushes.Red,
                true
                )
        {
        }

        public int VisualId { get { return this.id; } }

        public bool ShowTimerTitle { get; set; }

        #region Display Settings

        public FontFamily TimerFontFamily { get; set; }

        public float TimerFontSize { get; set; }

        public TimerCounterMode CounterMode { get; set; }

        public TimerDisplayMode DisplayMode { get; set; }

        #endregion

        #region Colors

        public Brush TimerColor { get; set; }

        public Brush RunningColor { get; set; }

        public Brush PausedColor { get; set; }

        public Brush FirstWarningColor { get; set; }

        public Brush SecondWarningColor { get; set; }

        public Brush StoppedColor { get; set; }

        public Brush ExpiredColor { get; set; }

        public Brush BackgroundColor { get; set; }

        public Brush MessageColor { get; set; }

        #endregion

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

            TimerVisualSettings that = obj as TimerVisualSettings;
            if (that == null) return false;

            return this.id.Equals(that.id)
                && this.TimerFontFamily.Equals(that.TimerFontFamily)
                && this.TimerFontSize.Equals(that.TimerFontSize)
                && this.CounterMode.Equals(that.CounterMode)
                && this.DisplayMode.Equals(that.DisplayMode)
                && this.TimerColor.Equals(that.TimerColor)
                && this.RunningColor.Equals(that.RunningColor)
                && this.PausedColor.Equals(that.PausedColor)
                && this.FirstWarningColor.Equals(that.FirstWarningColor)
                && this.StoppedColor.Equals(that.StoppedColor)
                && this.ExpiredColor.Equals(that.ExpiredColor)
                && this.BackgroundColor.Equals(that.BackgroundColor)
                && this.MessageColor.Equals(that.MessageColor)
                && this.SecondWarningColor.Equals(that.SecondWarningColor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 21;
        }

    }

}
