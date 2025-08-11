using Personal_finance_app.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_finance_app.Models
{
    public class TransactionModel
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
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }
        public string Attachments { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}