using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class WinterPage
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string TopTitle1 { get; set; }
        [Required, MaxLength(30)]
        public string Title1 { get; set; }
        [Required, MaxLength(150)]
        public string introText1 { get; set; }
        [Required, MaxLength(30)]
        public string TopTitle2 { get; set; }
        [Required, MaxLength(30)]
        public string Title2 { get; set; }
        [Required, MaxLength(150)]
        public string introText2 { get; set; }
        [MaxLength(250)]
        public string IntroImage1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage1File { get; set; }
        [MaxLength(250)]
        public string IntroImage2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage2File { get; set; }
        public string VideoImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideoImageFile { get; set; }
        [MaxLength(250)]
        public string ParallaxImage1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ParallaxImage1File { get; set; }
        [Required, MaxLength(250)]
        public string Video { get; set; }
    }
}