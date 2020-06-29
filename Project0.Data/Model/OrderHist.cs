using System;
using System.Collections.Generic;

namespace Project0.ConosoleApp
{
    public partial class OrderHist
    {
        public OrderHist()
        {
            Orders = new HashSet<Orders>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int FromStore { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store FromStoreNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
