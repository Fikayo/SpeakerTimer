namespace SpeakerTimer.Data.Settings
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using SpeakerTimer.Application;

    public class DurationSettingsModel : DataModel
    {
        public static readonly DbColumn IdCol = new DbColumn("DurationId", "INTEGER");
        public static readonly DbColumn TitleCol = new DbColumn("Title", "VARCHAR(255)", "Title");
        public static readonly DbColumn DurationCol = new DbColumn("Duration", "REAL", "Duration");
        public static readonly DbColumn Warning1Col = new DbColumn("Warning1", "REAL", "Warning");
        public static readonly DbColumn Warning2Col = new DbColumn("Warning2", "REAL", "SecondWarning");

        public const string TableName = "Duration Settings";

        private static readonly DurationSettingsModel instance = null;

        static DurationSettingsModel()
        {
            instance = new DurationSettingsModel();
        }

        private DurationSettingsModel() : base(TableName)
        {
        }

        public static DurationSettingsModel Instance
        {
            get { return instance; }
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("{0} PRIMARY KEY AUTOINCREMENT, ", IdCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Untitled', ", TitleCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 0, ", DurationCol);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 0, ", Warning1Col);
            tableColumns.AppendFormat("{0} NOT NULL DEFAULT 0", Warning2Col);

            base.CreateTable(tableColumns.ToString());
        }

        public List<TimerDurationSettings> FetchAll()
        {
            var durationSettings = new List<TimerDurationSettings>();

            var reader = this.Select();
            while (reader.Read())
            {
                var setting = DurationSettingsModel.Parse(reader);
                durationSettings.Add(setting);
            }

            return durationSettings;
        }

        public TimerDurationSettings Save(TimerDurationSettings timerDuration)
        {
            var parameters = new List<SQLiteParameter>
            {
                    new SQLiteParameter() { ParameterName = TitleCol.ParameterName, Value = timerDuration.Title },
                    new SQLiteParameter() { ParameterName = DurationCol.ParameterName, Value = timerDuration.Duration },
                    new SQLiteParameter() { ParameterName = Warning1Col.ParameterName, Value = timerDuration.WarningTime },
                    new SQLiteParameter() { ParameterName = Warning2Col.ParameterName, Value = timerDuration.SecondWarningTime }
            };

            if (timerDuration.DurationId < 0)
            {
                var sql = "INSERT INTO [" + TableName + "](" +
                    "[" + TitleCol.Name + "], " +
                    "[" + DurationCol.Name + "], " +
                    "[" + Warning1Col.Name + "], " +
                    "[" + Warning2Col.Name + "]" +
                    ") VALUES (" +
                    "@" + TitleCol.ParameterName + ", " +
                    "@" + DurationCol.ParameterName + ", " +
                    "@" + Warning1Col.ParameterName + ", " +
                    "@" + Warning2Col.ParameterName + ");";

                var newId = (int)this.Insert(sql, parameters.ToArray());
                return new TimerDurationSettings(newId, timerDuration);
            }

            var update = "UPDATE [" + TableName + "] SET " +
                "[" + TitleCol.Name + "] = @" + TitleCol.ParameterName + "," +
                "[" + DurationCol.Name + "] = @" + DurationCol.ParameterName + "," +
                "[" + Warning1Col.Name + "] = @" + Warning1Col.ParameterName + "," +
                "[" + Warning2Col.Name + "] = @" + Warning2Col.ParameterName + " " +
                "WHERE [" + IdCol.Name + "] = @" + IdCol.ParameterName + ";";

            parameters.Add(new SQLiteParameter() { ParameterName = IdCol.ParameterName, Value = timerDuration.DurationId });
            this.ExecuteNonQuery(update, parameters.ToArray());
            return timerDuration;
        }

        public static TimerDurationSettings Parse(SQLiteDataReader reader)
        {
            if(reader[DurationCol.Name] is DBNull)
            {
                int a = 5;
            }

            var id = Convert.ToInt32(reader[IdCol.Name]);
            var title = Convert.ToString(reader[TitleCol.Name]);
            var duration = Convert.ToDouble(reader[DurationCol.Name]);
            var warningTime = Convert.ToDouble(reader[Warning1Col.Name]);
            var secondWarningTime = Convert.ToDouble(reader[Warning2Col.Name]);

            return new TimerDurationSettings(id, title, duration, warningTime, secondWarningTime);
        }
    }
}
