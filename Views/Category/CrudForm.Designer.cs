namespace Personal_finance_app.Views.Category
{
    partial class CrudForm
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
            label1 = new Label();
            tbx_name = new TextBox();
            label2 = new Label();
            btn_save = new Button();
            cbx_type = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 37);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 0;
            label1.Text = "Type:";
            // 
            // tbx_name
            // 
            tbx_name.Font = new Font("Segoe UI", 12F);
            tbx_name.Location = new Point(354, 29);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(209, 29);
            tbx_name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(285, 37);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 3;
            label2.Text = "Name:";
            // 
            // btn_save
            // 
            btn_save.BackColor = SystemColors.GradientActiveCaption;
            btn_save.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_save.Location = new Point(254, 96);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(102, 57);
            btn_save.TabIndex = 4;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // cbx_type
            // 
            cbx_type.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbx_type.FormattingEnabled = true;
            cbx_type.Location = new Point(89, 29);
            cbx_type.Name = "cbx_type";
            cbx_type.Size = new Size(150, 29);
            cbx_type.TabIndex = 5;
            // 
            // CrudForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 180);
            Controls.Add(cbx_type);
            Controls.Add(btn_save);
            Controls.Add(label2);
            Controls.Add(tbx_name);
            Controls.Add(label1);
            Name = "CrudForm";
            Text = "CrudForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbx_name;
        private Label label2;
        private Button btn_save;
        private ComboBox cbx_type;
    }
}