using Microsoft.Data.Sqlite;
using Personal_finance_app.Enums;
using Personal_finance_app.Views.Category;
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

namespace Personal_finance_app.Views
{
    public partial class ucCategory : UserControl
    {
        public ucCategory()
        {
            InitializeComponent();
            initControls();
            reloadData();
        }


        private void initControls()
        {
            this.cbx_type.Items.Clear();
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = EnumHelper<TypeEnum>.GetComboBoxItems();

            dgv_categories.MultiSelect = false;
            dgv_categories.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_categories.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_categories.AutoGenerateColumns = false;
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", DataPropertyName = "ID", HeaderText = "ID", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "NO", DataPropertyName = "NO", HeaderText = "No.", Visible = true, Width = 90 });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "TYPE", DataPropertyName = "TYPE", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", DataPropertyName = "TYPE_TEXT", HeaderText = "Type", Visible = true, MinimumWidth = 180 });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "NAME", DataPropertyName = "NAME", HeaderText = "Name", Visible = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "CREATED_AT", DataPropertyName = "CREATED_AT", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "CREATED_AT_TEXT", DataPropertyName = "CREATED_AT_TEXT", HeaderText = "Created At", Visible = true, MinimumWidth = 200 });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "UPDATED_AT", DataPropertyName = "UPDATED_AT", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { Name = "UPDATED_AT_TEXT", DataPropertyName = "UPDATED_AT_TEXT", HeaderText = "Updated At", Visible = true, MinimumWidth = 200 });
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var crudForm = new CrudForm(CrudEnum.Create);
            if (crudForm.ShowDialog() == DialogResult.OK)
            {
                this.reloadData();
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (this.dgv_categories.SelectedRows.Count > 0)
            {
                var selectedRow = this.dgv_categories.SelectedRows[0];
                var category = new CategoryModel();
                category.Id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                category.Type = (TypeEnum)Convert.ToInt32(selectedRow.Cells["TYPE"].Value);
                category.Name = selectedRow.Cells["NAME"].Value.ToString();
                category.CreatedAt = selectedRow.Cells["CREATED_AT"].Value.ToString();
                category.UpdatedAt = selectedRow.Cells["UPDATED_AT"].Value.ToString();
                var crudForm = new CrudForm(CrudEnum.Update, category);
                if (crudForm.ShowDialog() == DialogResult.OK)
                {
                    this.reloadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a category to modify.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (this.dgv_categories.SelectedRows.Count > 0)
            {
                var selectedRow = this.dgv_categories.SelectedRows[0];
                var categoryId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                var categoryName = selectedRow.Cells["NAME"].Value.ToString();
                var confirmResult = MessageBox.Show($"Are you sure you want to delete this category: [{categoryName}]?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = DbHelper.GetConnection())
                        {
                            var sql = "SELECT COUNT(*) FROM TRANSACTIONS WHERE CATEGORY_ID = @CATEGORY_ID";
                            using (var cmd = new SqliteCommand(sql, conn))
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@CATEGORY_ID", categoryId);
                                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                                {
                                    MessageBox.Show("This category is associated with existing transactions and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                sql = "DELETE FROM CATEGORIES WHERE ID = @ID";
                                cmd.CommandText = sql;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ID", categoryId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.reloadData();
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            reloadData();
        }

        private void reloadData()
        {
            this.dgv_categories.DataSource = null;

            var query = new StringBuilder("SELECT ID, TYPE, NAME, UPDATED_AT, CREATED_AT FROM CATEGORIES WHERE 1 = 1");
            var parameters = new List<SqliteParameter>();

            if (this.cbx_type.SelectedValue != null && (int)this.cbx_type.SelectedValue >= 0)
            {
                query.Append(" AND TYPE = @type");
                parameters.Add(new SqliteParameter("@type", (int)this.cbx_type.SelectedValue));
            }

            if (!string.IsNullOrWhiteSpace(tbx_name.Text))
            {
                query.Append(" AND LOWER(NAME) LIKE @name");
                parameters.Add(new SqliteParameter("@name", $"%{tbx_name.Text.Trim().ToLower()}%"));
            }

            using (var conn = DbHelper.GetConnection())
            {
                using (var cmd = new SqliteCommand(query.ToString(), conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var data = new DataTable();
                        data.Load(reader);
                        data.Columns.Add("NO", typeof(int));
                        data.Columns.Add("TYPE_TEXT", typeof(string));
                        data.Columns.Add("CREATED_AT_TEXT", typeof(string));
                        data.Columns.Add("UPDATED_AT_TEXT", typeof(string));
                        int index = 1;
                        foreach (DataRow row in data.Rows)
                        {
                            row["NO"] = index;
                            row["TYPE_TEXT"] = Enum.GetName(typeof(TypeEnum), Convert.ToInt32(row["TYPE"]));
                            row["CREATED_AT_TEXT"] = DateTime.ParseExact(row["CREATED_AT"].ToString(), "yyyyMMddHHmmss", null).ToString("yyyy-MM-dd HH:mm:ss");
                            row["UPDATED_AT_TEXT"] = DateTime.ParseExact(row["UPDATED_AT"].ToString(), "yyyyMMddHHmmss", null).ToString("yyyy-MM-dd HH:mm:ss");
                            index++;
                        }
                        this.dgv_categories.DataSource = data;
                    }
                }

            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            this.cbx_type.SelectedIndex = -1;
            this.cbx_type.Text = "";
            this.tbx_name.Text = "";
            this.reloadData();
        }
    }
}
