using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmBlogComment: VmLayoutDesLog
    {
        public string Message { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
    }
}