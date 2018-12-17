using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Resources
{

    public class OrderResource : OrderRecord
    {
        public string Customer { get; set; }

        public string Representative { get; set; }

        public string Shipper { get; set; }
    }

    public class OrderResourceFull : OrderResource
    {
        public virtual ICollection<OrderDetailResource> OrderDetails { get; set; }
    }
}
