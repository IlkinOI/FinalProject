using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class WinePage
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string introTitleImage1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase introTitleImage1File { get; set; }
        [MaxLength(250)]
        public string introTitleImage2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase introTitleImage2File { get; set; }
        [MaxLength(250)]
        public string introTitleImage3 { get; set; }
        [NotMapped]
        public HttpPostedFileBase introTitleImage3File { get; set; }
        [MaxLength(250)]
        public string IntroImage1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage1File { get; set; }
        [MaxLength(250)]
        public string IntroImage1s { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage1sFile { get; set; }
        [MaxLength(250)]
        public string IntroImage2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage2File { get; set; }
        [MaxLength(250)]
        public string IntroImage2s { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage2sFile { get; set; }
        [MaxLength(250)]
        public string IntroImage3 { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage3File { get; set; }
        [MaxLength(250)]
        public string IntroImage3s { get; set; }
        [NotMapped]
        public HttpPostedFileBase IntroImage3sFile { get; set; }
        [MaxLength(250)]
        public string VideoImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideoImageFile { get; set; }
        [MaxLength(250)]
        public string PopImage1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase PopImage1File { get; set; }
        [MaxLength(250)]
        public string PopImage2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase PopImage2File { get; set; }
        [Required]
        public int Glasses { get; set; }
        [Required]
        public int Years { get; set; }
        [Required]
        public int Uniques { get; set; }
        [Required]
        public int Sorts { get; set; }
        [Required, MaxLength(150)]
        public string PopSlogan { get; set; }
        [Required, MaxLength(100)]
        public string PopText1 { get; set; }
        [Required, MaxLength(100)]
        public string PopText2 { get; set; }
        [Required, MaxLength(100)]
        public string PopText3 { get; set; }
        [Required, MaxLength(100)]
        public string PopText4 { get; set; }
        [Required, MaxLength(250)]
        public string Video { get; set; }
    }
}