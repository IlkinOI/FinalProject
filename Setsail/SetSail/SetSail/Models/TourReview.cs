using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class TourReview
    {
        public int Id { get; set; }
        [Required,MaxLength(500)]
        public string Message { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Rating { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Comfort { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Food { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Hospitality { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Hygiene { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Reception { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TourId { get; set; }
        public int UserId { get; set; }
        public Tour Tour { get; set; }
        public User User { get; set; }
    }
}