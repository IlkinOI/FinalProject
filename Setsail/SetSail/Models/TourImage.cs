using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class TourImage
    {
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string ImageName { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}