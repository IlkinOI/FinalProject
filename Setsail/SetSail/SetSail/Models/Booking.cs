using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
        [Required, Column(TypeName = "tinyint")]
        public byte Tickets { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TourId { get; set; }
        public int? UserId { get; set; }
        public Tour Tour { get; set; }
        public User User { get; set; }
    }
}