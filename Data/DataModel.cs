namespace SpeakerTimer.Data
{
    using System;
    using System.Data.SQLite;

    public abstract class DataModel : IReadWrite
    {
        private readonly string tableName;
        private SQLiteConnection connection;

        public DataModel(string tableName)
        {
            this.tableName = tableName;
        }

        protected abstract DbColumn[] Columns { get; }

        public void OpenConnection(string connectionString)
        {
            if (this.connection == null)
            {
                this.connection = new SQLiteConnection(connectionString);
            }
            
            this.connection.Open();
        }

        public void CreateDb()
        {
            throw new NotImplementedException();
        }

        public void CreateTable()
        {
            var createString = "CREATE TABLE IF NOT EXISTS [" + this.tableName + "] (";

            DbColumn[] columns = this.Columns;
            foreach (var col in columns)
            {
                createString += " [" + col.Name + "] " + col.Type + ",";
            }

            createString = createString.Substring(0, createString.Length - 1); // Get rid of last comma
            createString += ");";

            this.ExecuteNonQuery(createString);
        }

        public void ExecuteNonQuery(string nonQuery)
        {
            using (var command = new SQLiteCommand(nonQuery, this.connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public SQLiteDataReader Query(string query)
        {
            using (var command = new SQLiteCommand(query, this.connection))
            {
                return command.ExecuteReader();
            }
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void CloseDb()
        {
            if (this.connection != null)
            {
                this.connection.Close();
            }
        }
    }
}
