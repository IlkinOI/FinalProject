using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class TourDates
    {
        public int Id { get; set; }
        [NotMapped]
        public string DateFromString { get; set; }
        [NotMapped]
        public string DateToString { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}