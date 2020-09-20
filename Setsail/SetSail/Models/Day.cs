using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Day
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Title { get; set; }
        [Required, MaxLength(300)]
        public string Consist { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public List<DayInclude> DayIncludes { get; set; }
    }
}