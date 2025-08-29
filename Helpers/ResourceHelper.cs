using Microsoft.Data.Sqlite;
using Personal_finance_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                var destFileFull = Path.Combine(RESOURCE_PATH, $"{DateTime.Now.ToString("yyMMddHHmmss")}_{Path.GetFileName(fromFile)}");
                File.Copy(fromFile, destFileFull);
                // return the resource id
                var fileInfo = new FileInfo(fromFile);
                using (var conn = DbHelper.GetConnection())
                {
                    var query = "INSERT INTO RESOURCES (NAME, SIZE, PATH, CREATED_AT, EXTENSION ) VALUES (@NAME, @SIZE, @PATH, @CREATED_AT, @EXTENSION); SELECT last_insert_rowid();";
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("NAME", fileInfo.Name);
                        cmd.Parameters.AddWithValue("SIZE", fileInfo.Length/1024);
                        cmd.Parameters.AddWithValue("PATH", Path.GetRelativePath(RESOURCE_PATH, destFileFull));
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

        public static void RemoveResources(int[] resourceIds, SqliteConnection conn, SqliteTransaction? trans = null )
        {
            try
            {
                var resources = GetResources(resourceIds);

                var ids = resourceIds.Select((value, index) =>
                {
                    return $"@ID{index}";
                }).ToArray();
                var query = $"DELETE FROM RESOURCES WHERE ID IN ({string.Join(",", ids)}) ";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    var index = 0;
                    foreach (var id in ids)
                    {
                        cmd.Parameters.AddWithValue(id, resourceIds[index]);
                        index++;
                    }
                    if (trans != null)
                    {
                        cmd.Transaction = trans;
                    }
                        cmd.ExecuteNonQuery();
                }

                // remove files:
                foreach (var item in resources)
                {
                    try
                    {
                        File.Delete(Path.Combine(RESOURCE_PATH, item.Path));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ResourceModel> GetResources(int[] resourceIds)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {

                    var ids = resourceIds.Select((value, index) =>
                    {
                        return $"@ID{index}";
                    }).ToArray();
                    var query = $"SELECT * FROM RESOURCES WHERE ID IN ({string.Join(",", ids)}) ";
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        var index = 0;
                        foreach (var id in ids)
                        {
                            cmd.Parameters.AddWithValue(id, resourceIds[index]);
                            index++;
                        }
                        using (var reader = cmd.ExecuteReader())
                        {
                            var resources = new List<ResourceModel>();
                            while (reader.Read())
                            {
                                resources.Add(new ResourceModel
                                {
                                    Id = Convert.ToInt32(reader["ID"]),
                                    Name = (string)reader["NAME"],
                                    Size = Convert.ToInt32(reader["SIZE"]),
                                    Path = (string)reader["PATH"],
                                    CreatedAt = (string)reader["CREATED_AT"],
                                    Extension = (string)reader["EXTENSION"]
                                }); 
                            }
                            return resources;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string[] getResourceFilePaths(int[] ids)
        {
            var resourceModels = GetResources(ids);
            return resourceModels.Select(r => Path.Combine(RESOURCE_PATH, r.Path)).ToArray();
        }
    }
}
