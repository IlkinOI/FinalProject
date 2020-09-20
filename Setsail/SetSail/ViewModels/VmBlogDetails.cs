using SetSail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmBlogDetails: VmLayoutDesLog
    {
        public List<BlogComment> BlogComments { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        [Required]
        public string SubFullname { get; set; }
        [Required]
        public string SubEmail { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        public int BlogId { get; set; }
    }
}