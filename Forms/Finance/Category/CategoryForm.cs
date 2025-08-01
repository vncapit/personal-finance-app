using Microsoft.Data.Sqlite;
using Personal_finance_app.Enums;
using Personal_finance_app.Forms.Finance.Category;
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

namespace Personal_finance_app.Forms
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
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

            dgv_categories.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_categories.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_categories.AutoGenerateColumns = false;
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NO", HeaderText = "No.", Visible = true, Width = 90 });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TYPE", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TYPE_TEXT", HeaderText = "Type", Visible = true, MinimumWidth = 180 });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NAME", HeaderText = "Name", Visible = true, MinimumWidth = 510 });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CREATED_AT", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CREATED_AT_TEXT", HeaderText = "Created At", Visible = true, MinimumWidth = 200 });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UPDATED_AT", Visible = false });
            dgv_categories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UPDATED_AT_TEXT", HeaderText = "Updated At", Visible = true, MinimumWidth = 200 });
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
            var query = new StringBuilder("SELECT * FROM CATEGORIES WHERE 1 = 1");
            var parameters = new List<SqliteParameter>();

            if (this.cbx_type.SelectedValue != null && (int)this.cbx_type.SelectedValue >= 0)
            {
                query.Append(" AND TYPE = @type");
                parameters.Add(new SqliteParameter("@type", (int)this.cbx_type.SelectedValue));
            }

            if (!String.IsNullOrWhiteSpace(tbx_name.Text))
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
