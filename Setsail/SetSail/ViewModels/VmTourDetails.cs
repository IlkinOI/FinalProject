using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmTourDetails: VmLayoutDesLog
    {
        public Tour Tour { get; set; }
        public TourCity TourCity { get; set; }
        public List<TourImage> TourImages { get; set; }
        public List<TourReview> TourReviews { get; set; }
        public List<TourDates> TourDates { get; set; }
        public List<Include> Includes { get; set; }
        public List<NotInclude> NotIncludes { get; set; }
        public List<Day> Days { get; set; }
        public List<DayInclude> DayIncludes { get; set; }
        public string BookingFullname { get; set; }
        public string BookingEmail { get; set; }
        public string BookingPhone { get; set; }
        public byte BookingTickets { get; set; }
        public string BookingDates { get; set; }
        public int dateId { get; set; }
        public int TourId { get; set; }
        public string Message { get; set; }
        public byte? Rating { get; set; }
        public byte? Comfort { get; set; }
        public byte? Food { get; set; }
        public byte? Hospitality { get; set; }
        public byte? Hygiene { get; set; }
        public byte? Reception { get; set; }
    }
}