using Microsoft.Data.Sqlite;
using Personal_finance_app.Enums;
using Personal_finance_app.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.cbx_type.Items.Clear();
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = EnumHelper<TypeEnum>.GetComboBoxItems();

            dgv_transactions.MultiSelect = false;
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
            dgv_transactions.Columns.Add(new DataGridViewButtonColumn { Name = "ATTACHMENTS", DataPropertyName = "ATTACHMENTS", HeaderText = "Attachments", Visible = true, Width = 110 });

            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CATEGORY_ID", DataPropertyName = "CATEGORY_ID", Visible = false });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "CREATED_AT", DataPropertyName = "CREATED_AT", Visible = false });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "UPDATED_AT", DataPropertyName = "UPDATED_AT", Visible = false });
            dgv_transactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", DataPropertyName = "ID", HeaderText = "ID", Visible = false });
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


        private void btn_search_Click(object sender, EventArgs e)
        {
            reloadData();
        }

        private void reloadData()
        {
            this.dgv_transactions.DataSource = null;

            var query = new StringBuilder(@"SELECT t.ID, t.NAME, t.CATEGORY_ID, t.AMOUNT, t.DESC, t.ATTACHMENTS, t.CREATED_AT, t.UPDATED_AT, t.CREATED_AT
                                            , c.TYPE, c.NAME AS CATEGORY_NAME, u.USERNAME AS CREATED_BY_USERNAME
                                            FROM TRANSACTIONS t LEFT JOIN CATEGORIES c ON t.CATEGORY_ID = c.ID
                                            LEFT JOIN USERS u ON t.CREATED_BY = u.ID WHERE 1 = 1");
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
                }
                e.FormattingApplied = true;
            }
        }
    }
}
