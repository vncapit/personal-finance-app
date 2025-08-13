namespace Personal_finance_app.Views.Transaction
{
    partial class ucTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTransaction));
            panel2 = new Panel();
            dgv_transactions = new DataGridView();
            btn_remove = new Button();
            btn_add = new Button();
            cbx_category = new ComboBox();
            label7 = new Label();
            dpk_createdAtEndTime = new DateTimePicker();
            dpk_createdAtEndDate = new DateTimePicker();
            dpk_createdAtStartTime = new DateTimePicker();
            dpk_createdAtStartDate = new DateTimePicker();
            label6 = new Label();
            cbx_createdBy = new ComboBox();
            tbx_description = new TextBox();
            groupBox1 = new GroupBox();
            btn_modify = new Button();
            tbx_name = new TextBox();
            label4 = new Label();
            label3 = new Label();
            btn_reset = new Button();
            btn_search = new Button();
            label2 = new Label();
            cbx_type = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label5 = new Label();
            panel1 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_transactions).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(dgv_transactions);
            panel2.Location = new Point(10, 190);
            panel2.Name = "panel2";
            panel2.Size = new Size(1557, 481);
            panel2.TabIndex = 5;
            // 
            // dgv_transactions
            // 
            dgv_transactions.AllowUserToAddRows = false;
            dgv_transactions.AllowUserToDeleteRows = false;
            dgv_transactions.AllowUserToResizeColumns = false;
            dgv_transactions.AllowUserToResizeRows = false;
            dgv_transactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_transactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_transactions.Location = new Point(0, 3);
            dgv_transactions.Name = "dgv_transactions";
            dgv_transactions.ReadOnly = true;
            dgv_transactions.RowHeadersVisible = false;
            dgv_transactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_transactions.Size = new Size(1551, 451);
            dgv_transactions.TabIndex = 0;
            dgv_transactions.CellFormatting += dgv_transactions_CellFormatting;
            // 
            // btn_remove
            // 
            btn_remove.BackColor = SystemColors.GradientActiveCaption;
            btn_remove.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_remove.Image = (Image)resources.GetObject("btn_remove.Image");
            btn_remove.ImageAlign = ContentAlignment.MiddleLeft;
            btn_remove.Location = new Point(230, 28);
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
            btn_add.Location = new Point(14, 28);
            btn_add.Name = "btn_add";
            btn_add.Padding = new Padding(5, 0, 5, 0);
            btn_add.Size = new Size(90, 41);
            btn_add.TabIndex = 0;
            btn_add.Text = "Add";
            btn_add.TextAlign = ContentAlignment.MiddleRight;
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // cbx_category
            // 
            cbx_category.FormattingEnabled = true;
            cbx_category.Location = new Point(306, 35);
            cbx_category.Name = "cbx_category";
            cbx_category.Size = new Size(210, 29);
            cbx_category.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(862, 76);
            label7.Name = "label7";
            label7.Size = new Size(16, 21);
            label7.TabIndex = 22;
            label7.Text = "-";
            // 
            // dpk_createdAtEndTime
            // 
            dpk_createdAtEndTime.Format = DateTimePickerFormat.Time;
            dpk_createdAtEndTime.Location = new Point(1027, 73);
            dpk_createdAtEndTime.Name = "dpk_createdAtEndTime";
            dpk_createdAtEndTime.Size = new Size(112, 29);
            dpk_createdAtEndTime.TabIndex = 21;
            // 
            // dpk_createdAtEndDate
            // 
            dpk_createdAtEndDate.Format = DateTimePickerFormat.Short;
            dpk_createdAtEndDate.Location = new Point(891, 73);
            dpk_createdAtEndDate.Name = "dpk_createdAtEndDate";
            dpk_createdAtEndDate.Size = new Size(129, 29);
            dpk_createdAtEndDate.TabIndex = 20;
            // 
            // dpk_createdAtStartTime
            // 
            dpk_createdAtStartTime.Format = DateTimePickerFormat.Time;
            dpk_createdAtStartTime.Location = new Point(732, 73);
            dpk_createdAtStartTime.Name = "dpk_createdAtStartTime";
            dpk_createdAtStartTime.Size = new Size(115, 29);
            dpk_createdAtStartTime.TabIndex = 19;
            // 
            // dpk_createdAtStartDate
            // 
            dpk_createdAtStartDate.Format = DateTimePickerFormat.Short;
            dpk_createdAtStartDate.Location = new Point(595, 73);
            dpk_createdAtStartDate.Name = "dpk_createdAtStartDate";
            dpk_createdAtStartDate.Size = new Size(131, 29);
            dpk_createdAtStartDate.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(496, 79);
            label6.Name = "label6";
            label6.Size = new Size(93, 21);
            label6.TabIndex = 17;
            label6.Text = "Created At:";
            // 
            // cbx_createdBy
            // 
            cbx_createdBy.FormattingEnabled = true;
            cbx_createdBy.Location = new Point(348, 76);
            cbx_createdBy.Name = "cbx_createdBy";
            cbx_createdBy.Size = new Size(133, 29);
            cbx_createdBy.TabIndex = 16;
            // 
            // tbx_description
            // 
            tbx_description.Location = new Point(79, 76);
            tbx_description.Name = "tbx_description";
            tbx_description.Size = new Size(156, 29);
            tbx_description.TabIndex = 15;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_remove);
            groupBox1.Controls.Add(btn_add);
            groupBox1.Controls.Add(btn_modify);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(14, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(362, 119);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Action";
            // 
            // btn_modify
            // 
            btn_modify.BackColor = SystemColors.GradientActiveCaption;
            btn_modify.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_modify.Image = (Image)resources.GetObject("btn_modify.Image");
            btn_modify.ImageAlign = ContentAlignment.MiddleLeft;
            btn_modify.Location = new Point(113, 28);
            btn_modify.Name = "btn_modify";
            btn_modify.Padding = new Padding(5, 0, 5, 0);
            btn_modify.Size = new Size(107, 41);
            btn_modify.TabIndex = 1;
            btn_modify.Text = "Modify";
            btn_modify.TextAlign = ContentAlignment.MiddleRight;
            btn_modify.UseVisualStyleBackColor = false;
            btn_modify.Click += btn_modify_Click;
            // 
            // tbx_name
            // 
            tbx_name.Location = new Point(609, 35);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(239, 29);
            tbx_name.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 79);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 11;
            label4.Text = "Desc:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(538, 38);
            label3.Name = "label3";
            label3.Size = new Size(57, 21);
            label3.TabIndex = 9;
            label3.Text = "Name:";
            // 
            // btn_reset
            // 
            btn_reset.BackColor = SystemColors.Info;
            btn_reset.Font = new Font("Segoe UI", 12F);
            btn_reset.Image = (Image)resources.GetObject("btn_reset.Image");
            btn_reset.ImageAlign = ContentAlignment.MiddleLeft;
            btn_reset.Location = new Point(1034, 30);
            btn_reset.Name = "btn_reset";
            btn_reset.Padding = new Padding(5, 0, 5, 0);
            btn_reset.Size = new Size(105, 37);
            btn_reset.TabIndex = 8;
            btn_reset.Text = "Refresh";
            btn_reset.TextAlign = ContentAlignment.MiddleRight;
            btn_reset.UseVisualStyleBackColor = false;
            btn_reset.Click += btn_reset_Click;
            // 
            // btn_search
            // 
            btn_search.BackColor = SystemColors.GradientActiveCaption;
            btn_search.Font = new Font("Segoe UI", 12F);
            btn_search.Image = (Image)resources.GetObject("btn_search.Image");
            btn_search.ImageAlign = ContentAlignment.MiddleLeft;
            btn_search.Location = new Point(921, 30);
            btn_search.Name = "btn_search";
            btn_search.Padding = new Padding(5, 0, 5, 0);
            btn_search.Size = new Size(107, 37);
            btn_search.TabIndex = 7;
            btn_search.Text = "Search";
            btn_search.TextAlign = ContentAlignment.MiddleRight;
            btn_search.UseVisualStyleBackColor = false;
            btn_search.Click += btn_search_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(207, 38);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 5;
            label2.Text = "Category:";
            // 
            // cbx_type
            // 
            cbx_type.FormattingEnabled = true;
            cbx_type.Location = new Point(80, 35);
            cbx_type.Name = "cbx_type";
            cbx_type.Size = new Size(108, 29);
            cbx_type.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 38);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 3;
            label1.Text = "Type:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbx_category);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dpk_createdAtEndTime);
            groupBox2.Controls.Add(dpk_createdAtEndDate);
            groupBox2.Controls.Add(dpk_createdAtStartTime);
            groupBox2.Controls.Add(dpk_createdAtStartDate);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cbx_createdBy);
            groupBox2.Controls.Add(tbx_description);
            groupBox2.Controls.Add(tbx_name);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btn_reset);
            groupBox2.Controls.Add(btn_search);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cbx_type);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(399, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1147, 119);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Search";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(248, 79);
            label5.Name = "label5";
            label5.Size = new Size(94, 21);
            label5.TabIndex = 13;
            label5.Text = "Created By:";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(10, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(1557, 136);
            panel1.TabIndex = 4;
            // 
            // ucTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucTransaction";
            Size = new Size(1577, 753);
            Load += ucTransaction_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_transactions).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgv_transactions;
        private Button btn_remove;
        private Button btn_add;
        private ComboBox cbx_category;
        private Label label7;
        private DateTimePicker dpk_createdAtEndTime;
        private DateTimePicker dpk_createdAtEndDate;
        private DateTimePicker dpk_createdAtStartTime;
        private DateTimePicker dpk_createdAtStartDate;
        private Label label6;
        private ComboBox cbx_createdBy;
        private TextBox tbx_description;
        private GroupBox groupBox1;
        private Button btn_modify;
        private TextBox tbx_name;
        private Label label4;
        private Label label3;
        private Button btn_reset;
        private Button btn_search;
        private Label label2;
        private ComboBox cbx_type;
        private Label label1;
        private GroupBox groupBox2;
        private Label label5;
        private Panel panel1;
    }
}
