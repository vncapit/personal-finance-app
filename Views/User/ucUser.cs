using Microsoft.Data.Sqlite;
using Personal_finance_app.Enums;
using Personal_finance_app.Helpers;
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

            // Init component
            dgv_users.AutoGenerateColumns = false;
            dgv_users.MultiSelect = false;
            dgv_users.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_users.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_users.RowHeadersVisible = false;
            dgv_users.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgv_users.Columns.Add(new DataGridViewTextBoxColumn { Name = "No", DataPropertyName = "No", HeaderText = "No.", Visible = true, Width = 140, DisplayIndex = 0 });
            dgv_users.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", DataPropertyName = "Username", HeaderText = "Username", Visible = true, DisplayIndex = 1, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv_users.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role", DataPropertyName = "Role", Visible = true, HeaderText = "Role", Width = 250, DisplayIndex = 2 });
            dgv_users.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedAt", DataPropertyName = "CreatedAt", HeaderText = "Created At",  Visible = true, Width = 250, DisplayIndex = 3 });
            dgv_users.Columns.Add(new DataGridViewTextBoxColumn { Name = "UpdatedAt", DataPropertyName = "UpdatedAt", Visible = true, HeaderText = "Updated At", Width = 250, DisplayIndex = 4 });

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if( new CrudForm(CrudEnum.Create).ShowDialog() == DialogResult.OK)
            {
                InitData();
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if( dgv_users.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_users.SelectedRows[0];
                var user = new UserModel
                {
                    Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                    Username = selectedRow.Cells["Username"].Value.ToString(),
                    Role = (RoleEnum)Convert.ToInt32(selectedRow.Cells["Role"].Value),
                    CreatedAt = selectedRow.Cells["CreatedAt"].Value.ToString(),
                    UpdatedAt = selectedRow.Cells["UpdatedAt"].Value.ToString()
                };
                var crudForm = new CrudForm(CrudEnum.Update, user);
                if (crudForm.ShowDialog() == DialogResult.OK)
                {
                    InitData();
                }
            }
            else
            {
                MessageBox.Show("Please select a user to modify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if(dgv_users.SelectedRows.Count > 0)
            {
                var row = dgv_users.SelectedRows[0];
                if (MessageBox.Show($"Are you sure you want to remove user: {row.Cells["Username"].Value.ToString()}") != DialogResult.OK) return;
                try
                {
                    using(var conn = DbHelper.GetConnection())
                    {
                        var sql = "DELETE FROM USERS WHERE ID = @ID";
                        using(var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("ID", Convert.ToInt32(row.Cells["Id"].Value));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Failed to delete user, details: {exception.Message}");
                }
                this.InitData();
            }
        }

        private void InitData()
        {
            dgv_users.DataSource = null;
            var users = new List<UserModel>();
            using (var conn = Helpers.DbHelper.GetConnection())
            {
                string query = "SELECT id, username, role, created_at, updated_at FROM users";
                if(!UserHelper.isSuperAdmin())
                {
                    query += " WHERE username != 'admin'";
                }
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
            dgv_users.DataSource = users.Select((u, index) => new {
                No = index + 1,
                u.Id,
                u.Username,
                u.Role,
                CreatedAt = DateTime.ParseExact(u.CreatedAt, "yyyyMMddHHmmss", null).ToString("yyyy-MM-dd HH:mm:ss"),
                UpdatedAt = DateTime.ParseExact(u.UpdatedAt, "yyyyMMddHHmmss", null).ToString("yyyy-MM-dd HH:mm:ss"),
            }).ToList();
        }

        private void ucUser_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
