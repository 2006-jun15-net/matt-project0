using System;
using System.Collections.Generic;

namespace Project0.ConosoleApp
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int? ItemQty { get; set; }
        public int ItemId { get; set; }

        public virtual OrderHist Order { get; set; }
    }
}
