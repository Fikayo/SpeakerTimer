namespace ChurchTimer.Data
{
    public interface IModel
    {
        void OpenConnection();

        void CreateTable();

        void CloseDatabase();
    }
}