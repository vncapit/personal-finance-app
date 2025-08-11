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

namespace Personal_finance_app.Views.Transaction
{
    public partial class CrudForm : Form
    {
        private string RESOURCE_PATH = Path.Combine(Application.StartupPath, "APP_RESOURCES");
        private CrudEnum Type;

        private TransactionModel Transaction;
        public CrudForm(CrudEnum type, TransactionModel transaction = null)
        {
            Type = type;
            Transaction = transaction;

            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();

            initControls();

            if (type == CrudEnum.Create)
            {
                Text = "Add new Transaction";
                btn_save.Text = "Add";
            }
            else if (type == CrudEnum.Update)
            {
                Text = "Modify Transaction";
                btn_save.Text = "Save";

                if (transaction != null)
                {
                    cbx_type.SelectedValue = (int)transaction.Type;
                    tbx_name.Text = transaction.Name;
                }
                else
                {
                    MessageBox.Show("Transaction data is not provided for update operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            if (!Directory.Exists(RESOURCE_PATH))
            {
                Directory.CreateDirectory(RESOURCE_PATH);
            }

        }

        private void initControls()
        {
            //
            cbx_type.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_type.Items.Clear();
            cbx_type.DisplayMember = "Name";
            cbx_type.ValueMember = "Value";
            cbx_type.DataSource = EnumHelper<TypeEnum>.GetComboBoxItems(false);
            cbx_type.SelectedValue = (int)TypeEnum.Expense;

            // 
            var categoryItems = getCategoryBox(TypeEnum.Expense);
            cbx_category.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_category.Items.Clear();
            cbx_category.DisplayMember = "Name";
            cbx_category.ValueMember = "Value";
            cbx_category.DataSource = getCategoryBox(TypeEnum.Expense);
            cbx_category.SelectedIndex = -1;

            cbx_type.SelectedIndexChanged += (sender, e) =>
            {
                if (cbx_type.SelectedValue != null)
                {
                    cbx_category.DataSource = getCategoryBox((TypeEnum)(cbx_type.SelectedValue));
                }
            };
        }

        private List<ComboBoxItem> getCategoryBox(TypeEnum type)
        {
            var items = new List<ComboBoxItem>();
            using (var conn = DbHelper.GetConnection())
            {
                var query = "SELECT ID, NAME, TYPE FROM CATEGORIES WHERE TYPE = @TYPE";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("TYPE", (int)type);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ComboBoxItem(reader["NAME"].ToString(), Convert.ToInt32(reader["ID"]));
                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }

        private void doCreate()
        {
            if (cbx_type.SelectedValue != null && cbx_category.SelectedValue != null && !string.IsNullOrEmpty(tbx_name.Text))
            {
                // handle attachments
                var resourceIds = new List<int>();
                if (lv_attachments.Items.Count > 0)
                {
                    try
                    {
                        // move file first, insert later
                        foreach (ListViewItem item in lv_attachments.Items)
                        {
                            var resourceId = ResourceHelper.UploadResource(item.Tag.ToString());
                            resourceIds.Add(resourceId);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Attachment upload failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    using (var conn = DbHelper.GetConnection())
                    {
                        var sql = "INSERT INTO TRANSACTIONS (CATEGORY_ID, NAME, AMOUNT, DESC, CREATED_BY, CREATED_AT, UPDATED_AT, ATTACHMENTS) VALUES (@CATEGORY_ID, @NAME, @AMOUNT, @DESC, @CREATED_BY, @CREATED_AT, @UPDATED_AT, @ATTACHMENTS);";
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("CATEGORY_ID", cbx_category.SelectedValue);
                            cmd.Parameters.AddWithValue("NAME", tbx_name.Text.Trim());
                            cmd.Parameters.AddWithValue("AMOUNT", Convert.ToDecimal(tbx_amount.Text.Trim()));
                            cmd.Parameters.AddWithValue("DESC", tbx_description.Text.Trim());
                            cmd.Parameters.AddWithValue("CREATED_BY", UserHelper.User.Id);
                            var tranCreatedAt = this.dpk_createdAtStartDate.Value.Date.Add(this.dpk_createdAtStartTime.Value.TimeOfDay).ToString("yyyyMMddHHmmss");
                            cmd.Parameters.AddWithValue("CREATED_AT", tranCreatedAt);
                            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                            cmd.Parameters.AddWithValue("UPDATED_AT", timestamp);
                            cmd.Parameters.AddWithValue("ATTACHMENTS", string.Join(",", resourceIds));

                            cmd.ExecuteNonQuery();

                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Failed to create transaction, details: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void doUpdate()
        {
            if (cbx_type.SelectedValue != null && !string.IsNullOrWhiteSpace(tbx_name.Text) && Transaction != null)
            {
                try
                {
                    var sql = "SELECT COUNT(1) FROM CATEGORIES WHERE LOWER(NAME) = @NAME AND ID <> @ID";
                    using (var conn = DbHelper.GetConnection())
                    {
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("NAME", tbx_name.Text.Trim().ToLower());
                            cmd.Parameters.AddWithValue("ID", Transaction.Id);
                            var count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"Category with name {tbx_name.Text} existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        sql = "UPDATE CATEGORIES SET TYPE = @TYPE, NAME = @NAME, UPDATED_AT = @UPDATED_AT WHERE ID = @ID";
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("TYPE", cbx_type.SelectedValue);
                            cmd.Parameters.AddWithValue("NAME", tbx_name.Text.Trim());
                            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                            cmd.Parameters.AddWithValue("UPDATED_AT", timestamp);
                            cmd.Parameters.AddWithValue("ID", Transaction.Id);
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
        private void btn_chooseFiles_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Select Attachments",
                Multiselect = true,
                Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileNames.Length > 3)
                {
                    MessageBox.Show("Limit max 3 files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.lv_attachments.Items.Clear();
                var index = 0;
                foreach (var fileName in fileDialog.FileNames)
                {
                    index++;
                    var fileInfo = new FileInfo(fileName);
                    var item = new ListViewItem { Text = index.ToString(), Tag = fileName };
                    item.SubItems.Add(fileInfo.Name);
                    item.SubItems.Add((fileInfo.Length / 1024).ToString());
                    item.SubItems.Add(fileInfo.Extension);
                    lv_attachments.Items.Add(item);
                }
            }
        }

        private void tbx_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) return ;
            if (char.IsControl(e.KeyChar)) return ;
            if (e.KeyChar == '.' && !((TextBox)sender).Text.Contains("."))
                return;
            e.Handled = true; // Ignore any other character
        }
    }
}
