namespace SpeakerTimer.Data.Settings
{
    using System.Text;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Drawing;
    using SpeakerTimer.Application;

    public class VisualSettingsModel : DataModel
    {
        public static readonly DbColumn IdCol = new DbColumn("Id", "INTEGER");
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

        private static readonly VisualSettingsModel instance = null;

        static VisualSettingsModel()
        {
            instance = new VisualSettingsModel();
        }

        private VisualSettingsModel() : base(TableName)
        {
        }

        public static VisualSettingsModel Instance
        {
            get { return instance; }
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("{0} PRIMARY KEY AUTOINCREMENT, ", IdCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Arial', ", TimerFontFamilyCol);
            tableColumns.AppendFormat("{0} DEFAULT 250, ", TimerFontSizeCol);
            tableColumns.AppendFormat("{0} DEFAULT 'CountDownToMinus', ", CounterModeCol);
            tableColumns.AppendFormat("{0} DEFAULT 'FullWidth', ", DisplayModeCol);
            tableColumns.AppendFormat("{0} DEFAULT 'White', ", TimerColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'White', ", RunningColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Cyan', ", PausedColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Yellow', ", WarningColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Orange', ", SecondWarningColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Silver', ", StoppedColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Red', ", ExpiredColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Black', ", BackgroundColorCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Red'", MessageColorCol);

            base.CreateTable(tableColumns.ToString());
        }
        
        public TimerVisualSettings Save(TimerVisualSettings timerVisual)
        {
            var parameters = new List<SQLiteParameter>
            {
                    new SQLiteParameter() { ParameterName = "TimerFontFamily", Value = timerVisual.TimerFont.FontFamily},
                    new SQLiteParameter() { ParameterName = "TimerFontSize", Value = timerVisual.TimerFont.Size},
                    new SQLiteParameter() { ParameterName = "CounterMode", Value = timerVisual.CounterMode},
                    new SQLiteParameter() { ParameterName = "DisplayMode", Value = timerVisual.DisplayMode},
                    new SQLiteParameter() { ParameterName = "TimerColor", Value = timerVisual.TimerColor},
                    new SQLiteParameter() { ParameterName = "RunningColor", Value = timerVisual.RunningColor},
                    new SQLiteParameter() { ParameterName = "PausedColor", Value = timerVisual.PausedColor},
                    new SQLiteParameter() { ParameterName = "WarningColor", Value = timerVisual.WarningColor},
                    new SQLiteParameter() { ParameterName = "SecondWarningColor", Value = timerVisual.SecondWarningColor},
                    new SQLiteParameter() { ParameterName = "StoppedColor", Value = timerVisual.StoppedColor},
                    new SQLiteParameter() { ParameterName = "ExpiredColor", Value = timerVisual.ExpiredColor},
                    new SQLiteParameter() { ParameterName = "BackgroundColor", Value = timerVisual.BackgroundColor},
                    new SQLiteParameter() { ParameterName = "MessageColor", Value = timerVisual.MessageColor},
            };

            if (timerVisual.VisualId < 0)
            {
                var sql = "INSERT INTO [" + TableName + "]";
                var newId = this.Insert(sql, parameters.ToArray());
                return new TimerVisualSettings(newId, timerVisual);
            }

            var update = "UPDATE [" + TableName + "] SET " +
                "[" + TimerFontFamilyCol + "] = @TimerFontFamily," +
                "[" + TimerFontSizeCol + "] = @TimerFontSize," +
                "[" + CounterModeCol + "] = @CounterMode," +
                "[" + DisplayModeCol + "] = @DisplayMode," +
                "[" + TimerColorCol + "] = @TimerColor," +
                "[" + RunningColorCol + "] = @RunningColor," +
                "[" + PausedColorCol + "] = @PausedColor," +
                "[" + WarningColorCol + "] = @WarningColor," +
                "[" + SecondWarningColorCol + "] = @SecondWarningColor," +
                "[" + StoppedColorCol + "] = @StoppedColor," +
                "[" + ExpiredColorCol + "] = @ExpiredColor," +
                "[" + BackgroundColorCol + "] = @BackgroundColor," +
                "[" + MessageColorCol + "] = @MessageColor" +
                "WHERE [" + IdCol + "] = @VisualId";

            parameters.Add(new SQLiteParameter("VisualId", timerVisual.VisualId));
            this.ExecuteNonQuery(update, parameters.ToArray());
            return timerVisual;
        }

        public static TimerVisualSettings Parse(SQLiteDataReader reader)
        {
            var id = (int)reader[IdCol.Name];
            var fontFamily = (string)reader[TimerFontFamilyCol.Name];
            var fontSize = (float)reader[TimerFontSizeCol.Name];
            var counterMode = Util.ToEnum<TimerVisualSettings.TimerCounterMode>((string)reader[CounterModeCol.Name]);
            var displayMode = Util.ToEnum<TimerVisualSettings.TimerDisplayMode>((string)reader[DisplayModeCol.Name]);
            var timerColor = Util.FromARGBString(Color.FromName((string)reader[TimerColorCol.Name]));
            var runningColor = Util.FromARGBString(Color.FromName((string)reader[RunningColorCol.Name]));
            var pausedColor = Util.FromARGBString(Color.FromName((string)reader[PausedColorCol.Name]));
            var warningColor = Util.FromARGBString(Color.FromName((string)reader[WarningColorCol.Name]));
            var warning2Color = Util.FromARGBString(Color.FromName((string)reader[SecondWarningColorCol.Name]));
            var stoppedColor = Util.FromARGBString(Color.FromName((string)reader[StoppedColorCol.Name]));
            var expiredColor = Util.FromARGBString(Color.FromName((string)reader[ExpiredColorCol.Name]));
            var backgroundColor = Util.FromARGBString(Color.FromName((string)reader[BackgroundColorCol.Name]));
            var messageColor = Util.FromARGBString(Color.FromName((string)reader[MessageColorCol.Name]));

            return new TimerVisualSettings(id, counterMode, displayMode, fontFamily, fontSize, timerColor, runningColor, pausedColor, warningColor, warning2Color, expiredColor, stoppedColor, backgroundColor, messageColor);
        }
    }
}