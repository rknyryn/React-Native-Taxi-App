using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaxiAppWebApi.Model
{
    public partial class TaxiTripDatum
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("DOLocationID")]
        public int DolocationId { get; set; }
        [Column("PULocationID")]
        public int PulocationId { get; set; }
        public int PassengerCount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TripDistance { get; set; }
        [Column(TypeName = "date")]
        public DateTime PickupDatetime { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DropoffDatetime { get; set; }
    }
}
