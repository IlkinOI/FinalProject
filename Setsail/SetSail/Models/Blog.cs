using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string BgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase BgImageFile { get; set; }
        [MaxLength(250)]
        public string MainImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase MainImageFile { get; set; }
        [Required, MaxLength(200)]
        public string TopText { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text1 { get; set; }
        [Required, MaxLength(250)]
        public string Quote { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text2 { get; set; }
        [MaxLength(250)]
        public string Image1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image1File { get; set; }
        [MaxLength(250)]
        public string Image2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image2File { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text3 { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogCategoryId { get; set; }
        public int UserId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public User User { get; set; }
        public List<BlogComment> BlogComments { get; set; }
    }

}