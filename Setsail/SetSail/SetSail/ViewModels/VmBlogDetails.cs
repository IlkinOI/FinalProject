using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmBlogDetails
    {
        public Blog Blog { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        public User User { get; set; }
        public List<UserSocial> UserSocials { get; set; }
        public string SFullname { get; set; }
        public string SEmail { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}