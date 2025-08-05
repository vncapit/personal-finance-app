using Personal_finance_app.Views;
using Personal_finance_app.Views.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_finance_app.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            initMenuTree();

            firstLoad();
        }

        private void initMenuTree()
        {
            TreeNode finance = new TreeNode { Text = "Finance", Tag = "finance" };
            finance.Nodes.Add(new TreeNode { Text = "Transaction", Tag = "transaction" });
            finance.Nodes.Add(new TreeNode { Text = "Category ", Tag = "category" });
            TreeNode system = new TreeNode { Text = "System", Tag = "system" };
            system.Nodes.Add(new TreeNode { Text = "User Management", Tag = "sys_user" });

            this.treev_menus.Nodes.Add(finance);
            this.treev_menus.Nodes.Add(system);
        }

        private void firstLoad()
        {
            var firstLoadNode = this.treev_menus.Nodes[0].Nodes[0]; // transaction
            this.treev_menus.SelectedNode = firstLoadNode;
            loadChildForm(firstLoadNode);
        }

        private void loadChildForm(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                //Form childForm = new Form();
                //switch (node.Tag)
                //{
                //    case "transaction":
                //        childForm = new TransactionForm();
                //        break;
                //    case "category":
                //        childForm = new CategoryForm();
                //        break;
                //    case "sys_user":
                //        childForm = new SysUserForm();
                //        break;
                //    default:
                //        break;
                //}
                //lbl_menu.Text = node.Text;
                //this.pnl_placeholder.Controls.Clear();
                //childForm.TopLevel = false;
                //childForm.FormBorderStyle = FormBorderStyle.None;
                //childForm.Dock = DockStyle.Fill;
                //pnl_placeholder.Controls.Add(childForm);
                //pnl_placeholder.Tag = childForm;
                //childForm.Show();

                UserControl uc = new UserControl();
                switch (node.Tag)
                {
                    case "transaction":
                        uc = new ucTransaction();
                        break;
                    case "category":
                        uc = new ucCategory();
                        break;
                    default:
                        break;
                }
                lbl_menu.Text = node.Text;
                this.pnl_placeholder.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                pnl_placeholder.Controls.Add(uc);
            }

        }

        private void treev_menus_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            loadChildForm(e.Node);
        }
    }
}
