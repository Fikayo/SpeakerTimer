namespace ChurchTimer.Data.Settings
{
    using System.Text;
    using System.Data.SQLite;

    public class TimerVisualModel : DataModel
    {
        public static readonly DbColumn TimerIdCol = new DbColumn("TimerId", "INTEGER");
        public static readonly DbColumn VisualIdCol = new DbColumn("VisualId", "INTEGER");

        public const string TableName = "Timer Visuals";

        private static readonly TimerVisualModel instance = null;

        static TimerVisualModel()
        {
            instance = new TimerVisualModel();
        }

        private TimerVisualModel() : base(TableName)
        {
        }

        public static TimerVisualModel Instance
        {
            get { return instance; }
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("{0} NOT NULL, ", TimerVisualModel.TimerIdCol);
            tableColumns.AppendFormat("{0} NOT NULL, ", TimerVisualModel.VisualIdCol);
            tableColumns.AppendFormat("UNIQUE([{0}], [{1}]) ON CONFLICT IGNORE, ", TimerIdCol.Name, VisualIdCol.Name);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]) ON DELETE CASCADE, ", TimerVisualModel.TimerIdCol.Name, TimerSettingsModel.TableName, TimerSettingsModel.IdCol.Name);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]) ON DELETE CASCADE", TimerVisualModel.VisualIdCol.Name, VisualSettingsModel.TableName, VisualSettingsModel.IdCol.Name);

            base.CreateTable(tableColumns.ToString());
        }

        public void Insert(int timerId, int visualId)
        {
            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter(TimerIdCol.ParameterName, timerId),
                new SQLiteParameter(VisualIdCol.ParameterName, visualId),
            };

            var sql = "INSERT OR REPLACE INTO [" + TableName + "] VALUES (" +
                "@" + TimerIdCol.ParameterName + ", " +
                "@" + VisualIdCol.ParameterName + ");";

            this.ExecuteNonQuery(sql, parameters);
        }
    }
}