using Microsoft.Data.Sqlite;
using Personal_finance_app.Enums;
using Personal_finance_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_finance_app.Views.User
{
    public partial class ucUser : UserControl
    {
        public ucUser()
        {
            InitializeComponent();
            dgv_users.AutoSize = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_modify_Click(object sender, EventArgs e)
        {

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

        }

        private void InitData()
        {
            dgv_users.Rows.Clear();
            var users = new List<UserModel>();
            using (var conn = Helpers.DbHelper.GetConnection())
            {
                string query = "SELECT id, username, role, created_at, updated_at FROM users";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var user = new UserModel
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Username = reader["USERNAME"].ToString(),
                                Role = (RoleEnum)Convert.ToInt32( reader["ROLE"]),
                                CreatedAt = reader["CREATED_AT"].ToString(),
                                UpdatedAt = reader["UPDATED_AT"].ToString()
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            dgv_users.DataSource = users.Select(u => new {
                u.Id,
                u.Username,
                u.Role,
                CreatedAt = DateTime.ParseExact(u.CreatedAt, "yyyyMMddHHmmss", null),
                UpdatedAt = DateTime.ParseExact(u.UpdatedAt, "yyyyMMddHHmmss", null) 
            }).ToList();
        }

        private void ucUser_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
