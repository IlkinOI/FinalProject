using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmSummer
    {
        public SummerPage SummerPage { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Tour> Tours { get; set; }
        public List<TourReview> TourReviews{ get; set; }
        public List<TourCategory> TourCategories{ get; set; }
        public List<Destination> Destinations{ get; set; }
        public Tour BestTour { get; set; }
    }
}