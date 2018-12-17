using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class Supplier : SupplierRecord
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
