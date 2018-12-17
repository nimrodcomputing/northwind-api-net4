using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Northwind.Models.Records;

namespace Northwind.Models
{

    [Table("Region")]
    public class Region : RegionRecord
    {
        public virtual ICollection<Territory> Territories { get; set; } = new HashSet<Territory>();
    }
}
