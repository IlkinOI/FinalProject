using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class TourDates
    {
        public int Id { get; set; }
        [NotMapped]
        public string DateFroms { get; set; }
        [NotMapped]
        public string DateTos { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [Required, Column(TypeName = "tinyint")]
        public byte TicketsNum { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}