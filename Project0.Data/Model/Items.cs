using System;
using System.Collections.Generic;

namespace Project0.ConosoleApp
{
    public partial class Items
    {
        public Items()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int Sku { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemName { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
