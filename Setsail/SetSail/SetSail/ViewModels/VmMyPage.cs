using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmMyPage
    {
        public User User { get; set; }
        public List<UserSocial> UserSocials { get; set; }
        public About About { get; set; }
        public List<Blog> Blogs { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public int SocialId { get; set; }
    }
}