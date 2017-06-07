namespace SpeakerTimer.Data
{
    using System;
    using System.Data.SQLite;

    public abstract class DataView : IReadModel
    {
        private readonly string viewName;
        private bool isOpen;
        private SQLiteConnection connection;

        private static readonly string connectionString;

        static DataView()
        {
            connectionString = (string)AppDomain.CurrentDomain.GetData("ConnectionString");
        }

        public DataView(string viewName)
        {
            this.isOpen = false;
            this.viewName = viewName;
            this.OpenConnection();
            this.CreateView();
        }

        public void OpenConnection()
        {
            if (this.connection == null)
            {
                this.connection = new SQLiteConnection(DataView.connectionString);
            }

            if (!this.isOpen)
            {
                this.connection.Open();
                this.isOpen = true;
            }
        }

        public void CreateTable()
        {
            throw new NotSupportedException();
        }

        public SQLiteDataReader Query(string query, params SQLiteParameter[] parameters)
        {
            if (this.connection == null) this.OpenConnection();

            try
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseDatabase()
        {
            if (this.connection != null && this.isOpen)
            {
                this.connection.Close();
            }
        }

        public abstract void CreateView();

        protected void CreateView(string createSql)
        {
            using (var command = new SQLiteCommand(createSql, this.connection))
            {
                command.ExecuteNonQuery();
            }
        }

        protected SQLiteDataReader Select(string condition = "")
        {
            var sql = "SELECT * FROM [" + this.viewName + "] ";
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
            var sql = "SELECT " + cols + " FROM [" + this.viewName + "] ";
            if (!string.IsNullOrEmpty(condition))
            {
                sql += condition.Trim();
            }

            return this.Query(sql);
        }
    }
}
