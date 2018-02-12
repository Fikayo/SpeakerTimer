namespace ChurchTimer.Data
{
    using System.Data.SQLite;

   public interface IReadModel : IModel
    {
        SQLiteDataReader Query(string query, params SQLiteParameter[] parameters);
    }
}
