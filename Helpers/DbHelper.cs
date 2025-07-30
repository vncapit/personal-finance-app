using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Personal_finance_app.Helpers
{
    public static class DbHelper
    {
        private static readonly string dbPath = Path.Combine(Application.StartupPath, "Database", "pfm.db");
        private static readonly string connString = $"Data Source={dbPath}";

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(connString);
            conn.Open();
            return conn;
        }
    }
}
