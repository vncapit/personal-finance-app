namespace Personal_finance_app.Views.Report
{
    partial class ucReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReport));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            btn_export = new Button();
            label1 = new Label();
            dpk_monthReport = new DateTimePicker();
            chart_income_pie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart_expense_pie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label2 = new Label();
            label3 = new Label();
            chart_expense_column = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart_income_column = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgv_incomes = new DataGridView();
            dgv_expenses = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart_income_pie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart_expense_pie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart_expense_column).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart_income_column).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_incomes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_expenses).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1647, 97);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btn_export);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dpk_monthReport);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(15, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1618, 71);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search";
            // 
            // btn_export
            // 
            btn_export.BackColor = SystemColors.Info;
            btn_export.Image = (Image)resources.GetObject("btn_export.Image");
            btn_export.ImageAlign = ContentAlignment.MiddleLeft;
            btn_export.Location = new Point(189, 21);
            btn_export.Name = "btn_export";
            btn_export.Padding = new Padding(10, 0, 0, 0);
            btn_export.Size = new Size(127, 39);
            btn_export.TabIndex = 5;
            btn_export.Text = "Export";
            btn_export.UseVisualStyleBackColor = false;
            btn_export.Click += btn_export_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 31);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 4;
            label1.Text = "Month:";
            // 
            // dpk_monthReport
            // 
            dpk_monthReport.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dpk_monthReport.CustomFormat = "MM-yyyy";
            dpk_monthReport.Format = DateTimePickerFormat.Custom;
            dpk_monthReport.Location = new Point(70, 26);
            dpk_monthReport.Name = "dpk_monthReport";
            dpk_monthReport.Size = new Size(83, 27);
            dpk_monthReport.TabIndex = 0;
            dpk_monthReport.ValueChanged += dpk_monthReport_ValueChanged;
            // 
            // chart_income_pie
            // 
            chartArea1.Name = "ChartArea1";
            chart_income_pie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart_income_pie.Legends.Add(legend1);
            chart_income_pie.Location = new Point(3, 3);
            chart_income_pie.Name = "chart_income_pie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "IncomePie";
            chart_income_pie.Series.Add(series1);
            chart_income_pie.Size = new Size(344, 257);
            chart_income_pie.TabIndex = 1;
            chart_income_pie.Text = "chart1";
            // 
            // chart_expense_pie
            // 
            chartArea2.Name = "ChartArea1";
            chart_expense_pie.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart_expense_pie.Legends.Add(legend2);
            chart_expense_pie.Location = new Point(791, 3);
            chart_expense_pie.Name = "chart_expense_pie";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "ExpensePie";
            chart_expense_pie.Series.Add(series2);
            chart_expense_pie.Size = new Size(342, 257);
            chart_expense_pie.TabIndex = 2;
            chart_expense_pie.Text = "sdfgsdf";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(273, 386);
            label2.Name = "label2";
            label2.Size = new Size(173, 21);
            label2.TabIndex = 3;
            label2.Text = "Chart of Income ratios";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(1067, 386);
            label3.Name = "label3";
            label3.Size = new Size(178, 21);
            label3.TabIndex = 4;
            label3.Text = "Chart of Expense ratios";
            // 
            // chart_expense_column
            // 
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            chart_expense_column.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart_expense_column.Legends.Add(legend3);
            chart_expense_column.Location = new Point(1136, 3);
            chart_expense_column.Name = "chart_expense_column";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart_expense_column.Series.Add(series3);
            chart_expense_column.Size = new Size(458, 257);
            chart_expense_column.TabIndex = 6;
            chart_expense_column.Text = "sdfgsdf";
            // 
            // chart_income_column
            // 
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.Name = "ChartArea1";
            chart_income_column.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart_income_column.Legends.Add(legend4);
            chart_income_column.Location = new Point(350, 3);
            chart_income_column.Name = "chart_income_column";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chart_income_column.Series.Add(series4);
            chart_income_column.Size = new Size(435, 257);
            chart_income_column.TabIndex = 5;
            chart_income_column.Text = "chart1";
            // 
            // dgv_incomes
            // 
            dgv_incomes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_incomes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_incomes.Dock = DockStyle.Fill;
            dgv_incomes.Location = new Point(3, 3);
            dgv_incomes.MultiSelect = false;
            dgv_incomes.Name = "dgv_incomes";
            dgv_incomes.ReadOnly = true;
            dgv_incomes.RowHeadersVisible = false;
            dgv_incomes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_incomes.Size = new Size(817, 350);
            dgv_incomes.TabIndex = 7;
            // 
            // dgv_expenses
            // 
            dgv_expenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_expenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_expenses.Dock = DockStyle.Fill;
            dgv_expenses.Location = new Point(826, 3);
            dgv_expenses.Name = "dgv_expenses";
            dgv_expenses.RowHeadersVisible = false;
            dgv_expenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_expenses.Size = new Size(818, 350);
            dgv_expenses.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgv_incomes, 0, 0);
            tableLayoutPanel1.Controls.Add(dgv_expenses, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1647, 356);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(chart_income_pie);
            panel2.Controls.Add(chart_expense_column);
            panel2.Controls.Add(chart_income_column);
            panel2.Controls.Add(chart_expense_pie);
            panel2.Location = new Point(3, 108);
            panel2.Name = "panel2";
            panel2.Size = new Size(1647, 269);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Location = new Point(3, 418);
            panel3.Name = "panel3";
            panel3.Size = new Size(1647, 356);
            panel3.TabIndex = 11;
            // 
            // ucReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ucReport";
            Size = new Size(1653, 777);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart_income_pie).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart_expense_pie).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart_expense_column).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart_income_column).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_incomes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_expenses).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DateTimePicker dpk_monthReport;
        private GroupBox groupBox1;
        private Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_income_pie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_expense_pie;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_expense_column;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_income_column;
        private DataGridView dgv_incomes;
        private DataGridView dgv_expenses;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private Button btn_export;
    }
}
