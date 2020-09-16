using SetSail.Areas.Administrator.Filters;
using SetSail.DAL;
using SetSail.Models;
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
    [filterAdmin]
    public class AdminController : Controller
    {
        // GET: Administrator/Admin
        SetSailContext db = new SetSailContext();
        public ActionResult Index()
        {
            List<Admin> admins = db.Admins.ToList();
            return View(admins);
        }
        public ActionResult Details(int id)
        {
            Admin admin = db.Admins.Find(id);

            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // ADMIN UPDATE PROFILE //

        public ActionResult Update(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }

        [HttpPost]
        public ActionResult Update(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin admin1 = db.Admins.Find(admin.Id);
                if (admin.PhotoFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.PhotoFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), admin1.Photo);
                    System.IO.File.Delete(oldImagePath);

                    admin.PhotoFile.SaveAs(imagePath);
                    admin1.Photo = imageName;
                }
                admin1.Password = Crypto.HashPassword(admin.Password);

                admin1.Fullname = admin.Fullname;
                admin1.Email = admin.Email;
                admin1.Phone = admin.Phone;

                db.Entry(admin1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // ADMIN DELETE PROFILE//
        public ActionResult Delete(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            db.Admins.Remove(admin);
            db.SaveChanges();

            return RedirectToAction("Login","Home");
        }
    }
}