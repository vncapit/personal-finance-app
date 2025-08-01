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

namespace Personal_finance_app.Forms
{
    public partial class TransactionForm : Form
    {
        public TransactionForm()
        {
            InitializeComponent();
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

            var query = new StringBuilder(@"SELECT t.ID, t.NAME, t.CATEGORY_ID, t.AMOUNT, t.DESC, t.CREATED_AT, t.UPDATED_AT, t.CREATED_AT
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
    }
}
