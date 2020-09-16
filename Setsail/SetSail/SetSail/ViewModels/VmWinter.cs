﻿using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmWinter
    {
        public WinterPage WinterPage { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Team> Teams { get; set; }
        public List<TeamSocial> TeamSocials { get; set; }
        public List<Tour> Tours { get; set; }
        public List<TourReview> TourReviews { get; set; } 
        public List<TourCategory> TourCategories { get; set; } 
    }
}