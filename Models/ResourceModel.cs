using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_finance_app.Models
{
    public class ResourceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public string CreatedAt { get; set; }
        public string Extension { get; set; }
    }
}
