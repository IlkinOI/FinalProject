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