namespace SpeakerTimer.Data
{
    public interface IModel
    {
        void CreateDb();

        void OpenConnection(string connectionString);

        void CreateTable();

        void CloseDb();
    }
}