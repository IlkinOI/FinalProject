﻿using SetSail.DAL;
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
using System.Web.Mvc.Razor;

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
            home.TourCategories = db.TourCategories.Include("DesToCats").Include("DesToCats.Destination").ToList();
            home.Destinations = db.Destinations.Include("DesToCats").Include("DesToTypes").ToList();
            home.TourCities = db.TourCities.Include("Destination").ToList();
            home.wDesToCats = db.DesToCats.Include("Destination").Include("TourCategory").Where(dc=>dc.TourCategory.Name=="Winter").ToList();
            home.eDesToCats = db.DesToCats.Include("Destination").Include("TourCategory").Where(dc=>dc.TourCategory.Name=="Exotic").ToList();
            home.Tours = db.Tours.Include("TourDates").Include("TourCity").Include("TourCity.Destination").ToList();
            home.TourReviews = db.TourReviews.Include("User").Include("Tour").Include("Tour.TourCity").OrderBy(t=>t.Id).Take(9).ToList();
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
            ViewBag.Page = "Home";
            return View(home);
        }

        // USER REGISTRATION //

        [HttpPost]
        public ActionResult Register(VmLayoutDesLog user)
        {
            if (!string.IsNullOrEmpty(user.RFullname) || !string.IsNullOrEmpty(user.REmail) || 
                !string.IsNullOrEmpty(user.RPhone) || !string.IsNullOrEmpty(user.RPassword))
            {
                if (db.Users.Any(u => u.Email == user.REmail))
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    if (user.Page == "About")
                    {
                        return RedirectToAction("Index", "About");
                    }
                    else if (user.Page == "FAQ")
                    {
                        return RedirectToAction("Index", "FAQ");
                    }
                    else if (user.Page == "Blog")
                    {
                        return RedirectToAction("Index", "Blog");
                    }
                    else if (user.Page == "CreateBlog")
                    {
                        return RedirectToAction("Create", "Blog");
                    }
                    else if (user.Page == "Search")
                    {
                        return RedirectToAction("Search", "Tour");
                    }
                    else if (user.Page == "Summer")
                    {
                        return RedirectToAction("Summer", "Tour");
                    }
                    else if (user.Page == "Winter")
                    {
                        return RedirectToAction("Winter", "Tour");
                    }
                    else if (user.Page == "City")
                    {
                        return RedirectToAction("City", "Tour");
                    }
                    else if (user.Page == "Exotic")
                    {
                        return RedirectToAction("Exotic", "Tour");
                    }
                    else if (user.Page == "Wine")
                    {
                        return RedirectToAction("Wine", "Tour");
                    }
                    else if (user.Page == "Destinations")
                    {
                        return RedirectToAction("Destinations", "Tour");
                    }
                    else if (user.Page == "UpdateBlog")
                    {
                        return RedirectToAction("Update", "Blog", new { id = user.pdId });
                    }
                    else if (user.Page == "BlogDetails")
                    {
                        return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)user.pdId });
                    }
                    else if (user.Page == "MyPage")
                    {
                        return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
                    }
                    else if (user.Page == "DestinationDetails")
                    {
                        return RedirectToAction("BlogDetails", "Blog", new { id = (int)user.pdId });
                    }
                    else if (user.Page == "TourDetails")
                    {
                        return RedirectToAction("TourDetailIndex", "BlTourog", new { id = (int)user.pdId });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                
                User User = new User();

                if (user.RPhotoFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    if (user.Page == "About")
                    {
                        return RedirectToAction("Index", "About");
                    }
                    else if (user.Page == "FAQ")
                    {
                        return RedirectToAction("FAQ", "About");
                    }
                    else if (user.Page == "Blog")
                    {
                        return RedirectToAction("Index", "Blog");
                    }
                    else if (user.Page == "CreateBlog")
                    {
                        return RedirectToAction("Create", "Blog");
                    }
                    else if (user.Page == "Search")
                    {
                        return RedirectToAction("Search", "Tour");
                    }
                    else if (user.Page == "Summer")
                    {
                        return RedirectToAction("Summer", "Tour");
                    }
                    else if (user.Page == "Winter")
                    {
                        return RedirectToAction("Winter", "Tour");
                    }
                    else if (user.Page == "City")
                    {
                        return RedirectToAction("City", "Tour");
                    }
                    else if (user.Page == "Exotic")
                    {
                        return RedirectToAction("Exotic", "Tour");
                    }
                    else if (user.Page == "Wine")
                    {
                        return RedirectToAction("Wine", "Tour");
                    }
                    else if (user.Page == "Destinations")
                    {
                        return RedirectToAction("Destinations", "Tour");
                    }
                    else if (user.Page == "Contact")
                    {
                        return RedirectToAction("Index", "Contact");
                    }
                    else if (user.Page == "UpdateBlog")
                    {
                        return RedirectToAction("Update", "Blog", new { id = (int)user.pdId });
                    }
                    else if (user.Page == "BlogDetails")
                    {
                        return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)user.pdId });
                    }
                    else if (user.Page == "MyPage")
                    {
                        return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
                    }
                    else if (user.Page == "DestinationDetails")
                    {
                        return RedirectToAction("DestinationDetails", "Tour", new { id = (int)user.pdId });
                    }
                    else if (user.Page == "TourDetails")
                    {
                        return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)user.pdId });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                string pimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.RPhotoFile.FileName;
                string pimagePath = Path.Combine(Server.MapPath("~/Uploads/"), pimageName);

                user.RPhotoFile.SaveAs(pimagePath);
                User.Photo = pimageName;

                User.Fullname = user.RFullname;
                User.Email = user.REmail;
                User.Phone = user.RPhone;
                User.CreatedDate = DateTime.Now;

                User.Password = Crypto.HashPassword(user.RPassword);
                
                db.Users.Add(User);
                db.SaveChanges();
                if (user.Page == "About")
                {
                    return RedirectToAction("Index", "About");
                }
                else if (user.Page == "FAQ")
                {
                    return RedirectToAction("FAQ", "About");
                }
                else if (user.Page == "Blog")
                {
                    return RedirectToAction("Index", "Blog");
                }
                else if (user.Page == "CreateBlog")
                {
                    return RedirectToAction("Create", "Blog");
                }
                else if (user.Page == "Search")
                {
                    return RedirectToAction("Search", "Tour");
                }
                else if (user.Page == "Summer")
                {
                    return RedirectToAction("Summer", "Tour");
                }
                else if (user.Page == "Winter")
                {
                    return RedirectToAction("Winter", "Tour");
                }
                else if (user.Page == "City")
                {
                    return RedirectToAction("City", "Tour");
                }
                else if (user.Page == "Exotic")
                {
                    return RedirectToAction("Exotic", "Tour");
                }
                else if (user.Page == "Wine")
                {
                    return RedirectToAction("Wine", "Tour");
                }
                else if (user.Page == "Destinations")
                {
                    return RedirectToAction("Destinations", "Tour");
                }
                else if (user.Page == "Contact")
                {
                    return RedirectToAction("Index", "Contact");
                }
                else if (user.Page == "UpdateBlog")
                {
                    return RedirectToAction("Update", "Blog", new { id = (int)user.pdId });
                }
                else if (user.Page == "BlogDetails")
                {
                    return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)user.pdId });
                }
                else if (user.Page == "MyPage")
                {
                    return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
                }
                else if (user.Page == "DestinationDetails")
                {
                    return RedirectToAction("DestinationDetails", "Tour", new { id = (int)user.pdId });
                }
                else if (user.Page == "TourDetails")
                {
                    return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)user.pdId });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            if (user.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }
            else if (user.Page == "FAQ")
            {
                return RedirectToAction("FAQ", "About");
            }
            else if (user.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }
            else if (user.Page == "CreateBlog")
            {
                return RedirectToAction("Create", "Blog");
            }
            else if (user.Page == "Search")
            {
                return RedirectToAction("Search", "Tour");
            }
            else if (user.Page == "Summer")
            {
                return RedirectToAction("Summer", "Tour");
            }
            else if (user.Page == "Winter")
            {
                return RedirectToAction("Winter", "Tour");
            }
            else if (user.Page == "City")
            {
                return RedirectToAction("City", "Tour");
            }
            else if (user.Page == "Exotic")
            {
                return RedirectToAction("Exotic", "Tour");
            }
            else if (user.Page == "Wine")
            {
                return RedirectToAction("Wine", "Tour");
            }
            else if (user.Page == "Destinations")
            {
                return RedirectToAction("Destinations", "Tour");
            }
            else if (user.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else if (user.Page == "UpdateBlog")
            {
                return RedirectToAction("Update", "Blog", new { id = (int)user.pdId });
            }
            else if (user.Page == "BlogDetails")
            {
                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)user.pdId });
            }
            else if (user.Page == "MyPage")
            {
                return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
            }
            else if (user.Page == "DestinationDetails")
            {
                return RedirectToAction("DestinationDetails", "Tour", new { id = (int)user.pdId });
            }
            else if (user.Page == "TourDetails")
            {
                return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)user.pdId });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
            ViewBag.Page = "MyPage";
            return View(mypage);
        }

        [HttpPost]
        public ActionResult UserUpdate(VmMyPage user)
        {
                User userr = db.Users.Find(user.UserId);

                if (user.PhotoFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.User.PhotoFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), userr.Photo);
                    System.IO.File.Delete(OldImagePath);

                    user.User.PhotoFile.SaveAs(imagePath);
                    userr.Photo = imageName;
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.User.PhotoFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    userr.PhotoFile.SaveAs(imagePath);
                    userr.Photo = imageName;
                }

                userr.Password = Crypto.HashPassword(user.Password);
                userr.Fullname = user.User.Fullname;
                userr.Email = user.User.Email;
                userr.Phone = user.User.Phone;

                db.Entry(userr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyPage","Home", new { id = (int)Session["UserId"] });
        }

        // USER LOGN //

        [HttpPost]
        public ActionResult Login(VmLayoutDesLog login)
        {
            if (!string.IsNullOrEmpty(login.lFullname) || !string.IsNullOrEmpty(login.lEmail) ||
                !string.IsNullOrEmpty(login.lPassword))
            {
                User user = db.Users.FirstOrDefault(a => a.Email == login.lEmail);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.lPassword) == true)
                    {
                        Session["User"] = user;
                        Session["UserId"] = user.Id;
                        Session.Timeout = 600;
                        if (login.Page == "About")
                        {
                            return RedirectToAction("Index", "About");
                        }
                        else if (login.Page == "FAQ")
                        {
                            return RedirectToAction("FAQ", "About");
                        }
                        else if (login.Page == "Blog")
                        {
                            return RedirectToAction("Index", "Blog");
                        }
                        else if (login.Page == "CreateBlog")
                        {
                            return RedirectToAction("Create", "Blog");
                        }
                        else if (login.Page == "Search")
                        {
                            return RedirectToAction("Search", "Tour");
                        }
                        else if (login.Page == "Summer")
                        {
                            return RedirectToAction("Summer", "Tour");
                        }
                        else if (login.Page == "Winter")
                        {
                            return RedirectToAction("Winter", "Tour");
                        }
                        else if (login.Page == "City")
                        {
                            return RedirectToAction("City", "Tour");
                        }
                        else if (login.Page == "Exotic")
                        {
                            return RedirectToAction("Exotic", "Tour");
                        }
                        else if (login.Page == "Wine")
                        {
                            return RedirectToAction("Wine", "Tour");
                        }
                        else if (login.Page == "Contact")
                        {
                            return RedirectToAction("Index", "Contact");
                        }
                        else if (login.Page == "Destinations")
                        {
                            return RedirectToAction("Destinations", "Tour");
                        }
                        else if (login.Page == "BlogDetails")
                        {
                            return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)login.pdId });
                        }
                        else if (login.Page == "MyPage")
                        {
                            return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
                        }
                        else if (login.Page == "DestinationDetails")
                        {
                            return RedirectToAction("DestinationDetails", "Tour", new { id = (int)login.pdId });
                        }
                        else if (login.Page == "TourDetails")
                        {
                            return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)login.pdId });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        Session["WrongPass"] = true;
                        ModelState.AddModelError("Password", "Incorrect Password!");
                        if (login.Page == "About")
                        {
                            return RedirectToAction("Index", "About");
                        }
                        else if (login.Page == "FAQ")
                        {
                            return RedirectToAction("FAQ", "About");
                        }
                        else if (login.Page == "Blog")
                        {
                            return RedirectToAction("Index", "Blog");
                        }
                        else if (login.Page == "CreateBlog")
                        {
                            return RedirectToAction("Create", "Blog");
                        }
                        else if (login.Page == "Search")
                        {
                            return RedirectToAction("Search", "Tour");
                        }
                        else if (login.Page == "Summer")
                        {
                            return RedirectToAction("Summer", "Tour");
                        }
                        else if (login.Page == "Winter")
                        {
                            return RedirectToAction("Winter", "Tour");
                        }
                        else if (login.Page == "City")
                        {
                            return RedirectToAction("City", "Tour");
                        }
                        else if (login.Page == "Exotic")
                        {
                            return RedirectToAction("Exotic", "Tour");
                        }
                        else if (login.Page == "Wine")
                        {
                            return RedirectToAction("Wine", "Tour");
                        }
                        else if (login.Page == "Destinations")
                        {
                            return RedirectToAction("Destinations", "Tour");
                        }
                        else if (login.Page == "Contact")
                        {
                            return RedirectToAction("Index", "Contact");
                        }
                        else if (login.Page == "BlogDetails")
                        {
                            return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)login.pdId });
                        }
                        else if (login.Page == "MyPage")
                        {
                            return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
                        }
                        else if (login.Page == "DestinationDetails")
                        {
                            return RedirectToAction("DestinationDetails", "Tour", new { id = (int)login.pdId });
                        }
                        else if (login.Page == "TourDetails")
                        {
                            return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)login.pdId });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Incorrect Email!");
                    if (login.Page == "About")
                    {
                        return RedirectToAction("Index", "About");
                    }
                    else if (login.Page == "FAQ")
                    {
                        return RedirectToAction("FAQ", "About");
                    }
                    else if (login.Page == "Blog")
                    {
                        return RedirectToAction("Index", "Blog");
                    }
                    else if (login.Page == "CreateBlog")
                    {
                        return RedirectToAction("Create", "Blog");
                    }
                    else if (login.Page == "Search")
                    {
                        return RedirectToAction("Search", "Tour");
                    }
                    else if (login.Page == "Summer")
                    {
                        return RedirectToAction("Summer", "Tour");
                    }
                    else if (login.Page == "Winter")
                    {
                        return RedirectToAction("Winter", "Tour");
                    }
                    else if (login.Page == "City")
                    {
                        return RedirectToAction("City", "Tour");
                    }
                    else if (login.Page == "Exotic")
                    {
                        return RedirectToAction("Exotic", "Tour");
                    }
                    else if (login.Page == "Wine")
                    {
                        return RedirectToAction("Wine", "Tour");
                    }
                    else if (login.Page == "Destinations")
                    {
                        return RedirectToAction("Destinations", "Tour");
                    }
                    else if (login.Page == "Contact")
                    {
                        return RedirectToAction("Index", "Contact");
                    }
                    else if (login.Page == "BlogDetails")
                    {
                        return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)login.pdId });
                    }
                    else if (login.Page == "MyPage")
                    {
                        return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
                    }
                    else if (login.Page == "DestinationDetails")
                    {
                        return RedirectToAction("DestinationDetails", "Tour", new { id = (int)login.pdId });
                    }
                    else if (login.Page == "TourDetails")
                    {
                        return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)login.pdId });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                } 
            }

            if (login.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }
            else if (login.Page == "FAQ")
            {
                return RedirectToAction("FAQ", "About");
            }
            else if (login.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }
            else if (login.Page == "CreateBlog")
            {
                return RedirectToAction("Create", "Blog");
            }
            else if (login.Page == "Search")
            {
                return RedirectToAction("Search", "Tour");
            }
            else if (login.Page == "Summer")
            {
                return RedirectToAction("Summer", "Tour");
            }
            else if (login.Page == "Winter")
            {
                return RedirectToAction("Winter", "Tour");
            }
            else if (login.Page == "City")
            {
                return RedirectToAction("City", "Tour");
            }
            else if (login.Page == "Exotic")
            {
                return RedirectToAction("Exotic", "Tour");
            }
            else if (login.Page == "Wine")
            {
                return RedirectToAction("Wine", "Tour");
            }
            else if (login.Page == "Destinations")
            {
                return RedirectToAction("Destinations", "Tour");
            }
            else if (login.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else if (login.Page == "BlogDetails")
            {
                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)login.pdId });
            }
            else if (login.Page == "MyPage")
            {
                return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
            }
            else if (login.Page == "DestinationDetails")
            {
                return RedirectToAction("DestinationDetails", "Tour", new { id = (int)login.pdId });
            }
            else if (login.Page == "TourDetails")
            {
                return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)login.pdId });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // USER LOGOUT //

        public ActionResult Logout(VmLayoutDesLog logout)
        {
            Session.Clear();
            Session["User"] = null;
            Session["UserId"] = null;

            if (logout.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }
            else if (logout.Page == "FAQ")
            {
                return RedirectToAction("FAQ", "About");
            }
            else if (logout.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }
            else if (logout.Page == "CreateBlog")
            {
                return RedirectToAction("Create", "Blog");
            }
            else if (logout.Page == "Search")
            {
                return RedirectToAction("Search", "Tour");
            }
            else if (logout.Page == "Summer")
            {
                return RedirectToAction("Summer", "Tour");
            }
            else if (logout.Page == "Winter")
            {
                return RedirectToAction("Winter", "Tour");
            }
            else if (logout.Page == "City")
            {
                return RedirectToAction("City", "Tour");
            }
            else if (logout.Page == "Exotic")
            {
                return RedirectToAction("Exotic", "Tour");
            }
            else if (logout.Page == "Wine")
            {
                return RedirectToAction("Wine", "Tour");
            }
            else if (logout.Page == "Destinations")
            {
                return RedirectToAction("Destinations", "Tour");
            }
            else if (logout.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else if (logout.Page == "BlogDetails")
            {
                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)logout.pdId });
            }
            else if (logout.Page == "MyPage")
            {
                return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
            }
            else if (logout.Page == "DestinationDetails")
            {
                return RedirectToAction("DestinationDetails", "Tour", new { id = (int)logout.pdId });
            }
            else if (logout.Page == "TourDetails")
            {
                return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)logout.pdId });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }   


        // USER SOCIAL CRUD START //

        [HttpPost]
        public ActionResult UserSocialCreate(VmMyPage model)
        {
            if (!string.IsNullOrEmpty(model.Link))
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
                return RedirectToAction("MyPage","Home",new { id= (int)Session["UserId"] });
            }
            return RedirectToAction("MyPage","Home", new { id = (int)Session["UserId"] });
        }

        [HttpPost]
        public ActionResult UserSocialUpdate(VmMyPage model)
        {
            if (ModelState.IsValid)
            {
                if (model.Link.Contains("twitter") || model.Link.Contains("pinteres") || model.Link.Contains("facebook") || model.Link.Contains("instagram"))
                {
                    
                    if (model.Link.Contains("twitter"))
                    {
                        UserSocial us = db.UserSocials.Find(model.SocialId);
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
                        UserSocial us = db.UserSocials.Find(model.SocialId);
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
                        UserSocial us = db.UserSocials.Find(model.SocialId);
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
                        UserSocial us = db.UserSocials.Find(model.SocialId);
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
                return RedirectToAction("MyPage","Home", new { id = (int)Session["UserId"] });
            }

            return RedirectToAction("MyPage","Home", new { id = (int)Session["UserId"] });
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

            return RedirectToAction("MyPage","Home", new { id = (int)Session["UserId"]});
        }


        // USER SOCIAL CRUD END //

        // MAIN SUBSCRIBTION //

        public ActionResult Subscribe(VmLayoutDesLog subscribe)
        {
            if (string.IsNullOrEmpty(subscribe.sEmail) || string.IsNullOrEmpty(subscribe.sFullname))
            {
                Session["Empty"] = true;
                if (subscribe.Page == "About")
                {
                    return RedirectToAction("Index", "About");
                }
                else if (subscribe.Page == "FAQ")
                {
                    return RedirectToAction("FAQ", "About");
                }
                else if (subscribe.Page == "Blog")
                {
                    return RedirectToAction("Index", "Blog");
                }
                else if (subscribe.Page == "CreateBlog")
                {
                    return RedirectToAction("Create", "Blog");
                }
                else if (subscribe.Page == "Search")
                {
                    return RedirectToAction("Search", "Tour");
                }
                else if (subscribe.Page == "Summer")
                {
                    return RedirectToAction("Summer", "Tour");
                }
                else if (subscribe.Page == "Winter")
                {
                    return RedirectToAction("Winter", "Tour");
                }
                else if (subscribe.Page == "City")
                {
                    return RedirectToAction("City", "Tour");
                }
                else if (subscribe.Page == "Exotic")
                {
                    return RedirectToAction("Exotic", "Tour");
                }
                else if (subscribe.Page == "Wine")
                {
                    return RedirectToAction("Wine", "Tour");
                }
                else if (subscribe.Page == "Contact")
                {
                    return RedirectToAction("Index", "Contact");
                }
                else if (subscribe.Page == "BlogDetails")
                {
                    return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)subscribe.pdId });
                }
                else if (subscribe.Page == "MyPage")
                {
                    return RedirectToAction("MyPage", "Home",new { id = (int)Session["UserId"]});
                }
                else if (subscribe.Page == "DestinationDetails")
                {
                    return RedirectToAction("DestinationDetails", "Tour", new { id = (int)subscribe.pdId });
                }
                else if (subscribe.Page == "TourDetails")
                {
                    return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)subscribe.pdId });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            Subscription Subscribtion = new Subscription();
            Subscribtion.Email = subscribe.sEmail;
            Subscribtion.Fullname = subscribe.sFullname;
            Subscribtion.CreatedDate = DateTime.Now;

            db.Subscriptions.Add(Subscribtion);
            db.SaveChanges();

            Session["Subsribed"] = true;

            if (subscribe.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }
            else if (subscribe.Page == "FAQ")
            {
                return RedirectToAction("FAQ", "About");
            }
            else if (subscribe.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }
            else if (subscribe.Page == "CreateBlog")
            {
                return RedirectToAction("Create", "Blog");
            }
            else if (subscribe.Page == "Search")
            {
                return RedirectToAction("Search", "Tour");
            }
            else if (subscribe.Page == "Summer")
            {
                return RedirectToAction("Summer", "Tour");
            }
            else if (subscribe.Page == "Winter")
            {
                return RedirectToAction("Winter", "Tour");
            }
            else if (subscribe.Page == "City")
            {
                return RedirectToAction("City", "Tour");
            }
            else if (subscribe.Page == "Exotic")
            {
                return RedirectToAction("Exotic", "Tour");
            }
            else if (subscribe.Page == "Wine")
            {
                return RedirectToAction("Wine", "Tour");
            }
            else if (subscribe.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else if (subscribe.Page == "BlogDetails")
            {
                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = (int)subscribe.pdId });
            }
            else if (subscribe.Page == "MyPage")
            {
                return RedirectToAction("MyPage", "Home", new { id = (int)Session["UserId"] });
            }
            else if (subscribe.Page == "DestinationDetails")
            {
                return RedirectToAction("DestinationDetails", "Tour", new { id = (int)subscribe.pdId });
            }
            else if (subscribe.Page == "TourDetails")
            {
                return RedirectToAction("TourDetailIndex", "Tour", new { id = (int)subscribe.pdId });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}