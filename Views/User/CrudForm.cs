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

        private CategoryModel Category;
        public CrudForm(CrudEnum type, CategoryModel category = null)
        {
            Type = type;
            Category = category;

            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();

            cbx_role.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_role.Items.Clear();
            cbx_role.DisplayMember = "Name";
            cbx_role.ValueMember = "Value";
            cbx_role.DataSource = EnumHelper<TypeEnum>.GetComboBoxItems(false);

            if (type == CrudEnum.Create)
            {
                Text = "Add new Category";
                btn_save.Text = "Add";
            }
            else if (type == CrudEnum.Update)
            {
                Text = "Modify Category";
                btn_save.Text = "Save";

                if (category != null)
                {
                    cbx_role.SelectedValue = (int)category.Type;
                    tbx_username.Text = category.Name;
                }
                else
                {
                    MessageBox.Show("Category data is not provided for update operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

        }

        private void doCreate()
        {
            if (cbx_role.SelectedValue != null && !string.IsNullOrWhiteSpace(tbx_username.Text))
            {
                try
                {
                    var sql = "SELECT COUNT(1) FROM CATEGORIES WHERE LOWER(NAME) = @NAME";
                    using (var conn = DbHelper.GetConnection())
                    {
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("NAME", tbx_username.Text.Trim().ToLower());
                            var count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"Category with name {tbx_username.Text} existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        sql = "INSERT INTO CATEGORIES (TYPE, NAME, CREATED_AT, UPDATED_AT) VALUES (@TYPE, @NAME, @CREATED_AT, @UPDATED_AT)";
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("TYPE", cbx_role.SelectedValue);
                            cmd.Parameters.AddWithValue("NAME", tbx_username.Text.Trim());
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
        }

        private void doUpdate()
        {
            if (cbx_role.SelectedValue != null && !string.IsNullOrWhiteSpace(tbx_username.Text) && Category != null)
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
                            cmd.Parameters.AddWithValue("ID", Category.Id);
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
                            cmd.Parameters.AddWithValue("ID", Category.Id);
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
