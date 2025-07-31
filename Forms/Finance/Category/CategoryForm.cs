using Personal_finance_app.Enums;
using Personal_finance_app.Forms.Finance.Category;
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
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var crudForm = new CrudForm(CrudEnum.Create);
            if(crudForm.ShowDialog() == DialogResult.OK )
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

        private void reloadData()
        {

        }
    }
}
