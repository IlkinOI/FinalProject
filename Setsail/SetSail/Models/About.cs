using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string TopText { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text { get; set; }
        [MaxLength(250)]
        public string BgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase BgImageFile { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(250)]
        public string PopImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase PopImageFile { get; set; }
        [MaxLength(250)]
        public string VideoImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideoImageFile { get; set; }
        [MaxLength(250)]
        public string Video { get; set; }
        [MaxLength(250)]
        public string MPImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase MPImageFile { get; set; }
        [MaxLength(250)]
        public string BlogsBgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase BlogsBgImageFile { get; set; }
    }
}