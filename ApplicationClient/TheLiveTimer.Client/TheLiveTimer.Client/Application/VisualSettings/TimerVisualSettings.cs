namespace TheLiveTimer.Client
{
    using Xamarin.Forms;

    public class TimerVisualSettings
    {
        private readonly int id;

        public TimerVisualSettings(
            int visualId,
            TimerCounterMode counterMode,
            TimerDisplayMode displayMode,
            string fontFamily,
            float fontSize,
            Color timerColor,
            Color runningColor,
            Color pausedColor,
            Color warningColor,
            Color secondWarningColor,
            Color expiredColor,
            Color stoppedColor,
            Color backgroundColor,
            Color messageColor,
            bool showTimerTitle)
        {
            this.id = visualId;
            this.CounterMode = counterMode;
            this.DisplayMode = displayMode;
            this.TimerFontFamily = fontFamily;
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
                copy.TimerFontFamily,
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
                Color.White,
                Color.White,
                Color.Cyan,
                Color.Yellow,
                Color.Orange,
                Color.Red,
                Color.Silver,
                Color.Black,
                Color.Red,
                true
                )
        {
        }

        private TimerVisualSettings(int id) :
            this(
                id,
                TimerCounterMode.CountDownToMinus,
                TimerDisplayMode.FullWidth,
                "Arial",
                50f,
                Color.White,
                Color.White,
                Color.Cyan,
                Color.Yellow,
                Color.Orange,
                Color.Red,
                Color.Silver,
                Color.Black,
                Color.Red,
                true
                )
        {
        }

        public int VisualId { get { return this.id; } }

        public bool ShowTimerTitle { get; set; }

        #region Display Settings

        public string TimerFontFamily { get; set; }

        public float TimerFontSize { get; set; }

        public TimerCounterMode CounterMode { get; set; }

        public TimerDisplayMode DisplayMode { get; set; }

        #endregion

        #region Colors

        public Color TimerColor { get; set; }

        public Color RunningColor { get; set; }

        public Color PausedColor { get; set; }

        public Color FirstWarningColor { get; set; }

        public Color SecondWarningColor { get; set; }

        public Color StoppedColor { get; set; }

        public Color ExpiredColor { get; set; }

        public Color BackgroundColor { get; set; }

        public Color MessageColor { get; set; }

        #endregion

        public string ToTransportString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                this.VisualId,
                this.TimerFontFamily.ToString(),
                this.TimerFontSize,
                (int)this.CounterMode,
                (int)this.DisplayMode,
                Color2Hex(this.TimerColor),
                Color2Hex(this.RunningColor),
                Color2Hex(this.PausedColor),
                Color2Hex(this.FirstWarningColor),
                Color2Hex(this.SecondWarningColor),
                Color2Hex(this.StoppedColor),
                Color2Hex(this.ExpiredColor),
                Color2Hex(this.BackgroundColor),
                Color2Hex(this.MessageColor)
               );
        }

        public static TimerVisualSettings ParseTransportString(string transString)
        {
            var values = transString.Split(new char[] { ',' });

            TimerVisualSettings settings = new TimerVisualSettings(int.Parse(values[0]));

            settings.TimerFontFamily = values[1];
            //settings.TimerFontSize = float.Parse(values[2]);
            settings.CounterMode = (TimerCounterMode)int.Parse(values[3]);
            settings.DisplayMode = (TimerDisplayMode)int.Parse(values[4]);
            settings.TimerColor = Color.FromHex(values[5]);
            settings.RunningColor = Color.FromHex(values[6]);
            settings.PausedColor = Color.FromHex(values[7]);
            settings.FirstWarningColor = Color.FromHex(values[8]);
            settings.SecondWarningColor = Color.FromHex(values[9]);
            settings.StoppedColor = Color.FromHex(values[10]);
            settings.ExpiredColor = Color.FromHex(values[11]);
            settings.BackgroundColor = Color.FromHex(values[12]);
            settings.MessageColor = Color.FromHex(values[13]);

            System.Console.WriteLine("\n----- Trans string: {0}\n--------", transString);
            System.Console.WriteLine("Background color: {0}; String hex: {1}", settings.BackgroundColor, values[10]);

            return settings;
        }

        private static string Color2Hex(Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var alpha = (int)(color.A * 255);
            var hex = $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";

            return hex;
        }

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
