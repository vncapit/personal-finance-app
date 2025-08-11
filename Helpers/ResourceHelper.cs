using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_finance_app.Helpers
{
    public static class ResourceHelper
    {
        static string RESOURCE_PATH = Path.Combine(Application.StartupPath, "APP_RESOURCES");
        public static int UploadResource(string fromFile)
        {
			try
			{
                var destFile = Path.Combine(RESOURCE_PATH, $"{DateTime.Now.ToString("yyMMddHHmmss")}_{Path.GetFileName(fromFile)}");
                File.Copy(fromFile, destFile);
                // return the resource id
                var fileInfo = new FileInfo(fromFile);
                using (var conn = DbHelper.GetConnection())
                {
                    var query = "INSERT INTO RESOURCES (NAME, PATH, CREATED_AT, EXTENSION ) VALUES (@NAME, @PATH, @CREATED_AT, @EXTENSION); SELECT last_insert_rowid();";
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("NAME", fileInfo.Name);
                        cmd.Parameters.AddWithValue("PATH", destFile);
                        cmd.Parameters.AddWithValue("CREATED_AT", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        cmd.Parameters.AddWithValue("EXTENSION", fileInfo.Extension);

                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception)
			{
				throw;
			}

        }
    }
}
