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
            model.Tours = db.Tours.Include("TourReviews")
                                  .Include("TourDates")
                                  .Include("TourCity")
                                  .Include("TourCity.Destination")
                                  .Include("TourCategory")
                                  .Include("TourType")
                                  .Where(t=>
                                  (!string.IsNullOrEmpty(search) ? t.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourCity.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourCity.Destination.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourCategory.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.TourType.Name.Contains(search) : true) ||
                                  (!string.IsNullOrEmpty(search) ? t.Price.ToString().Contains(search) : true)
                                  ).OrderBy(o => o.Id).Skip((page - 1) * 8).Take(8).ToList();
            model.LatestTours = db.Tours.OrderByDescending(t=>t.Id).Take(3).ToList();
            model.CurrentPage = page;
            model.PageCount = Convert.ToInt32(Math.Ceiling(db.Tours.Count() / 8.0));
            ViewBag.Tour = true;
            ViewBag.Page = "Search";
            return View(model);
        }
        public ActionResult TourDetailIndex(int id)
        {
            VmTourDetails td = new VmTourDetails();
            td.Tour = db.Tours.Include("TourDates").Include("TourImages")
                              .Include("TourReviews").Include("TourReviews.User")
                              .Include("Days").Include("Days.DayIncludes")
                              .Include("Includes").Include("NotIncludes")
                              .Include("TourCity").Include("TourCity.Destination").FirstOrDefault(t=>t.Id==id);
            ViewBag.Tour = true;
            ViewBag.Page = "TourDetails";
            ViewBag.Id = id;
            return View(td);
        }
        public ActionResult Destinations()
        {
            VmLayoutDesLog des = new VmLayoutDesLog();
            des.Ddestinations = db.Destinations.ToList();
            ViewBag.Destination = true;
            ViewBag.Page = "Destinations";
            return View(des);
        }
        public ActionResult DestinationDetails(int id)
        {
            VmLayoutDesLog des = new VmLayoutDesLog();
            des.Ddestionation=db.Destinations.Find(id);
            des.DesTours = db.Tours.Where(t=>t.TourCity.DestinationId==id).OrderByDescending(t => t.Id).Take(5).ToList();
            ViewBag.Destination = true;
            ViewBag.Page = "DestinationDetails";
            ViewBag.Id = id;
            return View(des);
        }
        public ActionResult Summer()
        {
            VmSummer summer = new VmSummer();
            summer.SummerPage = db.SummerPages.FirstOrDefault();
            summer.Tours = db.Tours.Include("TourCategory").Include("TourCity").Include("TourCity.Destination").ToList();
            summer.Blogs = db.Blogs.Include("User").Include("BlogComments").ToList();
            summer.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            summer.BestTour = db.Tours.Include("TourCity").FirstOrDefault(t => t.TourCity.Name == db.SummerPages.FirstOrDefault().BestTourName);
            ViewBag.Summer = true;
            ViewBag.Page = "Summer";
            return View(summer);
        }
        public ActionResult Winter()
        {
            VmWinter winter = new VmWinter();
            winter.WinterPage = db.WinterPages.FirstOrDefault();
            winter.Destinations = db.Destinations.ToList();
            winter.Tours = db.Tours.Include("TourCategory").Include("TourDates").Include("TourReviews").Include("TourCity").Include("TourCity.Destination").ToList();
            winter.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").OrderBy(t=>t.Id).Take(9).ToList();
            winter.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            ViewBag.Winter = true;
            ViewBag.Page = "Winter";
            return View(winter);
        }
        public ActionResult City()
        {
            VmCity city = new VmCity();
            city.CityPage = db.CityPages.FirstOrDefault();
            city.Tours = db.Tours.Include("TourCategory").Include("TourCity").Include("TourCity.Destination").ToList();
            city.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            ViewBag.City = true;
            ViewBag.Page = "City";
            return View(city);
        }
        public ActionResult Exotic()
        {
            VmExotic ex = new VmExotic();
            ex.ExoticPage = db.ExoticPages.FirstOrDefault();
            ex.Blogs = db.Blogs.Include("User").Include("BlogComments").ToList();
            ex.Destinations = db.Destinations.ToList();
            ex.Tours = db.Tours.Include("TourCategory").Include("TourCity").Include("TourCity.Destination").ToList();
            ex.Teams = db.Teams.Include("TeamSocials").Include("Position").ToList();
            ViewBag.Exotic = true;
            ViewBag.Page = "Exotic";
            return View(ex);
        }
        public ActionResult Wine()
        {
            VmWine wine = new VmWine();
            wine.WinePage = db.WinePages.FirstOrDefault();
            wine.Tours = db.Tours.Include("TourCategory").Include("TourCity").Include("TourCity.Destination").ToList();
            ViewBag.Wine = true;
            ViewBag.Page = "Wine";
            return View(wine);
        }


        // TOUR REVIEW CRUD START //

        [HttpPost]
        public ActionResult TourReviewCreate(VmTourDetails vmtr)
        {
            if (string.IsNullOrEmpty(vmtr.Message)|| string.IsNullOrEmpty(vmtr.Rating.ToString()) ||
                string.IsNullOrEmpty(vmtr.Reception.ToString()) || string.IsNullOrEmpty(vmtr.Comfort.ToString()) ||
                string.IsNullOrEmpty(vmtr.Food.ToString()) || string.IsNullOrEmpty(vmtr.Hospitality.ToString()) ||
                string.IsNullOrEmpty(vmtr.Hygiene.ToString()))
            {
                Session["EmptyReview"] = true;

                return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.TourId });
            }
                TourReview tr = new TourReview();

                tr.Message = vmtr.Message;

                tr.Rating = Convert.ToByte(vmtr.Rating);
                tr.Comfort = Convert.ToByte(vmtr.Comfort);
                tr.Food = Convert.ToByte(vmtr.Food);
                tr.Hospitality = Convert.ToByte(vmtr.Hospitality);
                tr.Hygiene = Convert.ToByte(vmtr.Hygiene);
                tr.Reception = Convert.ToByte(vmtr.Reception);
            
                tr.TourId = vmtr.TourId;
                tr.CreatedDate = DateTime.Now;
                tr.UserId = (int)Session["UserId"];

                db.TourReviews.Add(tr);
                db.SaveChanges();

                Session["TourReviewSent"] = true;
            return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.TourId });
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
            if (string.IsNullOrEmpty(vmtr.Message) || string.IsNullOrEmpty(vmtr.Rating.ToString()) ||
                string.IsNullOrEmpty(vmtr.Reception.ToString()) || string.IsNullOrEmpty(vmtr.Comfort.ToString()) ||
                string.IsNullOrEmpty(vmtr.Food.ToString()) || string.IsNullOrEmpty(vmtr.Hospitality.ToString()) ||
                string.IsNullOrEmpty(vmtr.Hygiene.ToString()))
            {
                Session["EmptyReview"] = true;
                return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.TourId });
            }
           
                TourReview tr = db.TourReviews.FirstOrDefault(c => c.Id == vmtr.TourId);

                tr.Message = vmtr.Message;
                tr.Rating = Convert.ToByte(vmtr.Rating);
                tr.Comfort = Convert.ToByte(vmtr.Comfort);
                tr.Food = Convert.ToByte(vmtr.Food);
                tr.Hospitality = Convert.ToByte(vmtr.Hospitality);
                tr.Hygiene = Convert.ToByte(vmtr.Hygiene);
                tr.Reception = Convert.ToByte(vmtr.Reception);
                tr.TourId = vmtr.Tour.Id;
                tr.CreatedDate = tr.CreatedDate;
                tr.UserId = (int)Session["UserId"];

                db.Entry(tr).State = EntityState.Modified;
                db.SaveChanges();

                Session["TourReviewSent"] = true;
            return RedirectToAction("TourDetailIndex", "Tour", new { id = vmtr.TourId });
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
                bk.DateId = date.Id;
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