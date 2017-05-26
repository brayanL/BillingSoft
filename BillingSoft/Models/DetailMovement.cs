using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoft.Models
{
    public class DetailMovement
    {
        public long ID { get; set; }
        public int Type { get; set; } // 0 - entry; 1 - discharge
        public long ProductID { get; set; }
        public long Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public long Stock { get; set; }

        //Navigation Property
        public Product Product { get; set; }

        //To see, wich BillPurchase is bind
        public DetailBillPurchase DetailBillPurchase { get; set; }
    }
}
