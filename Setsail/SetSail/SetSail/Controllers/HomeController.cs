using SetSail.DAL;
using SetSail.Models;
using SetSail.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SetSail.Controllers
{
    public class HomeController : Controller
    {
        SetSailContext db = new SetSailContext();
        public ActionResult Index()
        {
            VmHome home = new VmHome();
            home.HomePage = db.HomePages.FirstOrDefault();
            home.WinterPage = db.WinterPages.FirstOrDefault();
            home.CityPage = db.CityPages.FirstOrDefault();
            home.TourCategories = db.TourCategories.Include("DesToCats").ToList();
            home.TourTypes = db.TourTypes.Include("DesToTypes").ToList();
            home.Destinations = db.Destinations.Include("DesToCats").Include("DesToTypes").ToList();
            home.TourCities = db.TourCities.Include("Destination").ToList();
            home.Tours = db.Tours.Include("TourCity").Include("TourCity.Destination").ToList();
            home.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").ToList();
            home.Blogs = db.Blogs.Include("User").Include("BlogComments").ToList();
            home.Destination1 = db.Destinations.FirstOrDefault(d=>d.Name == "Spain");
            home.ToursDes1 = db.Tours.Include("TourImages").Include("TourCity").Where(t=>t.TourCity.DestinationId == home.Destination1.Id).ToList();
            home.Destination2 = db.Destinations.FirstOrDefault(d => d.Name == "Taiwan");
            home.ToursDes2 = db.Tours.Include("TourImages").Include("TourCity").Where(t => t.TourCity.DestinationId == home.Destination2.Id).ToList();
            home.Destination3 = db.Destinations.FirstOrDefault(d => d.Name == "Italy");
            home.ToursDes3 = db.Tours.Include("TourImages").Include("TourCity").Where(t => t.TourCity.DestinationId == home.Destination3.Id).ToList();
            home.TourParis = db.Tours.Include("TourCity").FirstOrDefault(t => t.TourCity.Name == "Paris");
            home.TourTaipei = db.Tours.Include("TourCity").FirstOrDefault(t => t.TourCity.Name == "Taipei");
            ViewBag.Home = true;
            return View(home);
        }

        // USER REGISTRATION //

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Admins.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    return View(user); // redirect where? //
                }

                user.Password = Crypto.HashPassword(user.Password);
                
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();  // redirect where? //
        }

        // USER UPDATE PROFILE AND ADD PHOTO//

        public ActionResult MyPage(int id)
        {
            VmMyPage mypage = new VmMyPage();
            mypage.About = db.Abouts.FirstOrDefault();
            mypage.Blogs = db.Blogs.Where(b => b.UserId == id).ToList();
            mypage.User = db.Users.Include("UserSocials").FirstOrDefault(u=>u.Id==id);
            mypage.UserSocials = db.UserSocials.Where(u => u.UserId == id).ToList();
            ViewBag.MyPage = true;
            return View(mypage);
        }

        [HttpPost]
        public ActionResult UserUpdate(User user)
        {
            if (ModelState.IsValid)
            {
                User userr = db.Users.Find(user.Id);

                if (user.PhotoFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.PhotoFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), userr.Photo);
                    System.IO.File.Delete(OldImagePath);

                    user.PhotoFile.SaveAs(imagePath);
                    userr.Photo = imageName;
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.PhotoFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    user.PhotoFile.SaveAs(imagePath);
                    user.Photo = imageName;
                }

                userr.Password = Crypto.HashPassword(user.Password);
                userr.Fullname = user.Fullname;
                userr.Email = user.Email;
                userr.Phone = user.Phone;

                db.Entry(userr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyPage", new {id=user.Id });
            }

            return RedirectToAction("MyPage", new { id = user.Id });
        }

        // USER LOGN //

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VmLayoutDesLog login)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(a => a.Email == login.Email);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password) == true)
                    {
                        Session["User"] = user;
                        Session["UserId"] = user.Id;
                        //Session.Timeout = 60;
                        return RedirectToAction("Index"); // redirect where? //
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password!");
                        return View(login);  // redirect where? //
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Incorrect Email!");
                    return View(login);  // redirect where? //
                } 
            }

            return View(login);   // redirect where? //
        }

        // USER LOGOUT //

        public ActionResult Logout()
        {
            Session.Clear();
            Session["User"] = null;
            Session["UserId"] = null;

            return RedirectToAction("Index");  // redirect where? //
        }   


        // USER SOCIAL CRUD START //

        [HttpPost]
        public ActionResult UserSocialCreate(VmMyPage model)
        {
            if (ModelState.IsValid)
            {
                UserSocial us = new UserSocial();
                if (!model.UserSocials.Any(s=>s.Link.Contains("twitter")))
                {
                    if (model.Link.Contains("twitter"))
                    {
                        us.Icon = "twitter";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.UserSocials.Add(us);
                    }
                    else
                    {
                        ModelState.AddModelError("Link","It is Not Twitter Link!");
                    }
                }
                if (!model.UserSocials.Any(s => s.Link.Contains("pinterest")))
                {
                    if (model.Link.Contains("pinterest"))
                    {
                        us.Icon = "pinterest";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.UserSocials.Add(us);
                    }
                    else
                    {
                        ModelState.AddModelError("Link", "It is Not Pinterest Link!");
                    }
                }
                if (!model.UserSocials.Any(s => s.Link.Contains("facebook")))
                {
                    if (model.Link.Contains("facebook"))
                    {
                        us.Icon = "facebook";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.UserSocials.Add(us);
                    }
                    else
                    {
                        ModelState.AddModelError("Link", "It is Not Facebook Link!");
                    }
                }
                if (!model.UserSocials.Any(s => s.Link.Contains("instagram")))
                {
                    if (model.Link.Contains("instagram"))
                    {
                        us.Icon = "instagram";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.UserSocials.Add(us);
                    }
                    else
                    {
                        ModelState.AddModelError("Link", "It is Not Instagram Link!");
                    }
                }

                db.SaveChanges();
                return RedirectToAction("MyPage",new { id=model.User.Id});
            }
            return RedirectToAction("MyPage", new { id = model.User.Id });
        }

        [HttpPost]
        public ActionResult UserSocialUpdate(VmMyPage model)
        {
            if (ModelState.IsValid)
            {
                if (model.Link.Contains("twitter") || model.Link.Contains("pinteres") || model.Link.Contains("facebook") || model.Link.Contains("instagram"))
                {
                    UserSocial us = db.UserSocials.Find(model.SocialId);
                    if (model.Link.Contains("twitter"))
                    {
                        us.Icon = "twitter";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.Entry(us).State = EntityState.Modified;
                    }
                    else
                    {
                        ModelState.AddModelError("Link", "It is Not Twitter Link!");
                    }
                    if (model.Link.Contains("pinterest"))
                    {
                        us.Icon = "pinterest";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.Entry(us).State = EntityState.Modified;
                    }
                    else
                    {
                        ModelState.AddModelError("Link", "It is Not Pinterest Link!");
                    }
                    if (model.Link.Contains("facebook"))
                    {
                        us.Icon = "facebook";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.Entry(us).State = EntityState.Modified;
                    }
                    else
                    {
                        ModelState.AddModelError("Link", "It is Not Facebook Link!");
                    }
                    if (model.Link.Contains("instagram"))
                    {
                        us.Icon = "instagram";
                        us.Link = model.Link;
                        us.UserId = (int)Session["UserId"];
                        db.Entry(us).State = EntityState.Modified;
                    }
                    else
                    {
                        ModelState.AddModelError("Link", "It is Not Instagram Link!");
                    }
                }
                else
                {
                    ModelState.AddModelError("Link", "Invalid Link");
                }
               
                db.SaveChanges();
                return RedirectToAction("MyPage", new { id = model.User.Id });
            }

            return RedirectToAction("MyPage", new { id = model.User.Id });
        }

        public ActionResult UserSocialDelete(VmMyPage model)
        {
            UserSocial usocial = db.UserSocials.Find(model.SocialId);
            if (usocial == null)
            {
                return HttpNotFound();
            }

            db.UserSocials.Remove(usocial);
            db.SaveChanges();

            return RedirectToAction("MyPage", new { id = (int)Session["USerId"]});
        }


        // USER SOCIAL CRUD END //

        // MAIN SUBSCRIBTION //

        public ActionResult Subscribe(VmLayoutDesLog details)
        {
            if (string.IsNullOrEmpty(details.Email) || string.IsNullOrEmpty(details.Fullname))
            {
                Session["Empty"] = true;
                return View(); //REDIRECT WHERE
            }
            Subscription Subscribe = new Subscription();
            Subscribe.Email = details.Email;
            Subscribe.Fullname = details.Fullname;
            Subscribe.CreatedDate = DateTime.Now;

            db.Subscriptions.Add(Subscribe);
            db.SaveChanges();

            Session["Subsribed"] = true;

            return View(); // REDIRECT WHERE?
        }

    }
}