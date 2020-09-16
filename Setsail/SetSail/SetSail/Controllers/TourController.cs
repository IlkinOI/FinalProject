using SetSail.DAL;
using SetSail.Models;
using SetSail.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetSail.Controllers
{
    public class TourController : Controller
    {
        SetSailContext db = new SetSailContext();
        // GET: Tour

        public ActionResult Search(string search, int page = 1)
        {
            VmSearch model = new VmSearch();
            model.TourCategories = db.TourCategories.ToList();
            model.Tours = db.Tours.Include("TourReviews").Include("TourCity")
                                  .Include("TourCity.Destination").Where(t=>(!string.IsNullOrEmpty(search) ? t.Name.Contains(search) : true) ||
                                                                            (!string.IsNullOrEmpty(search) ? t.TourCity.Name.Contains(search) : true) ||
                                                                            (!string.IsNullOrEmpty(search) ? t.TourCity.Destination.Name.Contains(search) : true))
                                                                            .OrderByDescending(o => o.Id).Skip((page - 1) * 8).Take(8).ToList();
            model.CurrentPage = page;
            model.PageCount = Convert.ToInt32(Math.Ceiling(db.Tours.Count() / 8.0));
            ViewBag.Tour = true;
            return View(model);
        }
        public ActionResult TourDetailIndex(int id)
        {
            VmTourDetails td = new VmTourDetails();
            td.Tour = db.Tours.Include("TourReviews").Include("TourCity").Include("TourCity.Destination").FirstOrDefault(t=>t.Id==id);
            td.TourCity = db.TourCities.Include("Tours").Include("Destination").FirstOrDefault(tc=>tc.Name==td.Tour.TourCity.Name);
            td.TourImages = db.TourImages.Include("Tour").Where(im => im.TourId == id).ToList();
            td.Includes = db.Includes.Include("Tour").Where(i => i.TourId == id).ToList();
            td.NotIncludes = db.NotIncludes.Include("Tour").Where(ni => ni.TourId == id).ToList();
            td.Days = db.Days.Include("DayIncludes").Include("Tour").Where(d => d.TourId == id).ToList();
            td.DayIncludes = db.DayIncludes.Include("Day").Include("Day.Tour").ToList();
            td.TourReviews = db.TourReviews.Include("User").Include("Tour").Where(tr=>tr.TourId==id).ToList();
            ViewBag.Tour = true;
            return View(td);
        }
        public ActionResult Destinations()
        {
            VmLayoutDesLog des = new VmLayoutDesLog();
            des.Destinations = db.Destinations.Include("DesToTypes").Include("DesToType.TourType").ToList();
            ViewBag.Destination = true;
            return View(des);
        }
        public ActionResult DestinationDetails(int id)
        {
            Destination des = db.Destinations.Find(id);
            ViewBag.Destination = true;
            return View(des);
        }
        public ActionResult Summer()
        {
            VmSummer summer = new VmSummer();
            summer.SummerPage = db.SummerPages.FirstOrDefault();
            summer.Destinations = db.Destinations.Include("DesToCats").Include("DesToTypes").ToList();
            summer.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            summer.TourCategories = db.TourCategories.Include("DesToCats").Include("Destination").ToList();
            summer.Blogs = db.Blogs.Include("User").Include("BlogComments").ToList();
            summer.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            summer.BestTour = db.Tours.Include("TourCity").FirstOrDefault(t => t.TourCity.Name == "Zermatt");
            ViewBag.Summer = true;
            return View(summer);
        }
        public ActionResult Winter()
        {
            VmWinter winter = new VmWinter();
            winter.WinterPage = db.WinterPages.FirstOrDefault();
            winter.Destinations = db.Destinations.Include("DesToCats").Include("DesToCat.TourCategory").ToList();
            winter.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            winter.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            winter.TourCategories = db.TourCategories.Include("DesToCats").Include("Destination").ToList();
            winter.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            winter.TeamSocials = db.TeamSocials.Include("Team").ToList();
            ViewBag.Winter = true;
            return View(winter);
        }
        public ActionResult City()
        {
            VmCity city = new VmCity();
            city.CityPage = db.CityPages.FirstOrDefault();
            city.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            city.TourCategories = db.TourCategories.Include("DesToCats").Include("Destination").ToList();
            city.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            city.TeamSocials = db.TeamSocials.Include("Team").ToList();
            ViewBag.City = true;
            return View(city);
        }
        public ActionResult Exotic()
        {
            VmExotic ex = new VmExotic();
            ex.ExoticPage = db.ExoticPages.FirstOrDefault();
            ex.Blogs = db.Blogs.Include("User").Include("BlogComments").ToList();
            ex.Destinations = db.Destinations.Include("DesToCats").Include("DesToCat.TourCategory").ToList();
            ex.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            ex.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            ex.TourCategories = db.TourCategories.Include("DesToCats").Include("Destination").ToList();
            ex.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            ex.TeamSocials = db.TeamSocials.Include("Team").ToList();
            ViewBag.Exotic = true;
            return View(ex);
        }
        public ActionResult Wine()
        {
            VmWine wine = new VmWine();
            wine.WinePage = db.WinePages.FirstOrDefault();
            wine.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            wine.TourCategories = db.TourCategories.Include("DesToCats").Include("Destination").ToList();
            ViewBag.Wine = true;
            return View(wine);
        }


        // TOUR REVIEW CRUD START //

        [HttpPost]
        public ActionResult TourReviewCreate(VmTourDetails vmtr)
        {
            if (string.IsNullOrEmpty(vmtr.Message) || string.IsNullOrEmpty(vmtr.Fullname) ||
                string.IsNullOrEmpty(vmtr.Email))
            {
                Session["EmptyReview"] = true;
                return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.Tour.Id });
            }
            if (Session["User"] != null)
            {
                TourReview tr = new TourReview();

                tr.Message = vmtr.Message;
                tr.Fullname = vmtr.Fullname;
                tr.Email = vmtr.Email;
                tr.Rating = vmtr.Rating;
                tr.Comfort = vmtr.Comfort;
                tr.Food = vmtr.Food;
                tr.Hospitality = vmtr.Hospitality;
                tr.Hygiene = vmtr.Hygiene;
                tr.Reception = vmtr.Reception;
                tr.TourId = vmtr.Tour.Id;
                tr.CreatedDate = DateTime.Now;
                tr.UserId = (int)Session["UserId"];

                db.TourReviews.Add(tr);
                db.SaveChanges();

                Session["TourReviewSent"] = true;
            }
            return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.Tour.Id });
        }
        public ActionResult TourReviewUpdate(int id)
        {
            TourReview tr = db.TourReviews.Find(id);
            if (tr == null)
            {
                return HttpNotFound();
            }
            return View(tr);
        }

        [HttpPost]
        public ActionResult TourReviewUpdate(VmTourDetails vmtr)
        {
            if (string.IsNullOrEmpty(vmtr.Message) || string.IsNullOrEmpty(vmtr.Fullname) ||
                string.IsNullOrEmpty(vmtr.Email))
            {
                Session["EmptyReview"] = true;
                return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.Tour.Id });
            }
            if (Session["User"] != null)
            {
                TourReview tr = db.TourReviews.FirstOrDefault(c => c.Id == vmtr.Tour.Id);

                tr.Message = vmtr.Message;
                tr.Fullname = vmtr.Fullname;
                tr.Email = vmtr.Email;
                tr.Rating = vmtr.Rating;
                tr.Comfort = vmtr.Comfort;
                tr.Food = vmtr.Food;
                tr.Hospitality = vmtr.Hospitality;
                tr.Hygiene = vmtr.Hygiene;
                tr.Reception = vmtr.Reception;
                tr.TourId = vmtr.Tour.Id;
                tr.CreatedDate = tr.CreatedDate;
                tr.UserId = (int)Session["UserId"];

                db.Entry(tr).State = EntityState.Modified;
                db.SaveChanges();

                Session["TourReviewSent"] = true;
            }
            return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.Tour.Id });
        }

        public ActionResult TourReviewDelete(int id)
        {
            TourReview tr = db.TourReviews.Find(id);
            if (tr == null)
            {
                return HttpNotFound();
            }

            db.TourReviews.Remove(tr);
            db.SaveChanges();

            return RedirectToAction("TourDetailIndex", "Tour", new { id });
        }

        // TOUR REVIEW CRUD END //

        // BOOKING CRUD START //

        public ActionResult BookingCreate(VmTourDetails book)
        {
            if (string.IsNullOrEmpty(book.BookingFullname) || string.IsNullOrEmpty(book.BookingEmail) ||
                string.IsNullOrEmpty(book.BookingPhone) || book.BookingTickets != 0 || book.BookingDates != "Avaliable Dates")
            {
                Session["EmptyBook"] = true;
                return RedirectToAction("TourDetailIndex", "Tour", new { id = book.Tour.Id });
            }

            Tour tour = db.Tours.Find(book.Tour.Id);

            if (tour.TicketsNum >= book.BookingTickets)
            {
                tour.TicketsNum = Convert.ToByte(tour.TicketsNum - book.BookingTickets);

                db.Entry(tour).State = EntityState.Modified;
                Booking bk = new Booking();

                bk.Tickets = book.BookingTickets;
                bk.Fullname = book.BookingFullname;
                bk.Email = book.BookingEmail;
                bk.Phone = book.BookingPhone;
                bk.CreatedDate = DateTime.Now;
                if (Session["User"] != null)
                {
                    bk.UserId = (int)Session["UserId"];
                }
                else
                {
                    bk.UserId = null;
                }
                string[] dates = book.BookingDates.Split('-');

                bk.DateFrom = Convert.ToDateTime(dates[0]);
                bk.DateTo = Convert.ToDateTime(dates[1]);

                db.Bookings.Add(bk);
                db.SaveChanges();

                Session["BookSent"] = true;

                return RedirectToAction("TourDetailIndex", "Tour", new { id = book.Tour.Id });
            }
            else
            {
                Session["NoTickets"] = true;
            }
            return RedirectToAction("TourDetailIndex", "Tour", new { id = book.Tour.Id });
        }


        // BOOKING CRUD END //
    }
}