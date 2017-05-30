namespace SpeakerTimer.Data.Settings
{
    using System.Text;

    public class SimpleTimerModel : DataModel
    {
        public static readonly DbColumn TimerIdCol = new DbColumn("TimerId", "INT");
        public static readonly DbColumn DurationId = new DbColumn("DurationId", "INT");
        public static readonly DbColumn VisualId = new DbColumn("VisualId", "INT");

        public const string TableName = "Timers";

        public SimpleTimerModel() : base(TableName)
        {
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("[{0}] NOT NULL, ", TimerIdCol);
            tableColumns.AppendFormat("[{0}] NOT NULL, ", DurationId);
            tableColumns.AppendFormat("[{0}] NOT NULL, ", VisualId);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]), ", TimerIdCol, TimerSettingsModel.TableName, TimerSettingsModel.IdCol);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]), ", DurationId, DurationSettingsModel.TableName, DurationSettingsModel.IdCol);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}])", VisualId, VisualSettingsModel.TableName, VisualSettingsModel.IdCol);

            base.CreateTable(tableColumns.ToString());
        }
    }
}