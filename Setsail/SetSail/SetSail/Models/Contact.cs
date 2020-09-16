using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Text { get; set; }
        [Required,MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Phone1 { get; set; }
        [Required, MaxLength(50)]
        public string Phone2 { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        [Required, MaxLength(500)]
        public string Map { get; set; }
        public int ContactCityId { get; set; }
        public ContactCity ContactCity { get; set; }
        public List<ContactSocial> ContactsSocials { get; set; }
    }
}