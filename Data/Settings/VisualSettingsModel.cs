namespace SpeakerTimer.Data.Settings
{
    using System.Text;
    using System.Data.SQLite;
    using System.Drawing;
    using SpeakerTimer.Application;

    public class VisualSettingsModel : DataModel
    {
        public static readonly DbColumn IdCol = new DbColumn("Id", "INT");
        public static readonly DbColumn TimerFontFamilyCol = new DbColumn("TimerFontFamily", "VARCHAR(255)");
        public static readonly DbColumn TimerFontSizeCol = new DbColumn("TimerFontSize", "REAL");
        public static readonly DbColumn CounterModeCol = new DbColumn("CounterMode", "VARCHAR(50)");
        public static readonly DbColumn DisplayModeCol = new DbColumn("DisplayMode", "VARCHAR(50)");
        public static readonly DbColumn TimerColorCol = new DbColumn("TimerColor", "VARCHAR(50)");
        public static readonly DbColumn RunningColorCol = new DbColumn("RunningColor", "VARCHAR(50)");
        public static readonly DbColumn PausedColorCol = new DbColumn("PausedColor", "VARCHAR(50)");
        public static readonly DbColumn WarningColorCol = new DbColumn("WarningColor", "VARCHAR(50)");
        public static readonly DbColumn SecondWarningColorCol = new DbColumn("SecondWarningColor", "VARCHAR(50)");
        public static readonly DbColumn StoppedColorCol = new DbColumn("StoppedColor", "VARCHAR(50)");
        public static readonly DbColumn ExpiredColorCol = new DbColumn("ExpiredColor", "VARCHAR(50)");
        public static readonly DbColumn BackgroundColorCol = new DbColumn("BackgroundColor", "VARCHAR(50)");
        public static readonly DbColumn MessageColorCol = new DbColumn("MessageColor", "VARCHAR(50)");
               
        public const string TableName = "Visual Settings";

        public VisualSettingsModel() : base(TableName)
        {
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("[{0}] PRIMARY KEY AUTOINCREMENT, ", IdCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Arial', ", TimerFontFamilyCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 250, ", TimerFontSizeCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'CountDownToMinus', ", CounterModeCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'FullWidth', ", DisplayModeCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'White', ", TimerColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'White', ", RunningColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Cyan', ", PausedColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Yellow', ", WarningColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Orange', ", SecondWarningColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Silver', ", StoppedColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Red', ", ExpiredColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Black', ", BackgroundColorCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Red'", MessageColorCol);

            base.CreateTable(tableColumns.ToString());
        }

        public static TimerVisualSettings Parse(SQLiteDataReader reader)
        {
            var fontFamily = (string)reader[TimerFontFamilyCol.Name];
            var fontSize = (float)reader[TimerFontSizeCol.Name];
            var counterMode = Util.ToEnum<TimerVisualSettings.TimerCounterMode>((string)reader[CounterModeCol.Name]);
            var displayMode = Util.ToEnum<TimerVisualSettings.TimerDisplayMode>((string)reader[DisplayModeCol.Name]);
            var timerColor = Util.FromARGBString(Color.FromName((string)reader[TimerColorCol.Name]));
            var runningColor = Util.FromARGBString(Color.FromName((string)reader[RunningColorCol.Name]));
            var pausedColor = Util.FromARGBString(Color.FromName((string)reader[PausedColorCol.Name]));
            var warningColor = Util.FromARGBString(Color.FromName((string)reader[WarningColorCol.Name]));
            var warning2Coor = Util.FromARGBString(Color.FromName((string)reader[SecondWarningColorCol.Name]));
            var stoppedColor = Util.FromARGBString(Color.FromName((string)reader[StoppedColorCol.Name]));
            var expiredColor = Util.FromARGBString(Color.FromName((string)reader[ExpiredColorCol.Name]));
            var backgroundColor = Util.FromARGBString(Color.FromName((string)reader[BackgroundColorCol.Name]));
            var messageColor = Util.FromARGBString(Color.FromName((string)reader[MessageColorCol.Name]));

            return new TimerVisualSettings(counterMode, displayMode, fontFamily, fontSize, timerColor, runningColor, pausedColor, warningColor, warningColor, expiredColor, stoppedColor, backgroundColor, messageColor);
        }
    }
}