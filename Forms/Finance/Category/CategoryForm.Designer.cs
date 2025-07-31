namespace Personal_finance_app.Forms
{
    partial class CategoryForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btn_remove = new Button();
            btn_modify = new Button();
            btn_add = new Button();
            panel2 = new Panel();
            dgv_categories = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_categories).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(btn_remove);
            panel1.Controls.Add(btn_modify);
            panel1.Controls.Add(btn_add);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 74);
            panel1.TabIndex = 0;
            // 
            // btn_remove
            // 
            btn_remove.BackColor = SystemColors.GradientActiveCaption;
            btn_remove.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_remove.Image = Properties.Resources.remove;
            btn_remove.ImageAlign = ContentAlignment.MiddleLeft;
            btn_remove.Location = new Point(256, 7);
            btn_remove.Name = "btn_remove";
            btn_remove.Size = new Size(135, 58);
            btn_remove.TabIndex = 2;
            btn_remove.Text = "Remove";
            btn_remove.TextAlign = ContentAlignment.MiddleRight;
            btn_remove.UseVisualStyleBackColor = false;
            btn_remove.Click += btn_remove_Click;
            // 
            // btn_modify
            // 
            btn_modify.BackColor = SystemColors.GradientActiveCaption;
            btn_modify.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_modify.Image = Properties.Resources.modify;
            btn_modify.ImageAlign = ContentAlignment.MiddleLeft;
            btn_modify.Location = new Point(116, 7);
            btn_modify.Name = "btn_modify";
            btn_modify.Size = new Size(132, 58);
            btn_modify.TabIndex = 1;
            btn_modify.Text = "Modify";
            btn_modify.TextAlign = ContentAlignment.MiddleRight;
            btn_modify.UseVisualStyleBackColor = false;
            btn_modify.Click += btn_modify_Click;
            // 
            // btn_add
            // 
            btn_add.BackColor = SystemColors.GradientActiveCaption;
            btn_add.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_add.Image = Properties.Resources.add;
            btn_add.ImageAlign = ContentAlignment.MiddleLeft;
            btn_add.Location = new Point(6, 7);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(104, 58);
            btn_add.TabIndex = 0;
            btn_add.Text = "Add";
            btn_add.TextAlign = ContentAlignment.MiddleRight;
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(dgv_categories);
            panel2.Location = new Point(2, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(1176, 534);
            panel2.TabIndex = 1;
            // 
            // dgv_categories
            // 
            dgv_categories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_categories.Location = new Point(6, 13);
            dgv_categories.Name = "dgv_categories";
            dgv_categories.Size = new Size(1167, 478);
            dgv_categories.TabIndex = 0;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 650);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CategoryForm";
            Text = "CategoryForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_categories).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgv_categories;
        private Button btn_add;
        private Button btn_remove;
        private Button btn_modify;
    }
}