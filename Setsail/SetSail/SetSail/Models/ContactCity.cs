using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class ContactCity
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        public int ContactCountryId { get; set; }
        public ContactCountry ContactCountry { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}