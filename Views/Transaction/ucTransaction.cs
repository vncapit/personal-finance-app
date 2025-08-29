using Microsoft.Data.Sqlite;
using Personal_finance_app.Enums;
using Personal_finance_app.Helpers;
using Personal_finance_app.Models;
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
using System.IO;
using System.IO.Compression;

namespace Personal_finance_app.Views.Transaction
{
    public partial class ucTransaction : UserControl
    {
        public ucTransaction()
        {
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            // Datetime range:
            this.dpk_createdAtStartDate.Format = DateTimePickerFormat.Short;
            this.dpk_createdAtEndDate.Format = DateTimePickerFormat.Short;
            this.dpk_createdAtStartTime.Format = DateTimePickerFormat.Time;
            this.dpk_createdAtEndTime.Format = DateTimePickerFormat.Time;
            this.dpk_createdAtStartTime.ShowUpDown = true;
            this.dpk_createdAtEndTime.ShowUpDown = true;

            this.dpk_createdAtStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dpk_createdAtEndDate.Value = DateTime.Now;
            this.dpk_createdAtStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            this.dpk_createdAtEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            // Type
            this.cbx_type.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbx_type.Items.Clear();
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = EnumHelper<TypeEnum>.GetComboBoxItems();

            // DataGridView
            dgv_transactions.MultiSelect = false;
            dgv_transactions.RowHeadersVisible = false;
            dgv_transactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_transactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_transactions.AutoGenerateColumns = false;

            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "NO", DataPropertyName = "NO", HeaderText = "No.", Visible = true, Width = 80 });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "NAME", DataPropertyName = "Name", Visible = true, MinimumWidth = 200 });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CATEGORY_NAME", DataPropertyName = "CATEGORY_NAME", HeaderText = "Category", Visible = true, Width = 180 });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "TYPE_TEXT", DataPropertyName = "TYPE_TEXT", HeaderText = "Type", Visible = true, Width = 110 });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "AMOUNT", DataPropertyName = "AMOUNT", HeaderText = "Amount", Visible = true, Width = 110 });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "DESC", DataPropertyName = "DESC", HeaderText = "Description", Visible = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CREATED_BY_USERNAME", DataPropertyName = "CREATED_BY_USERNAME", HeaderText = "Created By", Visible = true, MinimumWidth = 150 });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CREATED_AT_TEXT", DataPropertyName = "CREATED_AT_TEXT", HeaderText = "Created At", Visible = true, MinimumWidth = 200 });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "UPDATED_AT_TEXT", DataPropertyName = "UPDATED_AT_TEXT", HeaderText = "Updated At", Visible = true, MinimumWidth = 200 });
            dgv_transactions.Columns.Add(new DataGridViewButtonColumn { Name = "ATTACHMENTS", DataPropertyName = "ATTACHMENTS", HeaderText = "Attachments", Visible = true, Width = 110, FlatStyle = FlatStyle.Flat });

            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CATEGORY_ID", DataPropertyName = "CATEGORY_ID", Visible = false });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CREATED_BY", DataPropertyName = "CREATED_BY", Visible = false });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CREATED_AT", DataPropertyName = "CREATED_AT", Visible = false });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "UPDATED_AT", DataPropertyName = "UPDATED_AT", Visible = false });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", DataPropertyName = "ID", HeaderText = "ID", Visible = false });

            // Categories:
            this.cbx_category.DropDownStyle = ComboBoxStyle.DropDownList;
            using (var conn = DbHelper.GetConnection())
            {
                using (var cmd = new SqliteCommand("SELECT ID, NAME FROM CATEGORIES", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var categories = new List<ComboBoxItem>();
                        categories.Add(new ComboBoxItem("", -1));
                        while (reader.Read())
                        {
                            categories.Add(new ComboBoxItem(reader["NAME"].ToString(), Convert.ToInt32(reader["ID"])));
                        }
                        this.cbx_category.DataSource = categories;
                        this.cbx_category.DisplayMember = "Name";
                        this.cbx_category.ValueMember = "Value";
                    }
                }
            }

            // Users:
            this.cbx_createdBy.DropDownStyle = ComboBoxStyle.DropDownList;
            using (var conn = DbHelper.GetConnection())
            {
                using (var cmd = new SqliteCommand("SELECT ID, USERNAME FROM USERS", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var categories = new List<ComboBoxItem>();
                        categories.Add(new ComboBoxItem("", -1));
                        while (reader.Read())
                        {
                            categories.Add(new ComboBoxItem(reader["USERNAME"].ToString(), Convert.ToInt32(reader["ID"])));
                        }
                        this.cbx_createdBy.DataSource = categories;
                        this.cbx_createdBy.DisplayMember = "Name";
                        this.cbx_createdBy.ValueMember = "Value";
                    }
                }
            }
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            var form = new CrudForm(CrudEnum.Create);
            if (form.ShowDialog() == DialogResult.OK)
            {
                reloadData();
            }

        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (dgv_transactions.SelectedRows.Count == 1)
            {
                var selectedRow = dgv_transactions.SelectedRows[0];
                var transactionModel = new TransactionModel
                {
                    Id = Convert.ToInt32(selectedRow.Cells["ID"].Value),
                    Type = (TypeEnum)Enum.Parse(typeof(TypeEnum), selectedRow.Cells["TYPE_TEXT"].Value.ToString()),
                    Name = selectedRow.Cells["NAME"].Value.ToString(),
                    CategoryId = Convert.ToInt32(selectedRow.Cells["CATEGORY_ID"].Value),
                    CategoryName = selectedRow.Cells["CATEGORY_NAME"].Value.ToString(),
                    Amount = Convert.ToDecimal(selectedRow.Cells["AMOUNT"].Value),
                    Desc = selectedRow.Cells["DESC"].Value.ToString(),
                    Attachments = selectedRow.Cells["ATTACHMENTS"].Value.ToString(),
                    CreatedBy = Convert.ToInt32(selectedRow.Cells["CREATED_BY"].Value),
                    CreatedAt = selectedRow.Cells["CREATED_AT"].Value.ToString(),
                    UpdatedAt = selectedRow.Cells["UPDATED_AT"].Value.ToString()
                };
                var crudForm = new CrudForm(CrudEnum.Update, transactionModel);
                if (crudForm.ShowDialog() == DialogResult.OK)
                {
                    reloadData();
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (dgv_transactions.SelectedRows.Count == 1)
            {
                var selectedRow = dgv_transactions.SelectedRows[0];
                var transactionId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                var transactionName = selectedRow.Cells["NAME"].Value.ToString();
                if (MessageBox.Show($"Are you sure you want to delete the transaction '{transactionName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (var conn = DbHelper.GetConnection())
                    {
                        using (var sqlTrans = conn.BeginTransaction())
                        {
                            try
                            {
                                using (var cmd = new SqliteCommand("DELETE FROM TRANSACTIONS WHERE ID = @id", conn))
                                {
                                    cmd.Transaction = sqlTrans;
                                    cmd.Parameters.AddWithValue("@id", transactionId);
                                    cmd.ExecuteNonQuery();
                                }
                                var attachments = selectedRow.Cells["ATTACHMENTS"].Value.ToString();
                                if (!string.IsNullOrEmpty(attachments))
                                {
                                    ResourceHelper.RemoveResources(attachments.Split(",").Select(item => Convert.ToInt32(item)).ToArray(), conn, sqlTrans);
                                }
                                sqlTrans.Commit();
                            }
                            catch (Exception)
                            {
                                sqlTrans.Rollback();
                                throw;
                            }
                        }
                    }
                    reloadData();
                }
            }
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            reloadData();
        }

        private void reloadData()
        {
            this.dgv_transactions.DataSource = null;

            var query = new StringBuilder(@"SELECT t.ID, t.NAME, t.CATEGORY_ID, t.AMOUNT, t.DESC, t.ATTACHMENTS, t.CREATED_BY, t.UPDATED_AT, t.CREATED_AT
                                            , c.TYPE, c.NAME AS CATEGORY_NAME, u.USERNAME AS CREATED_BY_USERNAME
                                            FROM TRANSACTIONS t INNER JOIN CATEGORIES c ON t.CATEGORY_ID = c.ID
                                            INNER JOIN USERS u ON t.CREATED_BY = u.ID WHERE 1 = 1");
            var parameters = new List<SqliteParameter>();

            if (this.cbx_type.SelectedValue != null && (int)this.cbx_type.SelectedValue >= 0)
            {
                query.Append(" AND c.TYPE = @type");
                parameters.Add(new SqliteParameter("@type", (int)this.cbx_type.SelectedValue));
            }

            if (!string.IsNullOrWhiteSpace(tbx_name.Text))
            {
                query.Append(" AND LOWER(t.NAME) LIKE @name");
                parameters.Add(new SqliteParameter("@name", $"%{tbx_name.Text.Trim().ToLower()}%"));
            }

            if (this.cbx_category.SelectedValue != null && (int)this.cbx_category.SelectedValue >= 0)
            {
                query.Append(" AND c.ID = @categoryId");
                parameters.Add(new SqliteParameter("@categoryId", (int)this.cbx_category.SelectedValue));
            }

            {
                query.Append(" AND LOWER(t.DESC) LIKE @desc");
                parameters.Add(new SqliteParameter("@desc", $"%{tbx_description.Text.Trim().ToLower()}%"));
            }

            if (this.cbx_createdBy.SelectedValue != null && (int)this.cbx_createdBy.SelectedValue >= 0)
            {
                query.Append(" AND t.CREATED_BY = @createdBy");
                parameters.Add(new SqliteParameter("@createdBy", (int)this.cbx_createdBy.SelectedValue));
            }

            {
                var startDate = this.dpk_createdAtStartDate.Value.Date + this.dpk_createdAtStartTime.Value.TimeOfDay;
                query.Append(" AND t.CREATED_AT >= @createdAtStart");
                parameters.Add(new SqliteParameter("@createdAtStart", startDate.ToString("yyyyMMddHHmmss")));
                var endDate = this.dpk_createdAtEndDate.Value.Date + this.dpk_createdAtEndTime.Value.TimeOfDay;
                query.Append(" AND t.CREATED_AT <= @createdAtEnd");
                parameters.Add(new SqliteParameter("@createdAtEnd", endDate.ToString("yyyyMMddHHmmss")));
            }

            query.Append(" ORDER BY t.CREATED_AT DESC");

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
                        this.dgv_transactions.DataSource = data;
                    }
                }

            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            this.cbx_type.SelectedIndex = -1;
            this.cbx_type.Text = "";
            this.tbx_name.Text = "";
            this.cbx_category.SelectedIndex = -1;
            this.cbx_category.Text = "";
            this.tbx_description.Text = "";
            this.cbx_createdBy.SelectedIndex = -1;
            this.cbx_createdBy.Text = "";
            this.dpk_createdAtStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dpk_createdAtStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            this.dpk_createdAtEndDate.Value = DateTime.Now;
            this.dpk_createdAtEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.reloadData();
        }

        private void dgv_transactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_transactions.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var row = dgv_transactions.Rows[e.RowIndex];
                if (string.IsNullOrWhiteSpace(row.Cells["ATTACHMENTS"].Value.ToString()))
                {
                    e.Value = "";
                }
                else
                {
                    e.Value = "Download";
                    var cell = row.Cells["ATTACHMENTS"];
                    cell.Style.ForeColor = Color.Red;
                    cell.Style.BackColor = Color.Gray;
                }
                e.FormattingApplied = true;
            }
        }

        private void ucTransaction_Load(object sender, EventArgs e)
        {
            this.reloadData();
        }

        private void dgv_transactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex != dgv_transactions.Columns["ATTACHMENTS"].Index) return;
                var idsString = dgv_transactions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (string.IsNullOrWhiteSpace(idsString)) return;

                var ids = idsString.Split(',').Select(id => Convert.ToInt32(id)).ToArray();
                var filePaths = ResourceHelper.getResourceFilePaths(ids);

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Download attachments";
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    saveFileDialog.Filter = "All files (*.*)|*.*";
                    saveFileDialog.FileName = $"{dgv_transactions.Rows[e.RowIndex].Cells["NAME"].Value}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        var zipPath = saveFileDialog.FileName;
                        using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                        {
                            using (ZipArchive zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                            {
                                foreach (var file in filePaths)
                                {
                                    string entryName = Path.GetFileName(file);
                                    zipArchive.CreateEntryFromFile(file, entryName, CompressionLevel.Optimal);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to download attachments", "Error", MessageBoxButtons.OK);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }
    }
}
