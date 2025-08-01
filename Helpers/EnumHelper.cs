using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_finance_app.Helpers
{
    public class ComboBoxItem
    {
        public ComboBoxItem(string name, int value) {
            this.Name = name;
            this.Value = value;
        }
        public string Name { set; get; }
        public int Value { set; get; }
    }
    public static class EnumHelper<TEnum>
    {
        public static List<ComboBoxItem> GetComboBoxItems(bool addDefault = true)
        {
            List<ComboBoxItem> results = new List<ComboBoxItem>();
            if (addDefault) results.Add(new ComboBoxItem("", -1));
            var enumValues = Enum.GetValues(typeof(TEnum));
            foreach (var value in enumValues)
            {
                var item = new ComboBoxItem(value.ToString(), (int)value);
                results.Add(item);
            }
            return results;
        } 
    }
}
