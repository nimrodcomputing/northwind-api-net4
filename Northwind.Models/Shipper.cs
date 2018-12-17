using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class Shipper : ShipperRecord
    {
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
