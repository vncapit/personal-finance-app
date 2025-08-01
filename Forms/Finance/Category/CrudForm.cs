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

namespace Personal_finance_app.Forms.Finance.Category
{
    public partial class CrudForm : Form
    {
        private CrudEnum Type;
        public CrudForm(CrudEnum type)
        {
            this.Type = type;
            InitializeComponent();

            this.cbx_type.DropDownStyle = ComboBoxStyle.DropDownList;

            if (type == CrudEnum.Create)
            {
                this.Text = "Add new Category";
                this.btn_save.Text = "Add";

                initAddData();
            }
            else if (type == CrudEnum.Update)
            {
                this.Text = "Modify Category";
                this.btn_save.Text = "Save";
            }

        }

        private void initAddData()
        {
            this.cbx_type.Items.Clear();
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = EnumHelper<TypeEnum>.GetComboBoxItems(false);
        }

        private void doCreate()
        {
            if (this.cbx_type.SelectedValue != null && !String.IsNullOrWhiteSpace(this.tbx_name.Text))
            {
                try
                {
                    var sql = "SELECT COUNT(1) FROM CATEGORIES WHERE NAME = @NAME";
                    using (var conn = DbHelper.GetConnection())
                    {
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("NAME", this.tbx_name.Text.Trim());
                            var count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"Category with name {tbx_name.Text} existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        sql = "INSERT INTO CATEGORIES (TYPE, NAME, CREATED_AT, UPDATED_AT) VALUES (@TYPE, @NAME, @CREATED_AT, @UPDATED_AT)";
                        using (var cmd = new SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("TYPE", this.cbx_type.SelectedValue);
                            cmd.Parameters.AddWithValue("NAME", this.tbx_name.Text.Trim());
                            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                            cmd.Parameters.AddWithValue("CREATED_AT", timestamp);
                            cmd.Parameters.AddWithValue("UPDATED_AT", timestamp);

                            var count = cmd.ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
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

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(this.Type == CrudEnum.Create)
            {
                doCreate();
            }

            if(this.Type == CrudEnum.Update)
            {
                doUpdate();
            }
        }
    }
}
