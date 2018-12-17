using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Resources
{

    public class OrderDetailResource : OrderDetailRecord
    {
        public string Product { get; set; }

        public string Category { get; set; }
    }
}
