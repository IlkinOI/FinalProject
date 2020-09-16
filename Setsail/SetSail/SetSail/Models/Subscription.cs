using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}