using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Personal_finance_app.Helpers;
using Microsoft.Data.Sqlite;
using Personal_finance_app.Models;

namespace Personal_finance_app.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.btn_login.Enabled = false;
        }

        private void doLogin()
        {
            var username = tbx_username.Text.Trim().ToLower();
            var password = tbx_password.Text.Trim();

            var sql = "SELECT * FROM USERS WHERE LOWER(USERNAME) = @username";
            using (var conn = DbHelper.GetConnection())
            {
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            var dbPassword = reader["PASSWORD"].ToString();
                            if(dbPassword != null && dbPassword == HashHelper.GetMd5Hash(password))
                            {
                                var dbId = Convert.ToInt32(reader["ID"]) ;
                                var dbUsername = reader["USERNAME"].ToString();
                                var dbCreatedAt = reader["CREATED_AT"].ToString();
                                var dbUpdatedAt = reader["UPDATED_AT"].ToString();
                                UserHelper.User = new UserModel
                                {
                                    Id = dbId,
                                    Username = dbUsername,
                                    Password = dbPassword,
                                    CreatedAt = dbCreatedAt,
                                    UpdatedAt = dbUpdatedAt
                                };
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                return;
                            }
                        }
                        MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void tbx_username_TextChanged(object sender, EventArgs e)
        {
            validateLogin();
        }

        private void tbx_password_TextChanged(object sender, EventArgs e)
        {
            validateLogin();
        }

        private void validateLogin()
        {
            if (!String.IsNullOrWhiteSpace(tbx_username.Text) && !String.IsNullOrWhiteSpace(tbx_password.Text))
            {
                btn_login.Enabled = true;
            }
            else
            {
                btn_login.Enabled = false;
            }
        }

        private void tbx_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btn_login.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                doLogin();
                Cursor = Cursors.Default;
            }
        }
    }
}
