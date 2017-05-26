using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoft.Models
{
    public class Supplier
    {
        public long ID { get; set; }
        public string Ruc { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string NameContactPerson { get; set; }
        public string SkypeUserContactPerson { get; set; }

        //Navigation Property
        public ICollection<BillPurchase> BillPurchases { get; set; }

    }
}
