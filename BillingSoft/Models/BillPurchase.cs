using System;
using System.ComponentModel.DataAnnotations;

namespace BillingSoft.Models
{
    public class BillPurchase
    {
        public long ID { get; set; }
        public string NumberBill { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        //Foreign Key
        public long SupplierID { get; set; }

        //Navigation Property
        public Supplier Supplier { get; set; }
    }
}
