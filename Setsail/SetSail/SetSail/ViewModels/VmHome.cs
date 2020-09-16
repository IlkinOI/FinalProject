using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmHome
    {
        public HomePage HomePage { get; set; }
        public WinterPage WinterPage { get; set; }
        public CityPage CityPage { get; set; }
        public List<Destination> Destinations { get; set; } 
        public List<TourCategory> TourCategories { get; set; } 
        public List<TourType> TourTypes { get; set; } 
        public List<TourCity> TourCities { get; set; } 
        public Destination Destination1 { get; set; } 
        public Destination Destination2 { get; set; }
        public Destination Destination3 { get; set; }
        public List<Tour> ToursDes1 { get; set; }
        public List<Tour> ToursDes2 { get; set; }
        public List<Tour> ToursDes3 { get; set; }
        public Tour TourParis { get; set; } 
        public List<Tour> Tours { get; set; }
        public List<Blog> Blogs { get; set; } //testmonial//
        public List<TourReview> TourReviews { get; set; } //parallax tour reviews//
        public Tour TourTaipei { get; set; } // best offer //
    }
}