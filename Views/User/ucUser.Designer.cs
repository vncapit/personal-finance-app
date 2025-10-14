namespace Personal_finance_app.Views.User
{
    partial class ucUser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUser));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            btn_remove = new Button();
            btn_add = new Button();
            btn_modify = new Button();
            panel2 = new Panel();
            dgv_users = new DataGridView();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_users).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(9, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1247, 103);
            panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_remove);
            groupBox1.Controls.Add(btn_add);
            groupBox1.Controls.Add(btn_modify);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(14, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(362, 83);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Action";
            // 
            // btn_remove
            // 
            btn_remove.BackColor = SystemColors.GradientActiveCaption;
            btn_remove.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_remove.Image = (Image)resources.GetObject("btn_remove.Image");
            btn_remove.ImageAlign = ContentAlignment.MiddleLeft;
            btn_remove.Location = new Point(230, 27);
            btn_remove.Name = "btn_remove";
            btn_remove.Padding = new Padding(5, 0, 5, 0);
            btn_remove.Size = new Size(116, 41);
            btn_remove.TabIndex = 2;
            btn_remove.Text = "Remove";
            btn_remove.TextAlign = ContentAlignment.MiddleRight;
            btn_remove.UseVisualStyleBackColor = false;
            btn_remove.Click += btn_remove_Click;
            // 
            // btn_add
            // 
            btn_add.BackColor = SystemColors.GradientActiveCaption;
            btn_add.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_add.Image = (Image)resources.GetObject("btn_add.Image");
            btn_add.ImageAlign = ContentAlignment.MiddleLeft;
            btn_add.Location = new Point(14, 27);
            btn_add.Name = "btn_add";
            btn_add.Padding = new Padding(5, 0, 5, 0);
            btn_add.Size = new Size(90, 41);
            btn_add.TabIndex = 0;
            btn_add.Text = "Add";
            btn_add.TextAlign = ContentAlignment.MiddleRight;
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // btn_modify
            // 
            btn_modify.BackColor = SystemColors.GradientActiveCaption;
            btn_modify.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_modify.Image = (Image)resources.GetObject("btn_modify.Image");
            btn_modify.ImageAlign = ContentAlignment.MiddleLeft;
            btn_modify.Location = new Point(113, 27);
            btn_modify.Name = "btn_modify";
            btn_modify.Padding = new Padding(5, 0, 5, 0);
            btn_modify.Size = new Size(107, 41);
            btn_modify.TabIndex = 1;
            btn_modify.Text = "Modify";
            btn_modify.TextAlign = ContentAlignment.MiddleRight;
            btn_modify.UseVisualStyleBackColor = false;
            btn_modify.Click += btn_modify_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(dgv_users);
            panel2.Location = new Point(9, 124);
            panel2.Name = "panel2";
            panel2.Size = new Size(1247, 634);
            panel2.TabIndex = 7;
            // 
            // dgv_users
            // 
            dgv_users.AllowUserToAddRows = false;
            dgv_users.AllowUserToDeleteRows = false;
            dgv_users.AllowUserToResizeColumns = false;
            dgv_users.AllowUserToResizeRows = false;
            dgv_users.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_users.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_users.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_users.Location = new Point(8, 12);
            dgv_users.MultiSelect = false;
            dgv_users.Name = "dgv_users";
            dgv_users.ReadOnly = true;
            dgv_users.RowHeadersVisible = false;
            dgv_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_users.Size = new Size(1227, 611);
            dgv_users.TabIndex = 0;
            // 
            // ucUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ucUser";
            Size = new Size(1278, 761);
            Load += ucUser_Load;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_users).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private Button btn_remove;
        private Button btn_add;
        private Button btn_modify;
        private Panel panel2;
        private DataGridView dgv_users;
    }
}
