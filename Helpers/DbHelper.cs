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
        private static readonly string dbPath = Path.Combine(Application.StartupPath, "pfm.db");
        private static readonly string connString = $"Data Source={dbPath}";

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(connString);
            conn.Open();
            return conn;
        }

        public static bool InitDatabase()
        {
            try
            {
                var configPath = Path.Combine(Application.StartupPath, ".ini");
                if(File.Exists(configPath))
                {
                    var configLines = File.ReadAllLines(configPath);
                    foreach (var config in configLines)
                    {
                        if(config.Trim().ToLower() == "init=1")
                        {
                            return true;
                        }
                    }
                }

                // init db
                var configFile = File.Create(configPath);
                configFile.Write(UTF8Encoding.UTF8.GetBytes("init=1"));
                configFile.Close();
                string dbSourcePath = Path.Combine(Application.StartupPath, "Database", "pfm.db");
                File.Copy(dbSourcePath, dbPath, overwrite: true);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
