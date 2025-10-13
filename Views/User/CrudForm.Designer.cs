namespace Personal_finance_app.Views.User
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
            tbx_username = new TextBox();
            label2 = new Label();
            btn_save = new Button();
            cbx_role = new ComboBox();
            label3 = new Label();
            tbx_password = new TextBox();
            label4 = new Label();
            tbx_confirmPassword = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(339, 20);
            label1.Name = "label1";
            label1.Size = new Size(47, 21);
            label1.TabIndex = 0;
            label1.Text = "Role:";
            // 
            // tbx_username
            // 
            tbx_username.Font = new Font("Segoe UI", 12F);
            tbx_username.Location = new Point(111, 12);
            tbx_username.Name = "tbx_username";
            tbx_username.Size = new Size(161, 29);
            tbx_username.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 20);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 3;
            label2.Text = "Username:";
            // 
            // btn_save
            // 
            btn_save.BackColor = SystemColors.GradientActiveCaption;
            btn_save.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_save.Location = new Point(265, 111);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(102, 57);
            btn_save.TabIndex = 4;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // cbx_role
            // 
            cbx_role.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbx_role.FormattingEnabled = true;
            cbx_role.Location = new Point(394, 12);
            cbx_role.Name = "cbx_role";
            cbx_role.Size = new Size(166, 29);
            cbx_role.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 68);
            label3.Name = "label3";
            label3.Size = new Size(83, 21);
            label3.TabIndex = 7;
            label3.Text = "Password:";
            // 
            // tbx_password
            // 
            tbx_password.Font = new Font("Segoe UI", 12F);
            tbx_password.Location = new Point(111, 60);
            tbx_password.Name = "tbx_password";
            tbx_password.PasswordChar = '*';
            tbx_password.Size = new Size(161, 29);
            tbx_password.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(292, 68);
            label4.Name = "label4";
            label4.Size = new Size(98, 21);
            label4.TabIndex = 9;
            label4.Text = "Confirm Pw:";
            // 
            // tbx_confirmPassword
            // 
            tbx_confirmPassword.Font = new Font("Segoe UI", 12F);
            tbx_confirmPassword.Location = new Point(394, 60);
            tbx_confirmPassword.Name = "tbx_confirmPassword";
            tbx_confirmPassword.PasswordChar = '*';
            tbx_confirmPassword.Size = new Size(166, 29);
            tbx_confirmPassword.TabIndex = 8;
            // 
            // CrudForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 183);
            Controls.Add(label4);
            Controls.Add(tbx_confirmPassword);
            Controls.Add(label3);
            Controls.Add(tbx_password);
            Controls.Add(cbx_role);
            Controls.Add(btn_save);
            Controls.Add(label2);
            Controls.Add(tbx_username);
            Controls.Add(label1);
            Name = "CrudForm";
            Text = "CrudForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbx_username;
        private Label label2;
        private Button btn_save;
        private ComboBox cbx_role;
        private Label label3;
        private TextBox tbx_password;
        private Label label4;
        private TextBox tbx_confirmPassword;
    }
}