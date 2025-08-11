namespace Personal_finance_app.Views.Transaction
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
            cbx_category = new ComboBox();
            dpk_createdAtStartTime = new DateTimePicker();
            dpk_createdAtStartDate = new DateTimePicker();
            label6 = new Label();
            tbx_description = new TextBox();
            label4 = new Label();
            label3 = new Label();
            openFileDlg = new OpenFileDialog();
            btn_chooseFiles = new Button();
            lv_attachments = new ListView();
            clnNo = new ColumnHeader();
            clnFileName = new ColumnHeader();
            clnFileSize = new ColumnHeader();
            clnExtension = new ColumnHeader();
            label5 = new Label();
            tbx_amount = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 34);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 0;
            label1.Text = "Type:";
            // 
            // tbx_name
            // 
            tbx_name.Font = new Font("Segoe UI", 12F);
            tbx_name.Location = new Point(89, 75);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(409, 29);
            tbx_name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 78);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 3;
            label2.Text = "Name:";
            // 
            // btn_save
            // 
            btn_save.BackColor = SystemColors.GradientActiveCaption;
            btn_save.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_save.Location = new Point(427, 342);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(102, 55);
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
            cbx_type.Size = new Size(161, 29);
            cbx_type.TabIndex = 5;
            // 
            // cbx_category
            // 
            cbx_category.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbx_category.FormattingEnabled = true;
            cbx_category.Location = new Point(384, 29);
            cbx_category.Name = "cbx_category";
            cbx_category.Size = new Size(207, 29);
            cbx_category.TabIndex = 30;
            // 
            // dpk_createdAtStartTime
            // 
            dpk_createdAtStartTime.Font = new Font("Segoe UI", 12F);
            dpk_createdAtStartTime.Format = DateTimePickerFormat.Time;
            dpk_createdAtStartTime.Location = new Point(766, 72);
            dpk_createdAtStartTime.Name = "dpk_createdAtStartTime";
            dpk_createdAtStartTime.Size = new Size(115, 29);
            dpk_createdAtStartTime.TabIndex = 29;
            // 
            // dpk_createdAtStartDate
            // 
            dpk_createdAtStartDate.Font = new Font("Segoe UI", 12F);
            dpk_createdAtStartDate.Format = DateTimePickerFormat.Short;
            dpk_createdAtStartDate.Location = new Point(629, 72);
            dpk_createdAtStartDate.Name = "dpk_createdAtStartDate";
            dpk_createdAtStartDate.Size = new Size(131, 29);
            dpk_createdAtStartDate.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(530, 80);
            label6.Name = "label6";
            label6.Size = new Size(93, 21);
            label6.TabIndex = 27;
            label6.Text = "Created At:";
            // 
            // tbx_description
            // 
            tbx_description.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbx_description.Location = new Point(89, 124);
            tbx_description.Name = "tbx_description";
            tbx_description.Size = new Size(792, 29);
            tbx_description.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 132);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 25;
            label4.Text = "Desc:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(287, 34);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 24;
            label3.Text = "Category:";
            // 
            // openFileDlg
            // 
            openFileDlg.FileName = "openFileDialog1";
            // 
            // btn_chooseFiles
            // 
            btn_chooseFiles.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_chooseFiles.Location = new Point(89, 184);
            btn_chooseFiles.Name = "btn_chooseFiles";
            btn_chooseFiles.Size = new Size(207, 35);
            btn_chooseFiles.TabIndex = 31;
            btn_chooseFiles.Text = "Choose Attachments";
            btn_chooseFiles.UseVisualStyleBackColor = true;
            btn_chooseFiles.Click += btn_chooseFiles_Click;
            // 
            // lv_attachments
            // 
            lv_attachments.Columns.AddRange(new ColumnHeader[] { clnNo, clnFileName, clnFileSize, clnExtension });
            lv_attachments.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lv_attachments.Location = new Point(89, 225);
            lv_attachments.Name = "lv_attachments";
            lv_attachments.Size = new Size(792, 102);
            lv_attachments.TabIndex = 32;
            lv_attachments.UseCompatibleStateImageBehavior = false;
            lv_attachments.View = View.Details;
            // 
            // clnNo
            // 
            clnNo.Text = "No.";
            clnNo.Width = 80;
            // 
            // clnFileName
            // 
            clnFileName.Text = "File Name";
            clnFileName.Width = 450;
            // 
            // clnFileSize
            // 
            clnFileSize.Text = "File Size(kB)";
            clnFileSize.TextAlign = HorizontalAlignment.Center;
            clnFileSize.Width = 150;
            // 
            // clnExtension
            // 
            clnExtension.Text = "Extension";
            clnExtension.TextAlign = HorizontalAlignment.Center;
            clnExtension.Width = 100;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(619, 35);
            label5.Name = "label5";
            label5.Size = new Size(73, 21);
            label5.TabIndex = 34;
            label5.Text = "Amount:";
            // 
            // tbx_amount
            // 
            tbx_amount.Font = new Font("Segoe UI", 12F);
            tbx_amount.Location = new Point(706, 29);
            tbx_amount.Name = "tbx_amount";
            tbx_amount.Size = new Size(175, 29);
            tbx_amount.TabIndex = 33;
            tbx_amount.KeyPress += tbx_amount_KeyPress;
            // 
            // CrudForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 411);
            Controls.Add(label5);
            Controls.Add(tbx_amount);
            Controls.Add(lv_attachments);
            Controls.Add(btn_chooseFiles);
            Controls.Add(cbx_category);
            Controls.Add(dpk_createdAtStartTime);
            Controls.Add(dpk_createdAtStartDate);
            Controls.Add(label6);
            Controls.Add(tbx_description);
            Controls.Add(label4);
            Controls.Add(label3);
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
        private ComboBox cbx_category;
        private DateTimePicker dpk_createdAtStartTime;
        private DateTimePicker dpk_createdAtStartDate;
        private Label label6;
        private TextBox tbx_description;
        private Label label4;
        private Label label3;
        private OpenFileDialog openFileDlg;
        private Button btn_chooseFiles;
        private ListView lv_attachments;
        private ColumnHeader clnFileName;
        private ColumnHeader clnFileSize;
        private ColumnHeader clnExtension;
        private ColumnHeader clnNo;
        private Label label5;
        private TextBox tbx_amount;
    }
}