using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmBlogs: VmLayoutDesLog
    {
        public About About { get; set; }
        public List<Blog> Blogs { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }
}