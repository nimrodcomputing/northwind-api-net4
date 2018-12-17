using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class Order : OrderRecord
    {
        public virtual Customer Customer { get; set; }

        public virtual Employee Representative { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();

        public virtual Shipper Shipper { get; set; }
    }
}
