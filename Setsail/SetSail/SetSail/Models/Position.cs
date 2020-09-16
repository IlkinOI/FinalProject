using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}