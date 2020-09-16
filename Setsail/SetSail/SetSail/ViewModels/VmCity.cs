using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmCity
    {
        public CityPage CityPage { get; set; }
        public List<Tour> Tours { get; set; }
        public List<TourCategory> TourCategories { get; set; }
        public List<Team> Teams { get; set; }
        public List<TeamSocial> TeamSocials { get; set; }
    }
}