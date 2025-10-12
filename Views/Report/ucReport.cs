using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Microsoft.Data.Sqlite;
using Personal_finance_app.Helpers;
using Personal_finance_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using Image = iText.Layout.Element.Image;
using iText.Layout.Borders;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;


namespace Personal_finance_app.Views.Report
{
    public partial class ucReport : UserControl
    {
        public ucReport()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.dpk_monthReport.Format = DateTimePickerFormat.Custom;
            this.dpk_monthReport.CustomFormat = "MM/yyyy";
            dpk_monthReport.ShowUpDown = true;

            this.InitReport();
        }

        private void dpk_monthReport_ValueChanged(object sender, EventArgs e)
        {
            this.InitReport();
        }

        private void InitReport()
        {
            this.chart_income_pie.Series.Clear();
            this.chart_expense_pie.Series.Clear();
            this.chart_income_column.Series.Clear();
            this.chart_expense_column.Series.Clear();

            chart_income_column.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;
            chart_expense_column.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;

            string month = this.dpk_monthReport.Value.ToString("yyyyMM");
            List<TransactionModel> transactions = new List<TransactionModel>();
            // Income pie:
            using (var conn = DbHelper.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT t.ID, t.NAME, t.CATEGORY_ID, t.AMOUNT, t.DESC, t.CREATED_AT, t.UPDATED_AT, c.TYPE, c.NAME as CATEGORY_NAME
                                        FROM TRANSACTIONS t INNER JOIN CATEGORIES c ON t.CATEGORY_ID = c.ID WHERE t.CREATED_AT LIKE @CREATED_AT_MONTH";
                    cmd.Parameters.AddWithValue("CREATED_AT_MONTH", $"{month}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TransactionModel transaction = new TransactionModel();
                            transaction.Id = Convert.ToInt32(reader["ID"]);
                            transaction.Amount = Convert.ToDecimal(reader["AMOUNT"]);
                            transaction.Name = reader["NAME"].ToString() ?? "";
                            transaction.Desc = reader["DESC"].ToString() ?? "";
                            transaction.CreatedAt = DateTime.ParseExact(reader["CREATED_AT"].ToString(), "yyyyMMddHHmmss", null).ToString("yyyy-MM-dd HH:mm:ss");
                            transaction.UpdatedAt = DateTime.ParseExact(reader["UPDATED_AT"].ToString(), "yyyyMMddHHmmss", null).ToString("yyyy-MM-dd HH:mm:ss");
                            transaction.Type = (Enums.TypeEnum)Convert.ToInt32(reader["TYPE"]);
                            transaction.CategoryName = reader["CATEGORY_NAME"].ToString() ?? "";
                            transaction.CategoryId = Convert.ToInt32(reader["CATEGORY_ID"]);
                            transactions.Add(transaction);
                        }
                    }
                }
            }

            var incomes = transactions.FindAll(t => t.Type == Enums.TypeEnum.Income);
            var expenses = transactions.FindAll(t => t.Type == Enums.TypeEnum.Expense);
            var totalIncome = incomes.Sum(i => i.Amount);
            var totalExpense = expenses.Sum(e => e.Amount);
            var incomeByCategory = incomes.GroupBy(i => i.CategoryName).Select(g => new { Category = g.Key, Total = g.Sum(i => i.Amount), Percent = (int)Math.Round(g.Sum(i => i.Amount) * 100 / totalIncome) });
            var expenseByCategory = expenses.GroupBy(e => e.CategoryName).Select(g => new { Category = g.Key, Total = g.Sum(i => i.Amount), Percent = (int)Math.Round(g.Sum(i => i.Amount) * 100 / totalExpense) });

            var incomePieSeries = new Series { ChartType = SeriesChartType.Pie, Name = "Incomes Pie" };
            var incomeColumnSeries = new Series { ChartType = SeriesChartType.Column, Name = "Incomes" };
            incomeColumnSeries.XValueType = ChartValueType.String;
            incomeColumnSeries.IsXValueIndexed = true;
            incomeColumnSeries.IsValueShownAsLabel = true;

            foreach (var income in incomeByCategory)
            {
                var p = incomePieSeries.Points.AddXY(income.Category, income.Total);
                incomePieSeries.Points[p].Label = $"{income.Category} {income.Percent}%";
                incomePieSeries.Points[p].LegendText = income.Category;
                incomeColumnSeries.Points.AddXY(income.Category, income.Total);
            }
            chart_income_pie.Series.Add(incomePieSeries);
            chart_income_column.Series.Add(incomeColumnSeries);

            var expensePieSeries = new Series { ChartType = SeriesChartType.Pie, Name = "Expenses Pie" };
            var expenseColumnSeries = new Series { ChartType = SeriesChartType.Column, Name = "Expenses" };
            expenseColumnSeries.XValueType = ChartValueType.String;
            expenseColumnSeries.IsXValueIndexed = true;
            expenseColumnSeries.IsValueShownAsLabel = true;

            foreach (var expense in expenseByCategory)
            {
                var p = expensePieSeries.Points.AddXY(expense.Category, expense.Total);
                expensePieSeries.Points[p].Label = $"{expense.Category} {expense.Percent}%";
                expensePieSeries.Points[p].LegendText = expense.Category;
                expenseColumnSeries.Points.AddXY(expense.Category, expense.Total);

            }
            chart_expense_pie.Series.Add(expensePieSeries);
            chart_expense_column.Series.Add(expenseColumnSeries);

            // datagridview:
            this.dgv_incomes.DataSource = incomes.Select(i => new { i.Name, i.CategoryName, i.Amount, i.Desc, i.CreatedAt }).ToList();
            this.dgv_expenses.DataSource = expenses.Select(i => new { i.Name, i.CategoryName, i.Amount, i.Desc, i.CreatedAt }).ToList();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            var month = this.dpk_monthReport.Value.ToString("MMMM");
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var outputPath = System.IO.Path.Combine(desktop, $"{month}_report.pdf");

            using var writer = new PdfWriter(outputPath);
            using var pdf = new PdfDocument(writer);
            var doc = new Document(pdf, PageSize.A4);
            doc.SetMargins(20, 20, 20, 20);

            // Header
            var header = new Paragraph($"{month} Transactions Report").SimulateBold()
                .SetFontSize(20)
                .SetFontColor(ColorConstants.BLUE).SetMarginBottom(5);
            doc.Add(header);

            var incomeTitle = new Paragraph().Add($"{month} Incomes").SimulateBold().SetFontSize(12);
            doc.Add(incomeTitle);

            // table
            var incomeTable = new Table(UnitValue.CreatePercentArray(new float[] { 2,2,1,3,2 })).UseAllAvailableWidth()
                .SetTextAlignment(TextAlignment.CENTER);
            incomeTable.AddHeaderCell(new Cell().Add(new Paragraph("Name")).SimulateBold());
            incomeTable.AddHeaderCell(new Cell().Add(new Paragraph("Category")).SimulateBold());
            incomeTable.AddHeaderCell(new Cell().Add(new Paragraph("Amount")).SimulateBold());
            incomeTable.AddHeaderCell(new Cell().Add(new Paragraph("Description")).SimulateBold());
            incomeTable.AddHeaderCell(new Cell().Add(new Paragraph("Created At")).SimulateBold());
            incomeTable.SetFontSize(9);

            for (int i = 0; i < dgv_incomes.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_incomes.Rows[i].Cells.Count; j++)
                {
                    incomeTable.AddCell(dgv_incomes.Rows[i].Cells[j].Value.ToString());
                }
            }
            doc.Add(incomeTable);

            var incomeChartLayoutTable = new Table(UnitValue.CreatePercentArray(new float[] { 45,55 })).UseAllAvailableWidth().SetMarginTop(5);
            using (var chartImg = new MemoryStream())
            {
                chart_income_pie.SaveImage(chartImg, ChartImageFormat.Png);
                incomeChartLayoutTable.AddCell(
                    new Cell()
                    .SetHeight(140)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Image(ImageDataFactory.Create(chartImg.ToArray())).SetAutoScale(true).SetHorizontalAlignment(HorizontalAlignment.CENTER))
                    .SetBorder(Border.NO_BORDER));
            }

            using (var chartImg = new MemoryStream())
            {
                chart_income_column.SaveImage(chartImg, ChartImageFormat.Png);
                incomeChartLayoutTable.AddCell(
                    new Cell()
                    .SetHeight(140)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Image(ImageDataFactory.Create(chartImg.ToArray())).SetAutoScale(true).SetHorizontalAlignment(HorizontalAlignment.CENTER))
                    .SetBorder(Border.NO_BORDER));
            }

            doc.Add(incomeChartLayoutTable);

            // expenses
            var expenseTitle = new Paragraph().Add($"{month} Expenses").SimulateBold().SetFontSize(12);
            doc.Add(expenseTitle);

            var expenseTable = new Table(UnitValue.CreatePercentArray(new float[] { 2, 2, 1, 3, 2 })).UseAllAvailableWidth()
                .SetTextAlignment(TextAlignment.CENTER);
            expenseTable.AddHeaderCell(new Cell().Add(new Paragraph("Name")).SimulateBold());
            expenseTable.AddHeaderCell(new Cell().Add(new Paragraph("Category")).SimulateBold());
            expenseTable.AddHeaderCell(new Cell().Add(new Paragraph("Amount")).SimulateBold());
            expenseTable.AddHeaderCell(new Cell().Add(new Paragraph("Description")).SimulateBold());
            expenseTable.AddHeaderCell(new Cell().Add(new Paragraph("Created At")).SimulateBold());
            expenseTable.SetFontSize(9);

            for (int i = 0; i < dgv_expenses.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_expenses.Rows[i].Cells.Count; j++)
                {
                    expenseTable.AddCell(dgv_expenses.Rows[i].Cells[j].Value.ToString());
                }
            }
            doc.Add(expenseTable);

            var expenseChartLayoutTable = new Table(UnitValue.CreatePercentArray(new float[] { 45, 55 })).UseAllAvailableWidth().SetMarginTop(5);
            using (var chartImg = new MemoryStream())
            {
                chart_expense_pie.SaveImage(chartImg, ChartImageFormat.Png);
                expenseChartLayoutTable.AddCell(
                    new Cell()
                    .SetHeight(140)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Image(ImageDataFactory.Create(chartImg.ToArray())).SetAutoScale(true).SetHorizontalAlignment(HorizontalAlignment.CENTER))
                    .SetBorder(Border.NO_BORDER));
            }

            using (var chartImg = new MemoryStream())
            {
                chart_expense_column.SaveImage(chartImg, ChartImageFormat.Png);
                expenseChartLayoutTable.AddCell(
                    new Cell()
                    .SetHeight(140)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Image(ImageDataFactory.Create(chartImg.ToArray())).SetAutoScale(true).SetHorizontalAlignment(HorizontalAlignment.CENTER))
                    .SetBorder(Border.NO_BORDER));
            }

            doc.Add(expenseChartLayoutTable);

        }
    }
}
