namespace ChurchTimer.Data
{
    using System.Data.SQLite;

    public interface IWriteModel : IModel
    {
        void ExecuteNonQuery(string nonQuery, params SQLiteParameter[] parameters);

        void Flush();
    }
}
