namespace Personal_finance_app.Views
{
    partial class ucCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCategory));
            dgv_categories = new DataGridView();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            btn_reset = new Button();
            btn_search = new Button();
            tbx_name = new TextBox();
            label2 = new Label();
            cbx_type = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btn_remove = new Button();
            btn_add = new Button();
            btn_modify = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_categories).BeginInit();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_categories
            // 
            dgv_categories.AllowUserToAddRows = false;
            dgv_categories.AllowUserToDeleteRows = false;
            dgv_categories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_categories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_categories.Location = new Point(6, 12);
            dgv_categories.Name = "dgv_categories";
            dgv_categories.ReadOnly = true;
            dgv_categories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_categories.Size = new Size(1232, 624);
            dgv_categories.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1250, 103);
            panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_reset);
            groupBox2.Controls.Add(btn_search);
            groupBox2.Controls.Add(tbx_name);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cbx_type);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(490, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(742, 83);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Search";
            // 
            // btn_reset
            // 
            btn_reset.BackColor = SystemColors.Info;
            btn_reset.Font = new Font("Segoe UI", 12F);
            btn_reset.Image = (Image)resources.GetObject("btn_reset.Image");
            btn_reset.ImageAlign = ContentAlignment.MiddleLeft;
            btn_reset.Location = new Point(618, 29);
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
            btn_search.Location = new Point(505, 29);
            btn_search.Name = "btn_search";
            btn_search.Padding = new Padding(5, 0, 5, 0);
            btn_search.Size = new Size(107, 37);
            btn_search.TabIndex = 7;
            btn_search.Text = "Search";
            btn_search.TextAlign = ContentAlignment.MiddleRight;
            btn_search.UseVisualStyleBackColor = false;
            btn_search.Click += btn_search_Click;
            // 
            // tbx_name
            // 
            tbx_name.Location = new Point(308, 34);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(172, 29);
            tbx_name.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(238, 37);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 5;
            label2.Text = "Name:";
            // 
            // cbx_type
            // 
            cbx_type.FormattingEnabled = true;
            cbx_type.Location = new Point(79, 34);
            cbx_type.Name = "cbx_type";
            cbx_type.Size = new Size(138, 29);
            cbx_type.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 37);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 3;
            label1.Text = "Type:";
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
            panel2.Controls.Add(dgv_categories);
            panel2.Location = new Point(3, 121);
            panel2.Name = "panel2";
            panel2.Size = new Size(1250, 639);
            panel2.TabIndex = 3;
            // 
            // ucCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ucCategory";
            Size = new Size(1256, 777);
            ((System.ComponentModel.ISupportInitialize)dgv_categories).EndInit();
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_categories;
        private Panel panel1;
        private GroupBox groupBox2;
        private Button btn_reset;
        private Button btn_search;
        private TextBox tbx_name;
        private Label label2;
        private ComboBox cbx_type;
        private Label label1;
        private GroupBox groupBox1;
        private Button btn_remove;
        private Button btn_add;
        private Button btn_modify;
        private Panel panel2;
    }
}
