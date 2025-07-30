namespace Personal_finance_app.Forms
{
    partial class LoginForm
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
            tbx_username = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbx_password = new TextBox();
            btn_login = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tbx_username
            // 
            tbx_username.Font = new Font("Segoe UI", 11.25F);
            tbx_username.Location = new Point(122, 48);
            tbx_username.Name = "tbx_username";
            tbx_username.Size = new Size(209, 27);
            tbx_username.TabIndex = 0;
            tbx_username.TextChanged += tbx_username_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(33, 55);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 106);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // tbx_password
            // 
            tbx_password.Location = new Point(122, 99);
            tbx_password.Name = "tbx_password";
            tbx_password.PasswordChar = '*';
            tbx_password.Size = new Size(209, 27);
            tbx_password.TabIndex = 3;
            tbx_password.TextChanged += tbx_password_TextChanged;
            tbx_password.KeyDown += tbx_password_KeyDown;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(122, 156);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(209, 35);
            btn_login.TabIndex = 4;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_login);
            groupBox1.Controls.Add(tbx_password);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbx_username);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(19, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(365, 223);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 253);
            Controls.Add(groupBox1);
            Name = "LoginForm";
            Text = "PFM";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbx_username;
        private Label label1;
        private Label label2;
        private TextBox tbx_password;
        private Button btn_login;
        private GroupBox groupBox1;
    }
}