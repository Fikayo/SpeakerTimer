namespace SpeakerTimer.Data.Settings
{
    using System.Text;
    using System.Data.SQLite;

    public class TimerDurationModel : DataModel
    {
        public static readonly DbColumn TimerIdCol = new DbColumn("TimerId", "INTEGER");
        public static readonly DbColumn DurationIdCol = new DbColumn("DurationId", "INTEGER");

        public const string TableName = "Timer Durations";

        private static readonly TimerDurationModel instance = null;

        static TimerDurationModel()
        {
            instance = new TimerDurationModel();
        }

        private TimerDurationModel() : base(TableName)
        {
        }

        public static TimerDurationModel Instance
        {
            get { return instance; }
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("{0} NOT NULL, ", TimerDurationModel.TimerIdCol);
            tableColumns.AppendFormat("{0} NOT NULL, ", TimerDurationModel.DurationIdCol);
            tableColumns.AppendFormat("UNIQUE([{0}], [{1}]) ON CONFLICT IGNORE, ", TimerDurationModel.TimerIdCol.Name, TimerDurationModel.DurationIdCol.Name);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]) ON DELETE CASCADE, ", TimerDurationModel.TimerIdCol.Name, TimerSettingsModel.TableName, TimerSettingsModel.IdCol.Name);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]) ON DELETE CASCADE", TimerDurationModel.DurationIdCol.Name, DurationSettingsModel.TableName, DurationSettingsModel.IdCol.Name);

            base.CreateTable(tableColumns.ToString());
        }

        public void Insert(int timerId, int durationid)
        {
            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter(TimerIdCol.ParameterName, timerId),
                new SQLiteParameter(DurationIdCol.ParameterName, durationid),
            };

            var sql = "INSERT OR REPLACE INTO [" + TableName + "] VALUES (" +
                "@" + TimerIdCol.ParameterName + ", " +
                "@" + DurationIdCol.ParameterName + ");";

            this.ExecuteNonQuery(sql, parameters);
        }
    }
}