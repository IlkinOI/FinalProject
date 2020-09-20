using SetSail.DAL;
using SetSail.Models;
using SetSail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetSail.Controllers
{
    public class AboutController : Controller
    {
        SetSailContext db = new SetSailContext();
        // GET: About
        public ActionResult Index()
        {
            VmAbout about = new VmAbout();
            about.About = db.Abouts.FirstOrDefault();
            about.Tours = db.Tours.Include("TourReviews").Include("TourCity").ToList();
            about.TourReviews = db.TourReviews.Include("Tour").ToList();
            about.Blogs = db.Blogs.Include("BlogComments").Include("User").ToList();
            about.BlogComments = db.BlogComments.Include("Blog").Include("User").ToList();
            about.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            about.TeamSocials = db.TeamSocials.Include("Team").ToList();
            ViewBag.About = true;
            ViewBag.Page = "About";
            return View(about);
        }

        public ActionResult FAQ()
        {
            VmFAQ Faqs = new VmFAQ();
            Faqs.Faqs = db.Faqs.ToList();
            ViewBag.FAQ = true;
            ViewBag.Page = "FAQ";
            return View(Faqs);
        }

        [HttpPost]
        public ActionResult Subscribe(VmFAQ details)
        {
            if (string.IsNullOrEmpty(details.Email) || string.IsNullOrEmpty(details.Fullname))
            {
                Session["Empty"] = true;
                return RedirectToAction("FAQ", "About");
            }
            Subscription Subscribe = new Subscription();
            Subscribe.Email = details.Email;
            Subscribe.Fullname = details.Fullname;
            Subscribe.CreatedDate = DateTime.Now;

            db.Subscriptions.Add(Subscribe);
            db.SaveChanges();

            Session["Subsribed"] = true;

            return RedirectToAction("FAQ", "About");
        }
    }
}