using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models.Records
{

    public class CategoryRecord
    {

        [Column("CategoryID")]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }

    public class CategoryRecordFull : CategoryRecord
    {
        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }
    }
}
