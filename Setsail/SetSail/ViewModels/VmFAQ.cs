﻿using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetSail.ViewModels
{
    public class VmFAQ: VmLayoutDesLog
    {
        public List<Faq> Faqs { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
    }
}