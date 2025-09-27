using Microsoft.Data.Sqlite;
using Personal_finance_app.Helpers;
using Personal_finance_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
                            transaction.CreatedAt = reader["CREATED_AT"].ToString() ?? "";
                            transaction.UpdatedAt = reader["UPDATED_AT"].ToString() ?? "";
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
        }
    }
}
