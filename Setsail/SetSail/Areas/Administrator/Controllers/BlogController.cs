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
using System.Web.Mvc;

namespace SetSail.Areas.Administrator.Controllers
{
    [filterAdmin]
    public class BlogController : Controller
    {
        // GET: Administrator/Blog
        SetSailContext db = new SetSailContext();


        //Blog Category CRUD START//


        public ActionResult BlogCategoryIndex()
        {
            List<BlogCategory> bcs = db.BlogCategories.ToList();
            return View(bcs);
        }
        public ActionResult BlogCategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogCategoryCreate(BlogCategory bc)
        {
            if (ModelState.IsValid)
            {
                db.BlogCategories.Add(bc);
                db.SaveChanges();

                return RedirectToAction("BlogCategoryIndex");
            }

            return View(bc);
        }

        public ActionResult BlogCategoryUpdate(int id)
        {
            BlogCategory bc = db.BlogCategories.Find(id);
            if (bc == null)
            {
                return HttpNotFound();
            }

            return View(bc);
        }

        [HttpPost]
        public ActionResult BlogCategoryUpdate(BlogCategory bc)
        {
            if (ModelState.IsValid)
            {

                db.Entry(bc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BlogCategoryIndex");
            }

            return View(bc);
        }

        public ActionResult BlogCategoryDelete(int id)
        {
            BlogCategory bc = db.BlogCategories.Find(id);
            if (bc == null)
            {
                return HttpNotFound();
            }

            db.BlogCategories.Remove(bc);
            db.SaveChanges();

            return RedirectToAction("BlogCategoryIndex");
        }

        //Blog Category CRUD END//


        //Blogs CRUD START//

        public ActionResult Index()
        {
            List<Blog> blogs = db.Blogs.Include("BlogCategory").Include("User").ToList();
            return View(blogs);
        }
        
        public ActionResult Update(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
        }

        [HttpPost]
        public ActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog blogg = db.Blogs.Find(blog.Id);

                if (blog.BgImageFile != null)
                {
                    string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.BgImageFile.FileName;
                    string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                    string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blogg.BgImage);
                    System.IO.File.Delete(OldbgImagePath);

                    blog.BgImageFile.SaveAs(bgimagePath);
                    blogg.BgImage = bgimageName;
                }

                if (blog.MainImageFile != null)
                {
                    string mimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.MainImageFile.FileName;
                    string mimagePath = Path.Combine(Server.MapPath("~/Uploads/"), mimageName);

                    string OldmImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blogg.MainImage);
                    System.IO.File.Delete(OldmImagePath);

                    blog.MainImageFile.SaveAs(mimagePath);
                    blogg.MainImage = mimageName;
                }

                if (blog.Image1File != null)
                {
                    string image1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.Image1File.FileName;
                    string image1Path = Path.Combine(Server.MapPath("~/Uploads/"), image1Name);

                    string OldImage1Path = Path.Combine(Server.MapPath("~/Uploads/"), blogg.Image1);
                    System.IO.File.Delete(OldImage1Path);

                    blog.Image1File.SaveAs(image1Path);
                    blogg.Image1 = image1Name;
                }

                if (blog.Image2File != null)
                {
                    string image2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.Image2File.FileName;
                    string image2Path = Path.Combine(Server.MapPath("~/Uploads/"), image2Name);

                    string OldImage2Path = Path.Combine(Server.MapPath("~/Uploads/"), blogg.Image2);
                    System.IO.File.Delete(OldImage2Path);

                    blog.Image2File.SaveAs(image2Path);
                    blogg.Image2 = image2Name;
                }

                blogg.TopText = blog.TopText;
                blogg.BlogCategoryId = blog.BlogCategoryId;
                blogg.UserId = blog.UserId;
                blogg.Text1 = blog.Text1;
                blogg.Text2 = blog.Text2;
                blogg.Text3 = blog.Text3;
                blogg.Quote = blog.Quote;

                db.Entry(blogg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
        }

        public ActionResult Delete(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            if (blog.BgImageFile != null)
            {
                string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blog.BgImage);
                System.IO.File.Delete(OldbgImagePath);
            }

            if (blog.MainImageFile != null)
            {
                string OldmImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blog.MainImage);
                System.IO.File.Delete(OldmImagePath);
            }

            if (blog.Image1File != null)
            {
                string OldImage1Path = Path.Combine(Server.MapPath("~/Uploads/"), blog.Image1);
                System.IO.File.Delete(OldImage1Path);
            }

            if (blog.Image2File != null)
            {
                string OldImage2Path = Path.Combine(Server.MapPath("~/Uploads/"), blog.Image2);
                System.IO.File.Delete(OldImage2Path);
            }
            db.Blogs.Remove(blog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // BLOG CRUD  END//

        // BLOG COMMENT RD START //

        public ActionResult BlogCommentIndex()
        {
            List<BlogComment> comments = db.BlogComments.ToList();
            return View(comments);
        }

        public ActionResult BlogCommentDelete(int id)
        {
            BlogComment bc = db.BlogComments.Find(id);
            if (bc == null)
            {
                return HttpNotFound();
            }

            db.BlogComments.Remove(bc);
            db.SaveChanges();

            return RedirectToAction("BlogCommentIndex");
        }

        // BLOG COMMENT RD END //

    }
}