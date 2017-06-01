namespace SpeakerTimer.Data.Settings
{
    using System.Text;

    public class TimerDurationModel : DataModel
    {
        public static readonly DbColumn TimerIdCol = new DbColumn("TimerId", "INT");
        public static readonly DbColumn DurationId = new DbColumn("DurationId", "INT");

        public const string TableName = "Timers";

        public TimerDurationModel() : base(TableName)
        {
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("[{0}] NOT NULL, ", TimerIdCol);
            tableColumns.AppendFormat("[{0}] NOT NULL, ", DurationId);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]), ", TimerIdCol, TimerSettingsModel.TableName, TimerSettingsModel.IdCol);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}])", DurationId, DurationSettingsModel.TableName, DurationSettingsModel.IdCol);

            base.CreateTable(tableColumns.ToString());
        }
    }
}