﻿using SetSail.Models;
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
        public About About { get; set; }
        public List<Blog> Blogs { get; set; }
        public string Link { get; set; }
        public int SocialId { get; set; }
        public int userId { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }
    }
}