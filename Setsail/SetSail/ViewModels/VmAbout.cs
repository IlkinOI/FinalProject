﻿using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmAbout: VmLayoutDesLog
    {
        public About About { get; set; }
        public List<Team> Teams { get; set; }
        public List<TeamSocial> TeamSocials { get; set; }
        public List<Tour> Tours { get; set; }
        public List<TourReview> TourReviews { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<BlogComment> BlogComments{ get; set; }
    }
}