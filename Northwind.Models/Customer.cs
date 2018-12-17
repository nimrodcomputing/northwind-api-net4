using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class Customer:CustomerRecord
    {
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; } = new HashSet<CustomerDemographic>();
    }
}
