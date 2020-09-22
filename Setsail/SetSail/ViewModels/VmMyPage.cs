using SetSail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmMyPage: VmLayoutDesLog
    {
        public User User { get; set; }
        public List<UserSocial> UserSocials { get; set; }
        public About About { get; set; }
        public List<Blog> Blogs { get; set; }
        public string Link { get; set; }
        public int SocialId { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        [NotMapped]
        public string PhotoFile { get; set; }
        public int UserId { get; set; }
    }
}