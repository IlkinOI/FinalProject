using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class ContactSocial
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Icon { get; set; }
        [Required, MaxLength(250)]
        public string Link { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}