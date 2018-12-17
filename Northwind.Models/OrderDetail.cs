using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Northwind.Models.Records;

namespace Northwind.Models
{

    [Table("Order Details")]
    public class OrderDetail : OrderDetailRecord
    {
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
