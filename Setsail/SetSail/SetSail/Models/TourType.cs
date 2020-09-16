using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class TourType
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public List<DesToType> DesToTypes { get; set; }
    }
}