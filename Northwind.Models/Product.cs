using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class Product : ProductRecord
    {
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();

        public virtual Supplier Supplier { get; set; }
    }
}
