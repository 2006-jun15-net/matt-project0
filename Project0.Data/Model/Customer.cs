using System;
using System.Collections.Generic;

namespace Project0.ConosoleApp
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHist = new HashSet<OrderHist>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public virtual ICollection<OrderHist> OrderHist { get; set; }

    }
}
