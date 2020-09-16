using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class TourCategory
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        public List<DesToCat> DesToCats { get; set; }
    }
}