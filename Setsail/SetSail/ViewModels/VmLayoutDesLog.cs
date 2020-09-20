using SetSail.DAL;
using SetSail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmLayoutDesLog
    {
        [Required]
        public string sEmail { get; set; }
        [Required]
        public string lEmail { get; set; }
        [Required]
        public string lPassword { get; set; }
        [Required]
        public string sFullname { get; set; }
        [Required]
        public string lFullname { get; set; }
        public List<Destination> Ddestinations { get; set; }
        public Destination Ddestionation { get; set; }
        public Blog Blog { get; set; }
        public string Page { get; set; }
        public int? pdId { get; set; }
        [Required]
        public string REmail { get; set; }
        [Required]
        public string RPhone { get; set; }
        [Required]
        public string RPassword { get; set; }
        [Required]
        public string RFullname { get; set; }
    }
}