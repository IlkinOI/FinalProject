﻿using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmSearch: VmLayoutDesLog
    {
        public List<Tour> Tours { get; set; }
        public List<Tour> MostTours { get; set; }
        public List<TourCategory> TourCategories { get; set; }
        public List<Destination> Dddestinations { get; set; }
        public List<TourCity> TourCitiess { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }
}