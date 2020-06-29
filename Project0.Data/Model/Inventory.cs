using System;
using System.Collections.Generic;

namespace Project0.ConosoleApp
{
    public partial class Inventory
    {
        public int StoreId { get; set; }
        public int Sku { get; set; }
        public int? Stock { get; set; }

        public virtual Items SkuNavigation { get; set; }
        public virtual Store Store { get; set; }
    }
}
