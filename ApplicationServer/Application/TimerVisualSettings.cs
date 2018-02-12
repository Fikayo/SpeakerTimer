namespace ChurchTimer.Application
{
    using System.Drawing;

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
            Color messageColor)
        {
            this.id = visualId;
            this.CounterMode = counterMode;
            this.DisplayMode = displayMode;
            this.TimerFont = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TimerColor = timerColor;
            this.RunningColor = runningColor;
            this.PausedColor = pausedColor;
            this.WarningColor = warningColor;
            this.SecondWarningColor = secondWarningColor;
            this.ExpiredColor = expiredColor;
            this.StoppedColor = stoppedColor;
            this.BackgroundColor = backgroundColor;
            this.MessageColor = messageColor;
        }

        public TimerVisualSettings(int visualId, TimerVisualSettings copy):
            this (
                visualId, 
                copy.CounterMode, 
                copy.DisplayMode, 
                copy.TimerFont.FontFamily.Name, 
                copy.TimerFont.Size, 
                copy.TimerColor, 
                copy.RunningColor, 
                copy.PausedColor, 
                copy.WarningColor, 
                copy.SecondWarningColor, 
                copy.ExpiredColor, 
                copy.StoppedColor, 
                copy.BackgroundColor, 
                copy.MessageColor
                )
        {
        }

        private TimerVisualSettings() :
            this(
                -1,
                TimerCounterMode.CountDownToMinus,
                TimerDisplayMode.FullWidth,
                "Arial", 
                250f,
                Color.White,
                Color.White,
                Color.Cyan,
                Color.Yellow,
                Color.FromName("ffff8000") /* Basically Orange */,
                Color.Red,
                Color.Silver,
                Color.Black,
                Color.Red
                )
        {
        }

        public int VisualId { get { return this.id; } }

        #region Display Settings

        public Font TimerFont { get; set; }

        public TimerCounterMode CounterMode { get; set; }

        public TimerDisplayMode DisplayMode { get; set; }

        #endregion

        #region Colors

        public Color TimerColor { get; set; }

        public Color RunningColor { get; set; }

        public Color PausedColor { get; set; }

        public Color WarningColor { get; set; }

        public Color SecondWarningColor { get; set; }

        public Color StoppedColor { get; set; }

        public Color ExpiredColor { get; set; }

        public Color BackgroundColor { get; set; }

        public Color MessageColor { get; set; }

        #endregion

        public static TimerVisualSettings Default
        {
            get { return new TimerVisualSettings(); }
        }

        public void SetFont(string fontFamily = "", float fontSize = 0f)
        {
            fontSize = fontSize <= 0 ? this.TimerFont.Size : fontSize;

            if (string.IsNullOrEmpty(fontFamily))
            {
                this.TimerFont = new Font(this.TimerFont.FontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            else
            {
                this.TimerFont = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                this.TimerFont.FontFamily.Name,
                this.TimerFont.Size,
                this.CounterMode,
                this.DisplayMode,
                this.TimerColor.Name,
                this.RunningColor.Name,
                this.PausedColor.Name,
                this.WarningColor.Name,
                this.StoppedColor.Name,
                this.ExpiredColor.Name,
                this.BackgroundColor.Name,
                this.MessageColor.Name,
                this.SecondWarningColor.Name);
        }

        public TimerVisualSettings Clone()
        {
            return new TimerVisualSettings(this.VisualId, this);
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
                && this.TimerFont.FontFamily.Name.Equals(that.TimerFont.FontFamily.Name)
                && this.TimerFont.Size.Equals(that.TimerFont.Size)
                && this.CounterMode.Equals(that.CounterMode)
                && this.DisplayMode.Equals(that.DisplayMode)
                && this.TimerColor.Equals(that.TimerColor)
                && this.RunningColor.Equals(that.RunningColor)
                && this.PausedColor.Equals(that.PausedColor)
                && this.WarningColor.Equals(that.WarningColor)
                && this.StoppedColor.Equals(that.StoppedColor)
                && this.ExpiredColor.Equals(that.ExpiredColor)
                && this.BackgroundColor.Equals(that.BackgroundColor)
                && this.MessageColor.Equals(that.MessageColor)
                && this.SecondWarningColor.Equals(that.SecondWarningColor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void SetDefaultSettings()
        {
            this.CounterMode = TimerCounterMode.CountDownToMinus;
            this.DisplayMode = TimerDisplayMode.FullWidth;
            this.SetFont("Arial", 250f);

            this.TimerColor = Color.White;
            this.RunningColor = Color.White;
            this.PausedColor = Color.Cyan;
            this.WarningColor = Color.Yellow;
            this.SecondWarningColor = Color.Orange;
            this.ExpiredColor = Color.Red;
            this.StoppedColor = Color.Silver;
            this.BackgroundColor = Color.Black;
            this.MessageColor = Color.Red;
        }

        public static TimerVisualSettings ParseCsv(string csv, int start = 0)
        {
            TimerVisualSettings settings = TimerVisualSettings.Default;

            try
            {
                var values = csv.Split(new char[] { ',' });

                var fontFamily = values[start + 0];
                var fontSize = float.Parse(values[start + 1]);
                settings.SetFont(fontFamily, fontSize);

                settings.CounterMode = Util.ToEnum<TimerCounterMode>(values[start + 2]);
                settings.DisplayMode = Util.ToEnum<TimerDisplayMode>(values[start + 3]);
                settings.TimerColor = Util.FromARGBString(Color.FromName(values[start + 4]));
                settings.RunningColor = Util.FromARGBString(Color.FromName(values[start + 5]));
                settings.PausedColor = Util.FromARGBString(Color.FromName(values[start + 6]));
                settings.WarningColor = Util.FromARGBString(Color.FromName(values[start + 7]));
                settings.StoppedColor = Util.FromARGBString(Color.FromName(values[start + 8]));
                settings.ExpiredColor = Util.FromARGBString(Color.FromName(values[start + 9]));
                settings.BackgroundColor = Util.FromARGBString(Color.FromName(values[start + 10]));
                settings.MessageColor = Util.FromARGBString(Color.FromName(values[start + 11]));
                settings.SecondWarningColor = Util.FromARGBString(Color.FromName(values[start + 12]));

                return settings;
            }
            catch
            {
                return settings;
            }
        }

        public enum TimerCounterMode
        {
            CountDownToMinus, CountDownToZero, CountUp
        }

        public enum TimerDisplayMode
        {
            FullWidth, SuppressLeadingZeros, DisplayInSeconds
        }
    }

}
