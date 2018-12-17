using System;
using System.Collections.Generic;
using Northwind.Models.Records;

namespace Northwind.Resources
{
    public class EmployeeResource : EmployeeRecord
    {
        public string Manager { get; set; }
    }
}
