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

            var sql = "SELECT PASSWORD FROM USERS WHERE LOWER(USERNAME) = @username";
            using (var conn = DbHelper.GetConnection())
            {
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    var res = cmd.ExecuteScalar();
                    if (res != null && res != DBNull.Value)
                    {
                        using (MD5 md5 = MD5.Create())
                        {
                            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                            byte[] hashBytes = md5.ComputeHash(inputBytes);

                            // Convert to hex string
                            StringBuilder sb = new StringBuilder();
                            foreach (byte b in hashBytes)
                            {
                                sb.Append(b.ToString("x2")); // lowercase hex
                            }

                            var passwordMd5 = sb.ToString();
                            if (passwordMd5 == res.ToString())
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                return;
                            }
                        }
                    }
                    MessageBox.Show("Invalid credentials");

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
            if (tbx_username.Text.Trim().Length > 0 && tbx_password.Text.Trim().Length > 0)
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
                doLogin();
            }
        }
    }
}
