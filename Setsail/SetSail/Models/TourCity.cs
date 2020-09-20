using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class TourCity
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string History { get; set; }
        [Required, MaxLength(500)]
        public string Map { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public List<Tour> Tours { get; set; }
    }
}