using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoft.Models
{
    public class DetailBillPurchase
    {
        public long ID { get; set; }
        //One to One RelationShip
        public long DetailMovementID { get; set; }

        //Foreign
        public long BillPurchaseID { get; set; }

        ////Nagigation Property 
        public BillPurchase BillPurchase { get; set; }
    }
}
