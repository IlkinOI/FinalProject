using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}