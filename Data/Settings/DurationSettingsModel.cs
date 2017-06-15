namespace SpeakerTimer.Data.Settings
{
    using System.Text;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using SpeakerTimer.Application;

    public class DurationSettingsModel : DataModel
    {
        public static readonly DbColumn IdCol = new DbColumn("Id", "INTEGER");
        public static readonly DbColumn TitleCol = new DbColumn("Title", "VARCHAR(255)");
        public static readonly DbColumn DurationCol = new DbColumn("Duration", "REAL");
        public static readonly DbColumn Warning1Col = new DbColumn("Warning1", "REAL");
        public static readonly DbColumn Warning2Col = new DbColumn("Warning2", "REAL");

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
            tableColumns.AppendFormat("{0} DEFAULT 0, ", DurationCol);
            tableColumns.AppendFormat("{0} DEFAULT 0, ", Warning1Col);
            tableColumns.AppendFormat("{0} DEFAULT 0", Warning2Col);

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
                    new SQLiteParameter() { Value = timerDuration.Title },
                    new SQLiteParameter() { Value = timerDuration.Duration },
                    new SQLiteParameter() { Value = timerDuration.WarningTime },
                    new SQLiteParameter() { Value = timerDuration.SecondWarningTime }
            };

            if (timerDuration.DurationId < 0)
            {
                var sql = "INSERT INTO [" + TableName + "] VALUES (?, ?, ?, ?)";
                var newId = this.Insert(sql, parameters.ToArray());
                return new TimerDurationSettings(newId, timerDuration);
            }

            var update = "UPDATE [" + TableName + "] SET " +
                "[" + TitleCol + "] = ?," +
                "[" + DurationCol + "] = ?," +
                "[" + Warning1Col + "] = ?," +
                "[" + Warning2Col + "] = ?" +
                "WHERE [" + IdCol + "] = ?";

            parameters.Add(new SQLiteParameter() { Value = timerDuration.DurationId });
            this.ExecuteNonQuery(update, parameters.ToArray());
            return timerDuration;
        }

        public static TimerDurationSettings Parse(SQLiteDataReader reader)
        {
            TimerDurationSettings setting = TimerDurationSettings.Default;
            setting.Title = (string)reader[TitleCol.Name];
            setting.Duration = (double)reader[DurationCol.Name];
            setting.WarningTime = (double)reader[Warning1Col.Name];
            setting.SecondWarningTime = (double)reader[Warning2Col.Name];

            return setting;
        }
    }
}
