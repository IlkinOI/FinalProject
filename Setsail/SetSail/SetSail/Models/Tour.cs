using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string BgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase BgImageFile { get; set; }
        [MaxLength(250)]
        public string FrontImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase FrontImageFile { get; set; }
        [Required,Column(TypeName ="money")]
        public decimal Price { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string About { get; set; }
        [Required, Column(TypeName = "tinyint")]
        public byte Age { get; set; }
        [Required, MaxLength(50)]
        public string DeparturePlace { get; set; }
        [NotMapped]
        public string DepartureTimes { get; set; }
        [NotMapped]
        public string ReturnTimes { get; set; }
        [Column(TypeName ="time")]
        public TimeSpan DepartureTime{ get; set; }
        [Column(TypeName = "time")]
        public TimeSpan ReturnTime { get; set; }
        [Required, MaxLength(30)]
        public string DressCode { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text { get; set; }
        [Required, Column(TypeName = "tinyint")]
        public byte TicketsNum { get; set; }
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public int TourCityId { get; set; }
        public Admin Admin { get; set; }
        public TourCity TourCity { get; set; }
        public List<Include> Includes { get; set; }
        public List<NotInclude> NotIncludes { get; set; }
        public List<Day> Days { get; set; }
        public List<TourReview> TourReviews { get; set; }
        public List<TourImage> TourImages { get; set; }
        public List<TourDates> TourDates { get; set; }
        [NotMapped]
        public HttpPostedFileBase[] ImageFile { get; set; }
    }
}