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

namespace SetSail.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        SetSailContext db = new SetSailContext();
        public ActionResult Index(int page=1)  // Blogs page //
        {
            VmBlogs blogs = new VmBlogs();
            blogs.About = db.Abouts.FirstOrDefault();
            blogs.Blogs = db.Blogs.Include("User").Include("BlogComments").OrderByDescending(o => o.Id).Skip((page - 1) * 4).Take(4).ToList();
            blogs.CurrentPage = page;
            blogs.PageCount = Convert.ToInt32(Math.Ceiling(db.Blogs.Count() / 4.0));
            ViewBag.Blog = true;
            ViewBag.Page = "Blog";
            return View(blogs);
        }

        public ActionResult BlogDetailsIndex(int id)  // Blog Details Page //
        {
            VmBlogDetails bldet = new VmBlogDetails();
            bldet.Blog = db.Blogs.Include("BlogComments").Include("User").Include("User.UserSocials").FirstOrDefault(b=>b.Id==id);
            bldet.BlogComments = db.BlogComments.Include("User").Include("Blog").Where(bc=>bc.BlogId==id).ToList();
            bldet.BlogCategories = db.BlogCategories.ToList();
            bldet.LatestBlogs = db.Blogs.OrderByDescending(b => b.Id).Take(3).ToList();
            ViewBag.Blog = true;
            ViewBag.Id = id;
            ViewBag.Page = "BlogDetails";
            return View(bldet);
        }

        // BLOG CRUD //
        public ActionResult Create()
        {
            ViewBag.Categories = db.BlogCategories.ToList();
            ViewBag.MyPage = true;
            ViewBag.Page = "CreateBlog";
            return View();
        }    
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                if (blog.BgImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(blog);
                }
                string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.BgImageFile.FileName;
                string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                blog.BgImageFile.SaveAs(bgimagePath);
                blog.BgImage = bgimageName;

                if (blog.MainImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(blog);
                }
                string mimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.MainImageFile.FileName;
                string mgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), mimageName);

                blog.MainImageFile.SaveAs(mgimagePath);
                blog.MainImage = mimageName;

                if (blog.Image1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(blog);
                }
                string image1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.Image1File.FileName;
                string image1Path = Path.Combine(Server.MapPath("~/Uploads/"), image1Name);

                blog.Image1File.SaveAs(image1Path);
                blog.Image1 = image1Name;

                if (blog.Image2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(blog);
                }
                string image2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.Image2File.FileName;
                string image2Path = Path.Combine(Server.MapPath("~/Uploads/"), image2Name);

                blog.Image2File.SaveAs(image2Path);
                blog.Image2 = image2Name;

                blog.CreatedDate = DateTime.Now;
                blog.UserId = (int)Session["UserId"];

                db.Blogs.Add(blog);
                db.SaveChanges();

                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = blog.Id });
            }
            return View(blog);
        }
        public ActionResult Update(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.BlogCategories.ToList();
            ViewBag.MyPage = true;
            ViewBag.Page = "UpdateBlog";
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

                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = blog.Id });
            }

            return View(blog);
        }

        public ActionResult Delete(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            db.Blogs.Remove(blog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // BLOG CRUD END //

        // BLOG COMMENT CRUD START //
        
        [HttpPost]
        public ActionResult BlogComment(VmBlogDetails vmbc)
        {
            if (string.IsNullOrEmpty(vmbc.Message))
            {
                Session["EmptyComment"] = true;
                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = vmbc.BlogId });
            }
            if (Session["User"]!=null)
            {
                BlogComment bc = new BlogComment();
                
                bc.Message = vmbc.Message;
                bc.BlogId = vmbc.BlogId;
                bc.CreatedDate = DateTime.Now;
                bc.UserId = (int)Session["UserId"];

                db.BlogComments.Add(bc);
                db.SaveChanges();

                Session["BlogCommentSent"] = true;
            }
            return RedirectToAction("BlogDetailsIndex", "Blog", new { id = vmbc.BlogId });
        }

        // BLOG COMMENT CRUD END //

        // SUBSCRIOTION BLOG DETAILS START//

        public ActionResult Subscribe(VmBlogDetails details)
        {
            if (string.IsNullOrEmpty(details.SubEmail) || string.IsNullOrEmpty(details.SubFullname))
            {
                Session["Empty"] = true;
                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = details.BlogId });
            }
            Subscription Subscribe = new Subscription();
            Subscribe.Email = details.SubEmail;
            Subscribe.Fullname = details.SubFullname;
            Subscribe.CreatedDate = DateTime.Now;

            db.Subscriptions.Add(Subscribe);
            db.SaveChanges();

            Session["Subsribed"] = true;

            return RedirectToAction("BlogDetailsIndex", "Blog", new { id = details.BlogId });
        }

        // SUBSCRIPTION BLOD DETAILS END //
    }
}