namespace Personal_finance_app.Forms
{
    partial class MainForm
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
            treev_menus = new TreeView();
            pnl_placeholder = new Panel();
            panel2 = new Panel();
            lbl_menu = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(treev_menus);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 777);
            panel1.TabIndex = 0;
            // 
            // treev_menus
            // 
            treev_menus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treev_menus.BackColor = SystemColors.GradientInactiveCaption;
            treev_menus.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            treev_menus.Location = new Point(11, 12);
            treev_menus.Name = "treev_menus";
            treev_menus.Size = new Size(232, 765);
            treev_menus.TabIndex = 0;
            treev_menus.NodeMouseDoubleClick += treev_menus_NodeMouseDoubleClick;
            // 
            // pnl_placeholder
            // 
            pnl_placeholder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_placeholder.BackColor = SystemColors.ControlLight;
            pnl_placeholder.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnl_placeholder.Location = new Point(257, 52);
            pnl_placeholder.Name = "pnl_placeholder";
            pnl_placeholder.Size = new Size(1598, 724);
            pnl_placeholder.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Info;
            panel2.Controls.Add(lbl_menu);
            panel2.Location = new Point(257, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1598, 46);
            panel2.TabIndex = 2;
            // 
            // lbl_menu
            // 
            lbl_menu.AutoSize = true;
            lbl_menu.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_menu.Location = new Point(14, 6);
            lbl_menu.Name = "lbl_menu";
            lbl_menu.Size = new Size(77, 32);
            lbl_menu.TabIndex = 0;
            lbl_menu.Text = "Menu";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1861, 777);
            Controls.Add(panel2);
            Controls.Add(pnl_placeholder);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "Personal Finance Management";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TreeView treev_menus;
        private Panel pnl_placeholder;
        private Panel panel2;
        private Label lbl_menu;
    }
}