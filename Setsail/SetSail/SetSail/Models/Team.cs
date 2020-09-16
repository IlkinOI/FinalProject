using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SetSail.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Fullname { get; set; }
        [Required, MaxLength(100)]
        public string About { get; set; }
        [MaxLength(250)]
        public string Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<TeamSocial> TeamSocials { get; set; }
    }
}