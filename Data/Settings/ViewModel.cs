namespace SpeakerTimer.Data.Settings
{
    using System;
    using System.Data.SQLite;

    public abstract class ViewModel : IReadModel
    {
        private readonly string viewName;
        private SQLiteConnection connection;

        private static readonly string connectionString;
        static ViewModel()
        {
            connectionString = (string)AppDomain.CurrentDomain.GetData("ConnectionString");
        }

        public ViewModel(string viewName)
        {
            this.viewName = viewName;
            this.OpenConnection();
            this.CreateView();
        }

        public void OpenConnection()
        {
            if (this.connection == null)
            {
                this.connection = new SQLiteConnection(ViewModel.connectionString);
            }

            this.connection.Open();
        }

        public void CreateTable()
        {
            throw new NotSupportedException();
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

        public void CloseDatabase()
        {
            if (this.connection != null)
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
