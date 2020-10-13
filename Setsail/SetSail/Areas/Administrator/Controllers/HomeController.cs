using SetSail.Areas.Administrator.Filters;
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

namespace SetSail.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administrator/Home
        SetSailContext db = new SetSailContext();

        [filterAdmin]
        public ActionResult Index()
        {
            return View();
        }

        // ADMIN REGISTRATION //

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (db.Admins.Any(u => u.Email == admin.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    return View(admin);
                }

                if (admin.PhotoFile == null)
                {
                    ModelState.AddModelError("", "Photo is requred!");
                    return View(admin);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.PhotoFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                admin.PhotoFile.SaveAs(imagePath);
                admin.Photo = imageName;

                admin.Password = Crypto.HashPassword(admin.Password);

                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        // ADMIN LOGIN //

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VmAdminLogin login)
        {
            if (ModelState.IsValid)
            {
                Admin admin = db.Admins.FirstOrDefault(a => a.Email == login.Email);
                if (admin != null)
                {
                    if (Crypto.VerifyHashedPassword(admin.Password, login.Password) == true)
                    {
                        Session["Admin"] = admin;
                        Session["AdminId"] = admin.Id;
                        Session.Timeout = 600;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password!");
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "No user found!");
                    return View(login);
                }
            }

            return View(login);
        }

        // ADMIN LOGOUT //

        public ActionResult Logout()
        {
            Session.Clear();
            Session["Admin"] = null;
            Session["AdminId"] = null;

            return RedirectToAction("Login"); ;
        }

        // USER RD START //
        [filterAdmin]
        public ActionResult UserIndex()
        {
            List<User> users = db.Users.ToList();
            return View(users);
        }

        public ActionResult UserDelete(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (user.PhotoFile != null)
            {
                string photo = Path.Combine(Server.MapPath("~/Uploads/"), user.Photo);
                System.IO.File.Delete(photo);
            }
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("UserIndex");
        }
    }
}