using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class Category : CategoryRecordFull
    {
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
