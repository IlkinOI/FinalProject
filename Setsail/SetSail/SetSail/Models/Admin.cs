using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
        [Required, MaxLength(250)]
        public string Password { get; set; }
        [MaxLength(250)]
        public string Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }
        public List<Tour> Tours { get; set; }
    }
}