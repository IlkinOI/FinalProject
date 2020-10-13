using SetSail.Areas.Administrator.Filters;
using SetSail.DAL;
using SetSail.Models;
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
    public class AboutController : Controller
    {
        // GET: Administrator/About
        SetSailContext db = new SetSailContext();
        public ActionResult Index()
        {
            List<About> abouts = db.Abouts.ToList();
            return View(abouts);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                
                if (about.BgImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(about);
                }
                string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.BgImageFile.FileName;
                string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                about.BgImageFile.SaveAs(bgimagePath);
                about.BgImage = bgimageName;

                if (about.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(about);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                about.ImageFile.SaveAs(imagePath);
                about.Image = imageName;

                if (about.PopImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(about);
                }
                string popimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.PopImageFile.FileName;
                string popimagePath = Path.Combine(Server.MapPath("~/Uploads/"), popimageName);

                about.PopImageFile.SaveAs(popimagePath);
                about.PopImage = popimageName;

                if (about.VideoImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(about);
                }
                string vidimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.VideoImageFile.FileName;
                string vidimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vidimageName);

                about.VideoImageFile.SaveAs(vidimagePath);
                about.VideoImage = vidimageName;

                if (about.MPImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(about);
                }
                string mpimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.MPImageFile.FileName;
                string mpimagePath = Path.Combine(Server.MapPath("~/Uploads/"), mpimageName);

                about.MPImageFile.SaveAs(mpimagePath);
                about.MPImage = mpimageName;

                if (about.BlogsBgImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(about);
                }
                string bbgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.BlogsBgImageFile.FileName;
                string bbgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bbgimageName);

                about.BlogsBgImageFile.SaveAs(bbgimagePath);
                about.BlogsBgImage = bbgimageName;

                db.Abouts.Add(about);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(about);
        }

        public ActionResult Update(int id)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }

            return View(about);
        }

        [HttpPost]
        public ActionResult Update(About about)
        {
            if (ModelState.IsValid)
            {
                About abouty = db.Abouts.Find(about.Id);
                if (about.BgImageFile != null)
                {
                    string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.BgImageFile.FileName;
                    string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                    string bgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), abouty.BgImage);
                    System.IO.File.Delete(bgoldImagePath);

                    about.BgImageFile.SaveAs(bgimagePath);
                    abouty.BgImage = bgimageName;
                }

                if (about.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), abouty.Image);
                    System.IO.File.Delete(oldImagePath);

                    about.ImageFile.SaveAs(imagePath);
                    abouty.Image = imageName;
                }
                if (about.PopImageFile != null)
                {
                    string popimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.PopImageFile.FileName;
                    string popimagePath = Path.Combine(Server.MapPath("~/Uploads/"), popimageName);

                    string popoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), abouty.PopImage);
                    System.IO.File.Delete(popoldImagePath);

                    about.PopImageFile.SaveAs(popimagePath);
                    abouty.PopImage = popimageName;
                }
                if (about.VideoImageFile != null)
                {
                    string vidimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.VideoImageFile.FileName;
                    string vidimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vidimageName);

                    string vidoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), abouty.VideoImage);
                    System.IO.File.Delete(vidoldImagePath);

                    about.VideoImageFile.SaveAs(vidimagePath);
                    abouty.VideoImage = vidimageName;
                }
                if (about.MPImageFile != null)
                {
                    string mpimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.MPImageFile.FileName;
                    string mpimagePath = Path.Combine(Server.MapPath("~/Uploads/"), mpimageName);

                    string mpoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), abouty.MPImage);
                    System.IO.File.Delete(mpoldImagePath);

                    about.MPImageFile.SaveAs(mpimagePath);
                    about.MPImage = mpimageName;
                }
                if (about.BlogsBgImageFile != null)
                {
                    string bbgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.BlogsBgImageFile.FileName;
                    string bbgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bbgimageName);

                    string bbgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), abouty.BlogsBgImage);
                    System.IO.File.Delete(bbgoldImagePath);

                    about.BlogsBgImageFile.SaveAs(bbgimagePath);
                    about.BlogsBgImage = bbgimageName;
                }

                abouty.TopText = about.TopText;
                abouty.Text = about.Text;
                abouty.Video = about.Video;

                db.Entry(abouty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        public ActionResult Delete(int id)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }

            if (about.BgImageFile != null)
            {
                string bgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), about.BgImage);
                System.IO.File.Delete(bgoldImagePath);
            }
            if (about.ImageFile != null)
            {
                string bgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), about.Image);
                System.IO.File.Delete(bgoldImagePath);
            }
            
            if (about.PopImageFile != null)
            {
                string popoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), about.PopImage);
                System.IO.File.Delete(popoldImagePath);
            }
            if (about.VideoImageFile != null)
            {
                string vidoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), about.VideoImage);
                System.IO.File.Delete(vidoldImagePath);
            }
            if (about.MPImageFile != null)
            {
                string mpoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), about.MPImage);
                System.IO.File.Delete(mpoldImagePath);
            }
            if (about.BlogsBgImageFile != null)
            {
                string bbgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), about.BlogsBgImage);
                System.IO.File.Delete(bbgoldImagePath);
            }

            db.Abouts.Remove(about);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //FAQ CRUD START//

        public ActionResult FaqIndex()
        {
            List<Faq> faqs = db.Faqs.ToList();
            return View(faqs);
        }
        public ActionResult FaqCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaqCreate(Faq faq)
        {
            if (ModelState.IsValid)
            {
                if (faq.BgImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(faq);
                }
                string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + faq.BgImageFile.FileName;
                string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                faq.BgImageFile.SaveAs(bgimagePath);
                faq.BgImage = bgimageName;


                db.Faqs.Add(faq);
                db.SaveChanges();

                return RedirectToAction("FaqIndex");
            }

            return View(faq);
        }

        public ActionResult FaqUpdate(int id)
        {
            Faq faq = db.Faqs.Find(id);
            if (faq == null)
            {
                return HttpNotFound();
            }

            return View(faq);
        }

        [HttpPost]
        public ActionResult FaqUpdate(Faq faq)
        {
            if (ModelState.IsValid)
            {
                Faq faqq = db.Faqs.Find(faq.Id);

                if (faq.BgImageFile != null)
                {
                    string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + faq.BgImageFile.FileName;
                    string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                    string bgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), faqq.BgImage);
                    System.IO.File.Delete(bgoldImagePath);

                    faq.BgImageFile.SaveAs(bgimagePath);
                    faq.BgImage = bgimageName;
                }
                faqq.Question = faq.Question;
                faqq.Answer = faq.Answer;

                db.Entry(faqq).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FaqIndex");
            }

            return View(faq);
        }

        public ActionResult FaqDelete(int id)
        {
            Faq faq = db.Faqs.Find(id);
            if (faq == null)
            {
                return HttpNotFound();
            }
            if (faq.BgImageFile != null)
            {
                string bgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), faq.BgImage);
                System.IO.File.Delete(bgoldImagePath);
            }
            db.Faqs.Remove(faq);
            db.SaveChanges();

            return RedirectToAction("FaqIndex");
        }

        // FAQ CRUD END//
    }
}