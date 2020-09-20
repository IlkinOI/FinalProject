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
            model.Tours = db.Tours.Include("TourReviews")
                                  .Include("TourDates")
                                  .Include("TourCity")
                                  .Include("TourCity.Destination")
                                  .Include("TourCity.Destination.DesToCats")
                                  .Include("TourCity.Destination.DesToCats.TourCategory")
                                  .Include("TourCity.Destination.DesToTypes")
                                  .Include("TourCity.Destination.DesToTypes.TourType")
                                  .Where(t=>
                                  (!string.IsNullOrEmpty(search) ? t.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourCity.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourCity.Destination.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourCity.Destination.DesToCats.Any(dc => dc.TourCategory.Name.Contains(search)) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourCity.Destination.DesToTypes.Any(dc => dc.TourType.Name.Contains(search)) : true)
                                  ).OrderByDescending(o => o.Id).Skip((page - 1) * 8).Take(8).ToList();
            model.CurrentPage = page;
            model.PageCount = Convert.ToInt32(Math.Ceiling(db.Tours.Count() / 8.0));
            ViewBag.Tour = true;
            ViewBag.Page = "Search";
            return View(model);
        }
        public ActionResult TourDetailIndex(int id)
        {
            VmTourDetails td = new VmTourDetails();
            td.Tour = db.Tours.Include("TourReviews").Include("TourCity").Include("TourCity.Destination").FirstOrDefault(t=>t.Id==id);
            td.TourDates = db.TourDates.Include("Tour").Where(d => d.TourId == id).OrderBy(b=>b.Id).ToList();
            td.TourCity = db.TourCities.Include("Tours").Include("Destination").FirstOrDefault(tc=>tc.Name==td.Tour.TourCity.Name);
            td.TourImages = db.TourImages.Include("Tour").Where(im => im.TourId == id).ToList();
            td.Includes = db.Includes.Include("Tour").Where(i => i.TourId == id).ToList();
            td.NotIncludes = db.NotIncludes.Include("Tour").Where(ni => ni.TourId == id).ToList();
            td.Days = db.Days.Include("DayIncludes").Include("Tour").Where(d => d.TourId == id).ToList();
            td.DayIncludes = db.DayIncludes.Include("Day").Include("Day.Tour").ToList();
            td.TourReviews = db.TourReviews.Include("User").Include("Tour").Where(tr=>tr.TourId==id).ToList();
            ViewBag.Tour = true;
            ViewBag.Page = "TourDetails";
            ViewBag.Id = id;
            return View(td);
        }
        public ActionResult Destinations()
        {
            VmLayoutDesLog des = new VmLayoutDesLog();
            des.Ddestinations = db.Destinations.Include("DesToTypes").Include("DesToTypes.TourType").ToList();
            ViewBag.Destination = true;
            ViewBag.Page = "Destinations";
            return View(des);
        }
        public ActionResult DestinationDetails(int id)
        {
            VmLayoutDesLog des = new VmLayoutDesLog();
            des.Ddestionation=db.Destinations.Find(id);
            ViewBag.Destination = true;
            ViewBag.Page = "DestinationDetails";
            ViewBag.Id = id;
            return View(des);
        }
        public ActionResult Summer()
        {
            VmSummer summer = new VmSummer();
            summer.SummerPage = db.SummerPages.FirstOrDefault();
            summer.DesToCats = db.DesToCats.Include("Destination").Include("TourCategory").Where(dc => dc.TourCategory.Name == "Summer").ToList();
            summer.Destinations = db.Destinations.Include("DesToCats").Include("DesToTypes").ToList();
            summer.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            summer.TourCategories = db.TourCategories.Include("DesToCats").Include("DesToCats.Destination").ToList();
            summer.Blogs = db.Blogs.Include("User").Include("BlogComments").ToList();
            summer.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            summer.BestTour = db.Tours.Include("TourCity").FirstOrDefault(t => t.TourCity.Name == "Zermatt");
            ViewBag.Summer = true;
            ViewBag.Page = "Summer";
            return View(summer);
        }
        public ActionResult Winter()
        {
            VmWinter winter = new VmWinter();
            winter.WinterPage = db.WinterPages.FirstOrDefault();
            winter.Destinations = db.Destinations.Include("DesToCats").Include("DesToCats.TourCategory").ToList();
            winter.DesToCats = db.DesToCats.Include("Destination").Include("TourCategory").Where(dc => dc.TourCategory.Name == "Winter").ToList();
            winter.Tours = db.Tours.Include("TourDates").Include("TourCity").Include("TourCity.Destination").ToList();
            winter.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            winter.TourCategories = db.TourCategories.Include("DesToCats").Include("DesToCats.Destination").ToList();
            winter.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            winter.TeamSocials = db.TeamSocials.Include("Team").ToList();
            ViewBag.Winter = true;
            ViewBag.Page = "Winter";
            return View(winter);
        }
        public ActionResult City()
        {
            VmCity city = new VmCity();
            city.CityPage = db.CityPages.FirstOrDefault();
            city.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            city.TourCategories = db.TourCategories.Include("DesToCats").Include("DesToCats.Destination").ToList();
            city.DesToCats = db.DesToCats.Include("Destination").Include("TourCategory").Where(dc => dc.TourCategory.Name == "City").ToList();
            city.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            city.TeamSocials = db.TeamSocials.Include("Team").ToList();
            ViewBag.City = true;
            ViewBag.Page = "City";
            return View(city);
        }
        public ActionResult Exotic()
        {
            VmExotic ex = new VmExotic();
            ex.ExoticPage = db.ExoticPages.FirstOrDefault();
            ex.Blogs = db.Blogs.Include("User").Include("BlogComments").ToList();
            ex.DesToCats = db.DesToCats.Include("Destination").Include("TourCategory").Where(dc => dc.TourCategory.Name == "Exotic").ToList();
            ex.Destinations = db.Destinations.Include("DesToCats").Include("DesToCats.TourCategory").ToList();
            ex.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            ex.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            ex.TourCategories = db.TourCategories.Include("DesToCats").Include("DesToCats.Destination").ToList();
            ex.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            ex.TeamSocials = db.TeamSocials.Include("Team").ToList();
            ViewBag.Exotic = true;
            ViewBag.Page = "Exotic";
            return View(ex);
        }
        public ActionResult Wine()
        {
            VmWine wine = new VmWine();
            wine.WinePage = db.WinePages.FirstOrDefault();
            wine.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            wine.TourCategories = db.TourCategories.Include("DesToCats").Include("DesToCats.Destination").ToList();
            wine.DesToCats = db.DesToCats.Include("Destination").Include("TourCategory").Where(dc => dc.TourCategory.Name == "Wine").ToList();
            ViewBag.Wine = true;
            ViewBag.Page = "Wine";
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

        public ActionResult BookingCreate(VmTourDetails book,int dateId,int TourId)
        {
            if (string.IsNullOrEmpty(book.BookingFullname) || string.IsNullOrEmpty(book.BookingEmail) ||
                string.IsNullOrEmpty(book.BookingPhone) || dateId==0 || book.BookingTickets == 0)
            {
                Session["EmptyBook"] = true;
                ModelState.AddModelError("","");
                return RedirectToAction("TourDetailIndex", "Tour", new { id = TourId });
            }
            TourDates date = db.TourDates.Find(dateId);

            if (date.TicketsNum >= book.BookingTickets)
            {
                date.TicketsNum = Convert.ToByte(date.TicketsNum - book.BookingTickets);

                db.Entry(date).State = EntityState.Modified;
                Booking bk = new Booking();

                bk.Tickets = book.BookingTickets;
                bk.Fullname = book.BookingFullname;
                bk.Email = book.BookingEmail;
                bk.Phone = book.BookingPhone;
                bk.TourId = TourId; ;
                bk.CreatedDate = DateTime.Now;
                if (Session["User"] != null)
                {
                    bk.UserId = (int)Session["UserId"];
                }
                else
                {
                    bk.UserId = null;
                }

                bk.DateFrom = date.DateFrom;
                bk.DateTo = date.DateTo;

                

                db.Bookings.Add(bk);
                db.SaveChanges();

                Session["BookSent"] = true;

                return RedirectToAction("TourDetailIndex", "Tour", new { id = TourId });
            }
            else
            {
                Session["NoTickets"] = true;
                ModelState.AddModelError("BookingTickets", "Only "+date.TicketsNum.ToString("0")+" left");
            }
            return RedirectToAction("TourDetailIndex", "Tour", new { id = TourId });
        }


        // BOOKING CRUD END //
    }
}