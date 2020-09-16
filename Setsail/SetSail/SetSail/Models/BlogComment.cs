using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        [Required, MaxLength(500)]
        public string Message { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public User User { get; set; }
    }
}