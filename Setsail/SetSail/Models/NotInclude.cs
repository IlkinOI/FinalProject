using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class NotInclude
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Feature { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}