using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_finance_app.Helpers
{
    public static class CsvHelper
    {
        public static string DataGridViewToCsv(DataGridView dgv, int[]? hiddenIndexes = null)
        {
            hiddenIndexes ??= Array.Empty<int>();
            StringBuilder sb = new StringBuilder();
            var headerCsv = string.Join(",", dgv.Columns.Cast<DataGridViewColumn>().Where(cl => !hiddenIndexes.Contains(cl.Index) && cl.Visible).Select(cl => cl.HeaderText));
            sb.AppendLine(headerCsv);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                var rowCsv = string.Join(',', row.Cells.Cast<DataGridViewCell>().Where(cell => !hiddenIndexes.Contains(cell.ColumnIndex) && cell.OwningColumn.Visible).Select(cell => Escape(cell.Value?.ToString() ?? "")));
                sb.AppendLine(rowCsv);
            }
            return sb.ToString();
        }

        private static string Escape(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if(value.Contains(",") || value.Contains('"') || value.Contains('\n'))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }
    }
}
