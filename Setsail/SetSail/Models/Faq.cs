using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Faq
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string BgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase BgImageFile { get; set; }
        [Required, MaxLength(50)]
        public string Question { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Answer { get; set; }
    }
}