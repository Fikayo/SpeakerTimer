namespace SpeakerTimer.Data
{
    using System;
    using System.Data.SQLite;

    public abstract class DataModel : IReadWrite
    {
        private readonly string tableName;
        private bool isOpen;
        private SQLiteConnection connection;

        private static readonly string connectionString;
        static DataModel()
        {
            connectionString = (string)AppDomain.CurrentDomain.GetData("ConnectionString");
        }

        public DataModel(string tableName)
        {
            this.isOpen = false;
            this.tableName = tableName;
            this.OpenConnection();
            this.CreateTable();
        }

        public void OpenConnection()
        {
            if (this.connection == null)
            {
                this.connection = new SQLiteConnection(DataModel.connectionString);
                this.ExecuteNonQuery("PRAGMA foreign_keys = ON");
            }

            if (!this.isOpen)
            {
                this.connection.Open();
                this.isOpen = true;
            }
        }

        public void ExecuteNonQuery(string nonQuery, params SQLiteParameter[] parameters)
        {
            if (this.connection == null) this.OpenConnection();

            try
            {
                using (var command = new SQLiteCommand(nonQuery, this.connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public SQLiteDataReader Query(string query, params SQLiteParameter[] parameters)
        {
            if (this.connection == null) this.OpenConnection();

            using (var command = new SQLiteCommand(query, this.connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }

                return command.ExecuteReader();
            }
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void CloseDatabase()
        {
            if (this.connection != null && this.isOpen)
            {
                this.connection.Close();
            }
        }

        public abstract void CreateTable();

        protected void CreateTable(string createColumnList)
        {
            var createString = "CREATE TABLE IF NOT EXISTS [" + this.tableName + "] (" + createColumnList + ");";
            this.ExecuteNonQuery(createString);
        }

        protected SQLiteDataReader Select(string condition = "")
        {
            var sql = "SELECT * FROM [" + this.tableName + "] ";
            if (!string.IsNullOrEmpty(condition))
            {
                sql += condition.Trim();
            }

            return this.Query(sql);
        }

        protected SQLiteDataReader Project(string condition, DbColumn col1, params DbColumn[] columns)
        {
            var cols = col1.Name;
            foreach (var col in columns)
            {
                cols += ", [" + col.Name + "]";
            }
            var sql = "SELECT " + cols + " FROM [" + this.tableName + "] ";
            if (!string.IsNullOrEmpty(condition))
            {
                sql += condition.Trim();
            }

            return this.Query(sql);
        }
        
        protected int Insert(string nonQuery, params SQLiteParameter[] parameters)
        {
            this.ExecuteNonQuery(nonQuery, parameters);
            var reader = this.Query("SELECT last_insert_rowid();");

            reader.Read();
            return int.Parse((string)reader[0]);
        }
    }
}
