using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class CustomerDemographic : CustomerDemographicRecord
    {
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    }
}
