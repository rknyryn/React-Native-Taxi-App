using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaxiAppWebApi.Model
{
    [Table("TaxiZone")]
    public partial class TaxiZone
    {
        [Key]
        [Column("LocationID")]
        public int LocationId { get; set; }
        [StringLength(50)]
        public string Borough { get; set; }
        [StringLength(50)]
        public string Zone { get; set; }
        [StringLength(50)]
        public string ServiceZone { get; set; }
    }
}
