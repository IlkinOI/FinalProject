using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmContact
    {
        public List<Contact> Contacts { get; set; }
        public string Message { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
    }
}