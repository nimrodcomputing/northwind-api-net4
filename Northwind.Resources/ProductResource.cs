using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Resources
{

    public class ProductResource : ProductRecord
    {
        public string Category { get; set; }

        public string Supplier { get; set; }
    }
}
