using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class DesToType
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public int TourTypeId { get; set; }
        public Destination Destination { get; set; }
        public TourType TourType { get; set; }
    }
}