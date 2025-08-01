using Personal_finance_app.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_finance_app.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public TypeEnum Type { get; set; }
        public string TypeText
        {
            get
            {
                return Enum.GetName(typeof(TypeEnum), this.Type);
            }
        }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
