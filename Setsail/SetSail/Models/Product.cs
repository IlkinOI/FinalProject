using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(250)]
        public string About { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required, Column(TypeName = "tinyint")]
        public byte Quantity { get; set; }
        [Required, MaxLength(20)]
        public string Code { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Width { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Height { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Length { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public int ProductCategoryId { get; set; }
        public Admin Admin { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductReview> ProductReviews { get; set; }
        [NotMapped]
        public HttpPostedFileBase[] ImageFile { get; set; }
    }
}