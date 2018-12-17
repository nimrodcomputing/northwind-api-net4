using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models.Records
{


    public class CustomerDemographicRecord
    {
        [Key]
        [StringLength(10)]
        public string CustomerTypeId { get; set; }

        [Column(TypeName = "ntext")]
        public string CustomerDesc { get; set; }

    }
}
