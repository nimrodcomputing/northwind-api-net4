using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Models
{

    public class Employee : EmployeeRecordFull
    {
        public virtual ICollection<Employee> Reports { get; set; } = new HashSet<Employee>();

        public virtual Employee Manager { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public virtual ICollection<Territory> Territories { get; set; } = new HashSet<Territory>();
    }
}
