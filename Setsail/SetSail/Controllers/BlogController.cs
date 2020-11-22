using SetSail.DAL;
using SetSail.Filters;
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
        public ActionResult Index(string search,int page=1)  // Blogs page //
        {
            VmBlogs blogs = new VmBlogs();
            blogs.About = db.Abouts.FirstOrDefault();
            blogs.Blogs = db.Blogs.Include("User").Include("BlogComments")
                          .Where(b=>
                          (!string.IsNullOrEmpty(search)? b.Name.Contains(search): true) ||
                          (!string.IsNullOrEmpty(search) ? b.BlogCategory.Name.Contains(search) : true) ||
                          (!string.IsNullOrEmpty(search) ? b.Quote.Contains(search) : true) ||
                          (!string.IsNullOrEmpty(search) ? b.TopText.Contains(search) : true) ||
                          (!string.IsNullOrEmpty(search) ? b.Text1.Contains(search) : true) ||
                          (!string.IsNullOrEmpty(search) ? b.Text2.Contains(search) : true) ||
                          (!string.IsNullOrEmpty(search) ? b.Text3.Contains(search) : true) ||
                          (!string.IsNullOrEmpty(search) ? b.User.Fullname.Contains(search) : true))
                          .OrderByDescending(o => o.Id).Skip((page - 1) * 3).Take(3).ToList();
            blogs.LatestTours = db.Tours.OrderByDescending(t => t.Id).Take(8).ToList();
            blogs.CurrentPage = page;
            blogs.PageCount = Convert.ToInt32(Math.Ceiling(db.Blogs.Count() / 3.0));
            ViewBag.Blog = true;
            ViewBag.Page = "Blog";
            return View(blogs);
        }

        public ActionResult BlogDetailsIndex(int id)  // Blog Details Page //
        {
            VmBlogDetails bldet = new VmBlogDetails();
            bldet.Blog = db.Blogs.Include("BlogComments").Include("BlogComments.User").Include("User").FirstOrDefault(b=>b.Id==id);
            bldet.BlogCategories = db.BlogCategories.ToList();
            bldet.LatestBlogs = db.Blogs.OrderByDescending(b => b.Id).Take(3).ToList();
            ViewBag.Blog = true;
            ViewBag.Id = id;
            ViewBag.Page = "BlogDetails";
            return View(bldet);
        }

        // BLOG CRUD //
        [filterUser]
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
        [filterUser]
        public ActionResult Update(VmLayoutDesLog blogonly,int id)
        {
            blogonly.Blog= db.Blogs.Include("BlogCategory").FirstOrDefault(b=>b.Id==id);

            if (blogonly.Blog == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.MyPage = true;
            ViewBag.Page = "UpdateBlog";
            ViewBag.Categories = db.BlogCategories.Include("Blogs").ToList();
            return View(blogonly);
        }

        [HttpPost]
        public ActionResult Update(VmLayoutDesLog blogonly)
        {
            if (!string.IsNullOrEmpty(blogonly.Blog.Name) || !string.IsNullOrEmpty(blogonly.Blog.TopText) ||
                !string.IsNullOrEmpty(blogonly.Blog.Text1) || !string.IsNullOrEmpty(blogonly.Blog.Text2) ||
                !string.IsNullOrEmpty(blogonly.Blog.Text3) || !string.IsNullOrEmpty(blogonly.Blog.Quote))
            {
                Blog blogg = db.Blogs.Include("BlogCategory").FirstOrDefault(b => b.Id == blogonly.bblogId);
                if (blogonly.Blog.BgImageFile != null)
                {
                    string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blogonly.Blog.BgImageFile.FileName;
                    string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                    string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blogg.BgImage);
                    System.IO.File.Delete(OldbgImagePath);

                    blogonly.Blog.BgImageFile.SaveAs(bgimagePath);
                    blogg.BgImage = bgimageName;
                }

                if (blogonly.Blog.MainImageFile != null)
                {
                    string mimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blogonly.Blog.MainImageFile.FileName;
                    string mimagePath = Path.Combine(Server.MapPath("~/Uploads/"), mimageName);

                    string OldmImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blogg.MainImage);
                    System.IO.File.Delete(OldmImagePath);

                    blogonly.Blog.MainImageFile.SaveAs(mimagePath);
                    blogg.MainImage = mimageName;
                }

                if (blogonly.Blog.Image1File != null)
                {
                    string image1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blogonly.Blog.Image1File.FileName;
                    string image1Path = Path.Combine(Server.MapPath("~/Uploads/"), image1Name);

                    string OldImage1Path = Path.Combine(Server.MapPath("~/Uploads/"), blogg.Image1);
                    System.IO.File.Delete(OldImage1Path);

                    blogonly.Blog.Image1File.SaveAs(image1Path);
                    blogg.Image1 = image1Name;
                }

                if (blogonly.Blog.Image2File != null)
                {
                    string image2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blogonly.Blog.Image2File.FileName;
                    string image2Path = Path.Combine(Server.MapPath("~/Uploads/"), image2Name);

                    string OldImage2Path = Path.Combine(Server.MapPath("~/Uploads/"), blogg.Image2);
                    System.IO.File.Delete(OldImage2Path);

                    blogonly.Blog.Image2File.SaveAs(image2Path);
                    blogg.Image2 = image2Name;
                }

                blogg.Name = blogonly.Blog.Name;
                blogg.TopText = blogonly.Blog.TopText;
                blogg.BlogCategoryId = blogonly.BlogCategoryId;
                blogg.UserId = (int)Session["UserId"];
                blogg.Text1 = blogonly.Blog.Text1;
                blogg.Text2 = blogonly.Blog.Text2;
                blogg.Text3 = blogonly.Blog.Text3;
                blogg.Quote = blogonly.Blog.Quote;

                db.Entry(blogg).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("BlogDetailsIndex", "Blog", new { id = blogonly.bblogId });
            }

            ViewBag.Categories = db.BlogCategories.Include("Blogs").ToList();
            return View(blogonly.Blog);
        }

        public ActionResult Delete(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            List<BlogComment> blc = db.BlogComments.Where(c => c.BlogId == id).ToList();
            foreach (var bc in blc)
            {
                db.BlogComments.Remove(bc);
            }
            if (blog.BgImageFile != null)
            {
                string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blog.BgImage);
                System.IO.File.Delete(OldbgImagePath);
            }
            if (blog.MainImageFile != null)
            {
                string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blog.MainImage);
                System.IO.File.Delete(OldbgImagePath);
            }
            if (blog.Image1File != null)
            {
                string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blog.Image1);
                System.IO.File.Delete(OldbgImagePath);
            }
            if (blog.Image2File != null)
            {
                string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blog.Image2);
                System.IO.File.Delete(OldbgImagePath);
            }
            db.Blogs.Remove(blog);
            db.SaveChanges();

            return RedirectToAction("MyPage","Home",new { id=(int)Session["UserId"]});
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
            if (Session["User"] != null)
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