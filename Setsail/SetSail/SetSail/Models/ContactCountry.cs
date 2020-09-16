using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class ContactCountry
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        public List<ContactCity> ContactCities { get; set; }
    }
}