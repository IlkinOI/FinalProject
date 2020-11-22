using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        [Required, MaxLength(500)]
        public string Message { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}