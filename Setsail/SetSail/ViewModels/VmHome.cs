using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmHome: VmLayoutDesLog
    {
        public HomePage HomePage { get; set; }
        public WinterPage WinterPage { get; set; }
        public CityPage CityPage { get; set; }
        public List<Destination> Destinations { get; set; } 
        public Destination Destination1 { get; set; } 
        public Destination Destination2 { get; set; }
        public Destination Destination3 { get; set; }
        public List<Tour> Tours { get; set; }
        public List<Blog> Blogs { get; set; } //testmonial//
        public List<TourReview> TourReviews { get; set; } //parallax tour reviews//
        public Tour BestTour { get; set; } // best offer //
    }
}