using System;
using System.Collections.Generic;

namespace Project0.ConosoleApp
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            OrderHist = new HashSet<OrderHist>();
        }

        public int StoreId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderHist> OrderHist { get; set; }
    }
}
