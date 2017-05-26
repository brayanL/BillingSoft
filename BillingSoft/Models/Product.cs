using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoft.Models
{
    public class Product
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Utility { get; set; }
        public decimal SalePrice { get; set; }
        public long Stock { get; set; }
        public bool State { get; set; } //true: active, false: inactive

        //Foreign Key
        public long CategoryID { get; set; }

        //Navigation Property
        public Category Category { get; set; }
    }
}
