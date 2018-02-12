namespace ChurchTimer.Data.Settings
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Drawing;
    using ChurchTimer.Application;

    public class VisualSettingsModel : DataModel
    {
        public static readonly DbColumn IdCol = new DbColumn("VisualId", "INTEGER");
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
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Arial', ", TimerFontFamilyCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 250, ", TimerFontSizeCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'CountDownToMinus', ", CounterModeCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'FullWidth', ", DisplayModeCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'White', ", TimerColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'White', ", RunningColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Cyan', ", PausedColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Yellow', ", WarningColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Orange', ", SecondWarningColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Silver', ", StoppedColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Red', ", ExpiredColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Black', ", BackgroundColorCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 'Red'", MessageColorCol);

            base.CreateTable(tableColumns.ToString());
        }

        public TimerVisualSettings Save(TimerVisualSettings timerVisual)
        {
            var parameters = new List<SQLiteParameter>
            {
                    new SQLiteParameter() { ParameterName = TimerFontFamilyCol.ParameterName , Value = timerVisual.TimerFont.FontFamily},
                    new SQLiteParameter() { ParameterName = TimerFontSizeCol.ParameterName , Value = timerVisual.TimerFont.Size},
                    new SQLiteParameter() { ParameterName = CounterModeCol.ParameterName , Value = timerVisual.CounterMode},
                    new SQLiteParameter() { ParameterName = DisplayModeCol.ParameterName , Value = timerVisual.DisplayMode},
                    new SQLiteParameter() { ParameterName = TimerColorCol.ParameterName , Value = timerVisual.TimerColor.Name},
                    new SQLiteParameter() { ParameterName = RunningColorCol.ParameterName , Value = timerVisual.RunningColor.Name},
                    new SQLiteParameter() { ParameterName = PausedColorCol.ParameterName , Value = timerVisual.PausedColor.Name},
                    new SQLiteParameter() { ParameterName = WarningColorCol.ParameterName , Value = timerVisual.WarningColor.Name},
                    new SQLiteParameter() { ParameterName = SecondWarningColorCol.ParameterName , Value = timerVisual.SecondWarningColor.Name},
                    new SQLiteParameter() { ParameterName = StoppedColorCol.ParameterName , Value = timerVisual.StoppedColor.Name},
                    new SQLiteParameter() { ParameterName = ExpiredColorCol.ParameterName , Value = timerVisual.ExpiredColor.Name},
                    new SQLiteParameter() { ParameterName = BackgroundColorCol.ParameterName , Value = timerVisual.BackgroundColor.Name},
                    new SQLiteParameter() { ParameterName = MessageColorCol.ParameterName , Value = timerVisual.MessageColor.Name},
            };

            if (timerVisual.VisualId < 0)
            {
                var sql = "INSERT INTO [" + TableName + "] (" +
                    "[" + TimerFontFamilyCol.Name + "], " +
                    "[" + TimerFontSizeCol.Name + "], " +
                    "[" + CounterModeCol.Name + "], " +
                    "[" + DisplayModeCol.Name + "], " +
                    "[" + TimerColorCol.Name + "], " +
                    "[" + RunningColorCol.Name + "], " +
                    "[" + PausedColorCol.Name + "], " +
                    "[" + WarningColorCol.Name + "], " +
                    "[" + SecondWarningColorCol.Name + "], " +
                    "[" + StoppedColorCol.Name + "], " +
                    "[" + ExpiredColorCol.Name + "], " +
                    "[" + BackgroundColorCol.Name + "], " +
                    "[" + MessageColorCol.Name + "]" +
                    ") VALUES (" +
                    "@" + TimerFontFamilyCol.ParameterName + ", " +
                    "@" + TimerFontSizeCol.ParameterName + ", " +
                    "@" + CounterModeCol.ParameterName + ", " +
                    "@" + DisplayModeCol.ParameterName + ", " +
                    "@" + TimerColorCol.ParameterName + ", " +
                    "@" + RunningColorCol.ParameterName + ", " +
                    "@" + PausedColorCol.ParameterName + ", " +
                    "@" + WarningColorCol.ParameterName + ", " +
                    "@" + SecondWarningColorCol.ParameterName + ", " +
                    "@" + StoppedColorCol.ParameterName + ", " +
                    "@" + ExpiredColorCol.ParameterName + ", " +
                    "@" + BackgroundColorCol.ParameterName + ", " +
                    "@" + MessageColorCol.ParameterName + ");";

                var newId = (int)this.Insert(sql, parameters.ToArray());
                return new TimerVisualSettings(newId, timerVisual);
            }

            var update = "UPDATE [" + TableName + "] SET " +
                "[" + TimerFontFamilyCol.Name + "] = @" + TimerFontFamilyCol.ParameterName + "," +
                "[" + TimerFontSizeCol.Name + "] = @" + TimerFontSizeCol.ParameterName + "," +
                "[" + CounterModeCol.Name + "] = @" + CounterModeCol.ParameterName + "," +
                "[" + DisplayModeCol.Name + "] = @" + DisplayModeCol.ParameterName + "," +
                "[" + TimerColorCol.Name + "] = @" + TimerColorCol.ParameterName + "," +
                "[" + RunningColorCol.Name + "] = @" + RunningColorCol.ParameterName + "," +
                "[" + PausedColorCol.Name + "] = @" + PausedColorCol.ParameterName + "," +
                "[" + WarningColorCol.Name + "] = @" + WarningColorCol.ParameterName + "," +
                "[" + SecondWarningColorCol.Name + "] = @" + SecondWarningColorCol.ParameterName + "," +
                "[" + StoppedColorCol.Name + "] = @" + StoppedColorCol.ParameterName + "," +
                "[" + ExpiredColorCol.Name + "] = @" + ExpiredColorCol.ParameterName + "," +
                "[" + BackgroundColorCol.Name + "] = @" + BackgroundColorCol.ParameterName + "," +
                "[" + MessageColorCol.Name + "] = @" + MessageColorCol.ParameterName + " " + 
                "WHERE [" + IdCol.Name + "] = @" + IdCol.ParameterName + ";";

            parameters.Add(new SQLiteParameter(IdCol.ParameterName, timerVisual.VisualId));
            this.ExecuteNonQuery(update, parameters.ToArray());
            return timerVisual;
        }

        public static TimerVisualSettings Parse(SQLiteDataReader reader)
        {
            var id = Convert.ToInt32(reader[IdCol.Name]);
            var fontFamily = Convert.ToString(reader[TimerFontFamilyCol.Name]);
            var fontSize = Convert.ToSingle(reader[TimerFontSizeCol.Name]);
            var counterMode = Util.ToEnum<TimerVisualSettings.TimerCounterMode>(Convert.ToString(reader[CounterModeCol.Name]));
            var displayMode = Util.ToEnum<TimerVisualSettings.TimerDisplayMode>(Convert.ToString(reader[DisplayModeCol.Name]));
            var timerColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[TimerColorCol.Name])));
            var runningColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[RunningColorCol.Name])));
            var pausedColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[PausedColorCol.Name])));
            var warningColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[WarningColorCol.Name])));
            var warning2Color = Util.FromARGBString(Color.FromName(Convert.ToString(reader[SecondWarningColorCol.Name])));
            var stoppedColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[StoppedColorCol.Name])));
            var expiredColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[ExpiredColorCol.Name])));
            var backgroundColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[BackgroundColorCol.Name])));
            var messageColor = Util.FromARGBString(Color.FromName(Convert.ToString(reader[MessageColorCol.Name])));

            return new TimerVisualSettings(id, counterMode, displayMode, fontFamily, fontSize, timerColor, runningColor, pausedColor, warningColor, warning2Color, expiredColor, stoppedColor, backgroundColor, messageColor);
        }
    }
}