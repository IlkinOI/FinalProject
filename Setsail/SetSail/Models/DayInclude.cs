using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class DayInclude
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Feature { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
    }
}