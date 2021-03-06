﻿using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmExotic: VmLayoutDesLog
    {
        public ExoticPage ExoticPage { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Team> Teams { get; set; }
        public List<Tour> Tours { get; set; }
    }
}