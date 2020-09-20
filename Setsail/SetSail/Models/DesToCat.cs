using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class DesToCat
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public int TourCategoryId { get; set; }
        public Destination Destination { get; set; }
        public TourCategory TourCategory { get; set; }
    }
}