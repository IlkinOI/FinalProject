using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class UserSocial
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Icon { get; set; }
        [Required, MaxLength(250)]
        public string Link { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}