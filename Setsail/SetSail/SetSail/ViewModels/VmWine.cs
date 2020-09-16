using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmWine
    {
        public WinePage WinePage { get; set; }
        public List<Tour> Tours { get; set; }
        public List<TourCategory> TourCategories { get; set; }
    }
}