using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models.Records
{

    public class TerritoryRecord
    {
        [StringLength(20)]
        [Column("TerritoryID")]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }
    }
}
