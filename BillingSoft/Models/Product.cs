using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BillingSoft.Models
{
    public class Product
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        //[RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?", ErrorMessage = "Ingrese un Numero valido")]
        //[DataType(DataType.Currency)]
        public decimal CostPrice { get; set; }
        //[RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?", ErrorMessage = "Ingrese un Numero valido")]
        //[DataType(DataType.Currency)]
        public decimal Utility { get; set; }
        //[RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?", ErrorMessage = "Ingrese un Numero valido")]
        //[DataType(DataType.Currency)]
        public decimal SalePrice { get; set; }
        public long Stock { get; set; }
        public bool State { get; set; } //true: active, false: inactive

        //Foreign Key
        public long CategoryID { get; set; }

        //Navigation Property
        public Category Category { get; set; }
    }
}
