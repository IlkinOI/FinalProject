using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Destination
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string BgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase BgImageFile { get; set; }
        [MaxLength(250)]
        public string SliderImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase SlideImageFile { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text1 { get; set; }
        [MaxLength(250)]
        public string Pic1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pic1File { get; set; }
        [MaxLength(250)]
        public string Pic2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pic2File { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text2 { get; set; }
        [Required, MaxLength(50)]
        public string Visa { get; set; }
        [Required, MaxLength(50)]
        public string Language { get; set; }
        [Required, MaxLength(50)]
        public string Area { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string MunText { get; set; }
        [MaxLength(250)]
        public string Pic3 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pic3File { get; set; }
        [MaxLength(250)]
        public string Pic4 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pic4File { get; set; }
        [MaxLength(250)]
        public string Pic5 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pic5File { get; set; }
        [MaxLength(250)]
        public string Pic6 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pic6File { get; set; }
        [Required, MaxLength(250)]
        public string Video { get; set; }
        public List<TourCity> TourCities { get; set; }
    }
}