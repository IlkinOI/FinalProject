using SetSail.DAL;
using SetSail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmLayoutDesLog
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Blog> Blogs { get; set; }

    }
}