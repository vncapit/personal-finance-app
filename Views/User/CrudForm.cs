using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Personal_finance_app.Enums;
using Personal_finance_app.Helpers;
using Personal_finance_app.Models;

namespace Personal_finance_app.Views.User
{
    public partial class CrudForm : Form
    {
        private CrudEnum Type;

        private UserModel User;
        public CrudForm(CrudEnum type, UserModel user = null)
        {
            Type = type;
            User = user;

            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();

            cbx_role.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_role.Items.Clear();
            cbx_role.DisplayMember = "Name";
            cbx_role.ValueMember = "Value";
            cbx_role.DataSource = EnumHelper<RoleEnum>.GetComboBoxItems(false);
            cbx_role.SelectedIndex = -1;
            tbx_username.Text = string.Empty;
            tbx_password.Text = string.Empty;
            tbx_confirmPassword.Text = string.Empty;   

            if (type == CrudEnum.Create)
            {
                Text = "Add new user";
                btn_save.Text = "Add";
            }
            else if (type == CrudEnum.Update)
            {
                Text = "Modify user";
                btn_save.Text = "Save";
                tbx_username.Enabled = false;
                if(UserHelper.checkSuperAdmin(user))
                {
                    cbx_role.Enabled = false;
                }

                if (user != null)
                {
                    cbx_role.SelectedValue = (int)user.Role;
                    tbx_username.Text = user.Username;
                }
                else
                {
                    MessageBox.Show("User data is not provided for update operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

        }

        private void doCreate()
        {
            if( tbx_password.Text != tbx_confirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if( tbx_password.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(tbx_username.Text.Trim().Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cbx_role.SelectedValue == null)
            {
                MessageBox.Show("Please select a role for the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if( UserHelper.User.Role != RoleEnum.Admin && (RoleEnum)cbx_role.SelectedValue == RoleEnum.Admin)
            {
                MessageBox.Show("You do not have permission to create an Admin user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                try
                {
                    var sql = "SELECT COUNT(1) FROM USERS WHERE LOWER(USERNAME) = @USERNAME";
                    using (var conn = DbHelper.GetConnection())
                    {
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("USERNAME", tbx_username.Text.Trim().ToLower());
                            var count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"Username with name {tbx_username.Text} existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        var passwordHash = HashHelper.GetMd5Hash(tbx_password.Text.Trim());
                    sql = "INSERT INTO USERS (USERNAME, PASSWORD, ROLE, CREATED_AT, UPDATED_AT) VALUES (@USERNAME, @PASSWORD, @ROLE, @CREATED_AT, @UPDATED_AT)";
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("USERNAME", tbx_username.Text.Trim());
                            cmd.Parameters.AddWithValue("PASSWORD", passwordHash);
                            cmd.Parameters.AddWithValue("ROLE", cbx_role.SelectedValue);
                            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                            cmd.Parameters.AddWithValue("CREATED_AT", timestamp);
                            cmd.Parameters.AddWithValue("UPDATED_AT", timestamp);

                            var count = cmd.ExecuteNonQuery();
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Failed to add category, details: {exception.Message}");
                }
        }

        private void doUpdate()
        {
            if (cbx_role.SelectedValue != null && !string.IsNullOrWhiteSpace(tbx_username.Text) && User != null)
            {
                try
                {
                    var sql = "SELECT COUNT(1) FROM CATEGORIES WHERE LOWER(NAME) = @NAME AND ID <> @ID";
                    using (var conn = DbHelper.GetConnection())
                    {
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("NAME", tbx_username.Text.Trim().ToLower());
                            cmd.Parameters.AddWithValue("ID", User.Id);
                            var count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"Category with name {tbx_username.Text} existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        sql = "UPDATE CATEGORIES SET TYPE = @TYPE, NAME = @NAME, UPDATED_AT = @UPDATED_AT WHERE ID = @ID";
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("TYPE", cbx_role.SelectedValue);
                            cmd.Parameters.AddWithValue("NAME", tbx_username.Text.Trim());
                            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                            cmd.Parameters.AddWithValue("UPDATED_AT", timestamp);
                            cmd.Parameters.AddWithValue("ID", User.Id);
                            var count = cmd.ExecuteNonQuery();
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Failed to update category, details: {exception.Message}");
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (Type == CrudEnum.Create)
            {
                doCreate();
            }

            if (Type == CrudEnum.Update)
            {
                doUpdate();
            }
        }
    }
}
