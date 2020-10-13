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
    public class PageController : Controller
    {
        // GET: Administrator/Page
        SetSailContext db = new SetSailContext();

        // HOME PAGE CRUD START //

        public ActionResult HomeIndex()
        {
            List<HomePage> Homes = db.HomePages.ToList();
            return View(Homes);
        }
        public ActionResult HomeCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomeCreate(HomePage hom)
        {
            if (ModelState.IsValid)
            {
                if (hom.IntroImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(hom);
                }
                string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.IntroImage1File.FileName;
                string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                hom.IntroImage1File.SaveAs(i1imagePath);
                hom.IntroImage1 = i1imageName;

                if (hom.IntroImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(hom);
                }
                string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.IntroImage2File.FileName;
                string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                hom.IntroImage2File.SaveAs(i2imagePath);
                hom.IntroImage2 = i2imageName;
                
                if (hom.ParallaxImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(hom);
                }

                string p1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.ParallaxImage1File.FileName;
                string p1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p1imageName);

                hom.ParallaxImage1File.SaveAs(p1imagePath);
                hom.ParallaxImage1 = p1imageName;

                if (hom.ParallaxImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(hom);
                }

                string p2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.ParallaxImage2File.FileName;
                string p2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p2imageName);

                hom.ParallaxImage2File.SaveAs(p2imagePath);
                hom.ParallaxImage2 = p2imageName;

                if (hom.VideoImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(hom);
                }

                string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.VideoImageFile.FileName;
                string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                hom.VideoImageFile.SaveAs(vimagePath);
                hom.VideoImage = vimageName;

                db.HomePages.Add(hom);
                db.SaveChanges();

                return RedirectToAction("HomeIndex");
            }

            return View(hom);
        }

        public ActionResult HomeUpdate(int id)
        {
            HomePage hom = db.HomePages.Find(id);
            if (hom == null)
            {
                return HttpNotFound();
            }

            return View(hom);
        }

        [HttpPost]
        public ActionResult HomeUpdate(HomePage hom)
        {
            if (ModelState.IsValid)
            {
                HomePage homs = db.HomePages.Find(hom.Id);

                if (hom.IntroImage1File != null)
                {
                    string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.IntroImage1File.FileName;
                    string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                    string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), homs.IntroImage1);
                    System.IO.File.Delete(i1oldImagePath);

                    hom.IntroImage1File.SaveAs(i1imagePath);
                    homs.IntroImage1 = i1imageName;

                }

                if (hom.IntroImage2File != null)
                {
                    string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.IntroImage2File.FileName;
                    string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                    string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), homs.IntroImage2);
                    System.IO.File.Delete(i2oldImagePath);

                    hom.IntroImage2File.SaveAs(i2imagePath);
                    homs.IntroImage2 = i2imageName;

                }
                
                if (hom.ParallaxImage1File != null)
                {
                    string p1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.ParallaxImage1File.FileName;
                    string p1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p1imageName);

                    string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), homs.ParallaxImage1);
                    System.IO.File.Delete(p1oldImagePath);

                    hom.ParallaxImage1File.SaveAs(p1imagePath);
                    homs.ParallaxImage1 = p1imageName;
                }
                if (hom.ParallaxImage2File != null)
                {
                    string p2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.ParallaxImage2File.FileName;
                    string p2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p2imageName);

                    string p2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), homs.ParallaxImage2);
                    System.IO.File.Delete(p2oldImagePath);

                    hom.ParallaxImage2File.SaveAs(p2imagePath);
                    homs.ParallaxImage2 = p2imageName;
                }
                if (hom.VideoImageFile != null)
                {
                    string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + hom.VideoImageFile.FileName;
                    string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                    string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), homs.VideoImage);
                    System.IO.File.Delete(voldImagePath);

                    hom.VideoImageFile.SaveAs(vimagePath);
                    homs.VideoImage = vimageName;
                }

                homs.TopTitle1 = hom.TopTitle1;
                homs.Title1 = hom.Title1;
                homs.introText1 = hom.introText1;
                homs.TopTitle2 = hom.TopTitle2;
                homs.Title2 = hom.Title2;
                homs.introText2 = hom.introText2;

                db.Entry(homs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HomeIndex");
            }

            return View(hom);
        }

        public ActionResult HomeDelete(int id)
        {
            HomePage hom = db.HomePages.Find(id);
            if (hom == null)
            {
                return HttpNotFound();
            }
            if (hom.IntroImage1File != null)
            {
                string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), hom.IntroImage1);
                System.IO.File.Delete(i1oldImagePath);
            }

            if (hom.IntroImage2File != null)
            {
                string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), hom.IntroImage2);
                System.IO.File.Delete(i2oldImagePath);
            }

            if (hom.ParallaxImage1File != null)
            {
                string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), hom.ParallaxImage1);
                System.IO.File.Delete(p1oldImagePath);
            }
            if (hom.ParallaxImage2File != null)
            {
                string p2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), hom.ParallaxImage2);
                System.IO.File.Delete(p2oldImagePath);
            }
            if (hom.VideoImageFile != null)
            {
                string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), hom.VideoImage);
                System.IO.File.Delete(voldImagePath);
            }
            db.HomePages.Remove(hom);
            db.SaveChanges();

            return RedirectToAction("HomeIndex");
        }

        // HOME PAGE CRUD END //

        // SUMMER PAGE CRUD START //

        public ActionResult SummerIndex()
        {
            List<SummerPage> summers = db.SummerPages.ToList();
            return View(summers);
        }
        public ActionResult SummerCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SummerCreate(SummerPage sum)
        {
            if (ModelState.IsValid)
            {
                if (sum.IntroImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(sum);
                }
                string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage1File.FileName;
                string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                sum.IntroImage1File.SaveAs(i1imagePath);
                sum.IntroImage1 = i1imageName;

                if (sum.IntroImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(sum);
                }
                string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage2File.FileName;
                string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                sum.IntroImage2File.SaveAs(i2imagePath);
                sum.IntroImage2 = i2imageName;

                if (sum.IntroImage3File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(sum);
                }
                string i3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage3File.FileName;
                string i3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3imageName);

                sum.IntroImage3File.SaveAs(i3imagePath);
                sum.IntroImage3 = i3imageName;

                if (sum.IntroImage4File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(sum);
                }

                string i4imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage4File.FileName;
                string i4imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i4imageName);

                sum.IntroImage4File.SaveAs(i4imagePath);
                sum.IntroImage4 = i4imageName;

                if (sum.ParallaxImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(sum);
                }

                string p1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.ParallaxImage1File.FileName;
                string p1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p1imageName);

                sum.ParallaxImage1File.SaveAs(p1imagePath);
                sum.ParallaxImage1 = p1imageName;

                if (sum.ParallaxImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(sum);
                }

                string p2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.ParallaxImage2File.FileName;
                string p2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p2imageName);

                sum.ParallaxImage2File.SaveAs(p2imagePath);
                sum.ParallaxImage2 = p2imageName;

                if (sum.VideoImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(sum);
                }

                string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.VideoImageFile.FileName;
                string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                sum.VideoImageFile.SaveAs(vimagePath);
                sum.VideoImage = vimageName;

                db.SummerPages.Add(sum);
                db.SaveChanges();

                return RedirectToAction("SummerIndex");
            }

            return View(sum);
        }

        public ActionResult SummerUpdate(int id)
        {
            SummerPage sum = db.SummerPages.Find(id);
            if (sum == null)
            {
                return HttpNotFound();
            }

            return View(sum);
        }

        [HttpPost]
        public ActionResult SummerUpdate(SummerPage sum)
        {
            if (ModelState.IsValid)
            {
                SummerPage sums = db.SummerPages.Find(sum.Id);

                if (sum.IntroImage1File != null)
                {
                    string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage1File.FileName;
                    string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                    string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sums.IntroImage1);
                    System.IO.File.Delete(i1oldImagePath);

                    sum.IntroImage1File.SaveAs(i1imagePath);
                    sums.IntroImage1 = i1imageName;

                }

                if (sum.IntroImage2File != null)
                {
                    string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage2File.FileName;
                    string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                    string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sums.IntroImage2);
                    System.IO.File.Delete(i2oldImagePath);

                    sum.IntroImage2File.SaveAs(i2imagePath);
                    sums.IntroImage2 = i2imageName;

                }
                if (sum.IntroImage3File != null)
                {
                    string i3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage3File.FileName;
                    string i3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3imageName);

                    string i3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sums.IntroImage3);
                    System.IO.File.Delete(i3oldImagePath);

                    sum.IntroImage3File.SaveAs(i3imagePath);
                    sums.IntroImage3 = i3imageName;

                }
                if (sum.IntroImage4File != null)
                {
                    string i4imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.IntroImage4File.FileName;
                    string i4imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i4imageName);

                    string i4oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sums.IntroImage4);
                    System.IO.File.Delete(i4oldImagePath);

                    sum.IntroImage4File.SaveAs(i4imagePath);
                    sums.IntroImage4 = i4imageName;

                }
                if (sum.ParallaxImage1File != null)
                {
                    string p1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.ParallaxImage1File.FileName;
                    string p1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p1imageName);

                    string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sums.ParallaxImage1);
                    System.IO.File.Delete(p1oldImagePath);

                    sum.ParallaxImage1File.SaveAs(p1imagePath);
                    sums.ParallaxImage1 = p1imageName;
                }
                if (sum.ParallaxImage2File != null)
                {
                    string p2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.ParallaxImage2File.FileName;
                    string p2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p2imageName);

                    string p2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sums.ParallaxImage2);
                    System.IO.File.Delete(p2oldImagePath);

                    sum.ParallaxImage2File.SaveAs(p2imagePath);
                    sums.ParallaxImage2 = p2imageName;
                }
                if (sum.VideoImageFile != null)
                {
                    string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sum.VideoImageFile.FileName;
                    string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                    string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sums.VideoImage);
                    System.IO.File.Delete(voldImagePath);

                    sum.VideoImageFile.SaveAs(vimagePath);
                    sums.VideoImage = vimageName;
                }

                sums.TopTitle1 = sum.TopTitle1;
                sums.Title1 = sum.Title1;
                sums.introText1 = sum.introText1;
                sums.TopTitle2 = sum.TopTitle2;
                sums.Title2 = sum.Title2;
                sums.introText2 = sum.introText2;
                sums.TopTitle3 = sum.TopTitle3;
                sums.Title3 = sum.Title3;
                sums.introText3 = sum.introText3;
                sums.Video = sum.Video;

                db.Entry(sums).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SummerIndex");
            }

            return View(sum);
        }

        public ActionResult SummerDelete(int id)
        {
            SummerPage sum = db.SummerPages.Find(id);
            if (sum == null)
            {
                return HttpNotFound();
            }
            if (sum.IntroImage1File != null)
            {
                string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sum.IntroImage1);
                System.IO.File.Delete(i1oldImagePath);
            }

            if (sum.IntroImage2File != null)
            {
                string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sum.IntroImage2);
                System.IO.File.Delete(i2oldImagePath);
            }
            if (sum.IntroImage3File != null)
            {
                string i3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sum.IntroImage3);
                System.IO.File.Delete(i3oldImagePath);
            }
            if (sum.IntroImage4File != null)
            {
                string i4oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sum.IntroImage4);
                System.IO.File.Delete(i4oldImagePath);
            }
            if (sum.ParallaxImage1File != null)
            {
                string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sum.ParallaxImage1);
                System.IO.File.Delete(p1oldImagePath);
            }
            if (sum.ParallaxImage2File != null)
            {
                string p2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sum.ParallaxImage2);
                System.IO.File.Delete(p2oldImagePath);
            }
            if (sum.VideoImageFile != null)
            {
                string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sum.VideoImage);
                System.IO.File.Delete(voldImagePath);
            }
            db.SummerPages.Remove(sum);
            db.SaveChanges();

            return RedirectToAction("SummerIndex");
        }

        // SUMMER PAGE CRUD END //

        // WINTER PAGE CRUD START //

        public ActionResult WinterIndex()
        {
            List<WinterPage> Winters = db.WinterPages.ToList();
            return View(Winters);
        }
        public ActionResult WinterCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WinterCreate(WinterPage win)
        {
            if (ModelState.IsValid)
            {
                if (win.IntroImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(win);
                }
                string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.IntroImage1File.FileName;
                string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                win.IntroImage1File.SaveAs(i1imagePath);
                win.IntroImage1 = i1imageName;

                if (win.IntroImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(win);
                }
                string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.IntroImage2File.FileName;
                string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                win.IntroImage2File.SaveAs(i2imagePath);
                win.IntroImage2 = i2imageName;

                

                if (win.ParallaxImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(win);
                }

                string p1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.ParallaxImage1File.FileName;
                string p1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p1imageName);

                win.ParallaxImage1File.SaveAs(p1imagePath);
                win.ParallaxImage1 = p1imageName;


                if (win.VideoImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(win);
                }

                string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.VideoImageFile.FileName;
                string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                win.VideoImageFile.SaveAs(vimagePath);
                win.VideoImage = vimageName;

                db.WinterPages.Add(win);
                db.SaveChanges();

                return RedirectToAction("WinterIndex");
            }

            return View(win);
        }

        public ActionResult WinterUpdate(int id)
        {
            WinterPage win = db.WinterPages.Find(id);
            if (win == null)
            {
                return HttpNotFound();
            }

            return View(win);
        }

        [HttpPost]
        public ActionResult WinterUpdate(WinterPage win)
        {
            if (ModelState.IsValid)
            {
                WinterPage wins = db.WinterPages.Find(win.Id);

                if (win.IntroImage1File != null)
                {
                    string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.IntroImage1File.FileName;
                    string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                    string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wins.IntroImage1);
                    System.IO.File.Delete(i1oldImagePath);

                    win.IntroImage1File.SaveAs(i1imagePath);
                    wins.IntroImage1 = i1imageName;

                }

                if (win.IntroImage2File != null)
                {
                    string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.IntroImage2File.FileName;
                    string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                    string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wins.IntroImage2);
                    System.IO.File.Delete(i2oldImagePath);

                    win.IntroImage2File.SaveAs(i2imagePath);
                    wins.IntroImage2 = i2imageName;

                }
                
                if (win.ParallaxImage1File != null)
                {
                    string p1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.ParallaxImage1File.FileName;
                    string p1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p1imageName);

                    string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wins.ParallaxImage1);
                    System.IO.File.Delete(p1oldImagePath);

                    win.ParallaxImage1File.SaveAs(p1imagePath);
                    wins.ParallaxImage1 = p1imageName;
                }
               
                if (win.VideoImageFile != null)
                {
                    string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + win.VideoImageFile.FileName;
                    string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                    string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wins.VideoImage);
                    System.IO.File.Delete(voldImagePath);

                    win.VideoImageFile.SaveAs(vimagePath);
                    wins.VideoImage = vimageName;
                }

                wins.TopTitle1 = win.TopTitle1;
                wins.Title1 = win.Title1;
                wins.introText1 = win.introText1;
                wins.TopTitle2 = win.TopTitle2;
                wins.Title2 = win.Title2;
                wins.introText2 = win.introText2;

                db.Entry(wins).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WinterIndex");
            }

            return View(win);
        }

        public ActionResult WinterDelete(int id)
        {
            WinterPage win = db.WinterPages.Find(id);
            if (win == null)
            {
                return HttpNotFound();
            }
            if (win.IntroImage1File != null)
            {
                string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), win.IntroImage1);
                System.IO.File.Delete(i1oldImagePath);
            }

            if (win.IntroImage2File != null)
            {
                string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), win.IntroImage2);
                System.IO.File.Delete(i2oldImagePath);
            }

            if (win.ParallaxImage1File != null)
            {
                string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), win.ParallaxImage1);
                System.IO.File.Delete(p1oldImagePath);
            }

            if (win.VideoImageFile != null)
            {
                string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), win.VideoImage);
                System.IO.File.Delete(voldImagePath);
            }
            db.WinterPages.Remove(win);
            db.SaveChanges();

            return RedirectToAction("WinterIndex");
        }

        // WINTER PAGE CRUD END //

        // CITY PAGE CRUD START //

        public ActionResult CityIndex()
        {
            List<CityPage> Citys = db.CityPages.ToList();
            return View(Citys);
        }
        public ActionResult CityCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CityCreate(CityPage cit)
        {
            if (ModelState.IsValid)
            {
                if (cit.IntroImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(cit);
                }
                string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + cit.IntroImage1File.FileName;
                string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                cit.IntroImage1File.SaveAs(i1imagePath);
                cit.IntroImage1 = i1imageName;

                if (cit.IntroImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(cit);
                }
                string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + cit.IntroImage2File.FileName;
                string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                cit.IntroImage2File.SaveAs(i2imagePath);
                cit.IntroImage2 = i2imageName;

                if (cit.IntroImage3File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(cit);
                }
                string i3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + cit.IntroImage3File.FileName;
                string i3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3imageName);

                cit.IntroImage3File.SaveAs(i3imagePath);
                cit.IntroImage3 = i3imageName;

                db.CityPages.Add(cit);
                db.SaveChanges();

                return RedirectToAction("CityIndex");
            }

            return View(cit);
        }

        public ActionResult CityUpdate(int id)
        {
            CityPage cit = db.CityPages.Find(id);
            if (cit == null)
            {
                return HttpNotFound();
            }

            return View(cit);
        }

        [HttpPost]
        public ActionResult CityUpdate(CityPage cit)
        {
            if (ModelState.IsValid)
            {
                CityPage cits = db.CityPages.Find(cit.Id);

                if (cit.IntroImage1File != null)
                {
                    string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + cit.IntroImage1File.FileName;
                    string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                    string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), cits.IntroImage1);
                    System.IO.File.Delete(i1oldImagePath);

                    cit.IntroImage1File.SaveAs(i1imagePath);
                    cits.IntroImage1 = i1imageName;

                }

                if (cit.IntroImage2File != null)
                {
                    string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + cit.IntroImage2File.FileName;
                    string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                    string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), cits.IntroImage2);
                    System.IO.File.Delete(i2oldImagePath);

                    cit.IntroImage2File.SaveAs(i2imagePath);
                    cits.IntroImage2 = i2imageName;

                }
                if (cit.IntroImage3File != null)
                {
                    string i3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + cit.IntroImage3File.FileName;
                    string i3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3imageName);

                    string i3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), cits.IntroImage3);
                    System.IO.File.Delete(i3oldImagePath);

                    cit.IntroImage3File.SaveAs(i3imagePath);
                    cits.IntroImage3 = i3imageName;

                }
                

                cits.TopTitle1 = cit.TopTitle1;
                cits.Title1 = cit.Title1;
                cits.introText1 = cit.introText1;
                cits.TopTitle2 = cit.TopTitle2;
                cits.Title2 = cit.Title2;
                cits.introText2 = cit.introText2;
                cits.TopTitle3 = cit.TopTitle3;
                cits.Title3 = cit.Title3;
                cits.introText3 = cit.introText3;
                cits.Video = cit.Video;

                db.Entry(cits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CityIndex");
            }

            return View(cit);
        }

        public ActionResult CityDelete(int id)
        {
            CityPage cit = db.CityPages.Find(id);
            if (cit == null)
            {
                return HttpNotFound();
            }
            if (cit.IntroImage1File != null)
            {
                string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), cit.IntroImage1);
                System.IO.File.Delete(i1oldImagePath);
            }

            if (cit.IntroImage2File != null)
            {
                string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), cit.IntroImage2);
                System.IO.File.Delete(i2oldImagePath);
            }
            if (cit.IntroImage3File != null)
            {
                string i3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), cit.IntroImage3);
                System.IO.File.Delete(i3oldImagePath);
            }
            db.CityPages.Remove(cit);
            db.SaveChanges();

            return RedirectToAction("CityIndex");
        }

        // CITY PAGE CRUD END //

        // EXOTIC PAGE CRUD START //

        public ActionResult ExoticIndex()
        {
            List<ExoticPage> Exotics = db.ExoticPages.ToList();
            return View(Exotics);
        }
        public ActionResult ExoticCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExoticCreate(ExoticPage exo)
        {
            if (ModelState.IsValid)
            {
                if (exo.IntroImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(exo);
                }
                string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + exo.IntroImage1File.FileName;
                string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                exo.IntroImage1File.SaveAs(i1imagePath);
                exo.IntroImage1 = i1imageName;

                if (exo.IntroImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(exo);
                }
                string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + exo.IntroImage2File.FileName;
                string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                exo.IntroImage2File.SaveAs(i2imagePath);
                exo.IntroImage2 = i2imageName;

                db.ExoticPages.Add(exo);
                db.SaveChanges();

                return RedirectToAction("ExoticIndex");
            }

            return View(exo);
        }

        public ActionResult ExoticUpdate(int id)
        {
            ExoticPage exo = db.ExoticPages.Find(id);
            if (exo == null)
            {
                return HttpNotFound();
            }

            return View(exo);
        }

        [HttpPost]
        public ActionResult ExoticUpdate(ExoticPage exo)
        {
            if (ModelState.IsValid)
            {
                ExoticPage exos = db.ExoticPages.Find(exo.Id);

                if (exo.IntroImage1File != null)
                {
                    string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + exo.IntroImage1File.FileName;
                    string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                    string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), exos.IntroImage1);
                    System.IO.File.Delete(i1oldImagePath);

                    exo.IntroImage1File.SaveAs(i1imagePath);
                    exos.IntroImage1 = i1imageName;

                }

                if (exo.IntroImage2File != null)
                {
                    string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + exo.IntroImage2File.FileName;
                    string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                    string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), exos.IntroImage2);
                    System.IO.File.Delete(i2oldImagePath);

                    exo.IntroImage2File.SaveAs(i2imagePath);
                    exos.IntroImage2 = i2imageName;

                }
                exos.TopTitle1 = exo.TopTitle1;
                exos.Title1 = exo.Title1;
                exos.introText1 = exo.introText1;
                exos.TopTitle2 = exo.TopTitle2;
                exos.Title2 = exo.Title2;
                exos.introText2 = exo.introText2;

                db.Entry(exos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ExoticIndex");
            }

            return View(exo);
        }

        public ActionResult ExoticDelete(int id)
        {
            ExoticPage exo = db.ExoticPages.Find(id);
            if (exo == null)
            {
                return HttpNotFound();
            }
            if (exo.IntroImage1File != null)
            {
                string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), exo.IntroImage1);
                System.IO.File.Delete(i1oldImagePath);
            }

            if (exo.IntroImage2File != null)
            {
                string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), exo.IntroImage2);
                System.IO.File.Delete(i2oldImagePath);
            }
            db.ExoticPages.Remove(exo);
            db.SaveChanges();

            return RedirectToAction("ExoticIndex");
        }

        // EXOTIC PAGE CRUD END //

        // WINE PAGE CRUD START //

        public ActionResult WineIndex()
        {
            List<WinePage> Wines = db.WinePages.ToList();
            return View(Wines);
        }
        public ActionResult WineCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WineCreate(WinePage wn)
        {
            if (ModelState.IsValid)
            {

                if (wn.introTitleImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }
                string it1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.introTitleImage1File.FileName;
                string it1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), it1imageName);

                wn.introTitleImage1File.SaveAs(it1imagePath);
                wn.introTitleImage1 = it1imageName;

                if (wn.introTitleImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }
                string it2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.introTitleImage2File.FileName;
                string it2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), it2imageName);

                wn.introTitleImage2File.SaveAs(it2imagePath);
                wn.introTitleImage2 = it2imageName;

                if (wn.introTitleImage3File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }
                string it3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.introTitleImage3File.FileName;
                string it3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), it3imageName);

                wn.introTitleImage3File.SaveAs(it3imagePath);
                wn.introTitleImage3 = it3imageName;

                if (wn.IntroImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }
                string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage1File.FileName;
                string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                wn.IntroImage1File.SaveAs(i1imagePath);
                wn.IntroImage1 = i1imageName;

                if (wn.IntroImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }
                string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage2File.FileName;
                string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                wn.IntroImage2File.SaveAs(i2imagePath);
                wn.IntroImage2 = i2imageName;

                if (wn.IntroImage3File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }
                string i3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage3File.FileName;
                string i3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3imageName);

                wn.IntroImage3File.SaveAs(i3imagePath);
                wn.IntroImage3 = i3imageName;

                if (wn.IntroImage1sFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }

                string i1simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage1sFile.FileName;
                string i1simagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1simageName);

                wn.IntroImage1sFile.SaveAs(i1simagePath);
                wn.IntroImage1s = i1simageName;

                if (wn.IntroImage2sFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }

                string i2simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage2sFile.FileName;
                string i2simagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2simageName);

                wn.IntroImage2sFile.SaveAs(i2simagePath);
                wn.IntroImage2s = i2simageName;

                if (wn.IntroImage3sFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }

                string i3simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage3sFile.FileName;
                string i3simagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3simageName);

                wn.IntroImage3sFile.SaveAs(i3simagePath);
                wn.IntroImage3s = i3simageName;

                if (wn.PopImage1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }

                string pimage1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.PopImage1File.FileName;
                string pimage1Path = Path.Combine(Server.MapPath("~/Uploads/"), pimage1Name);

                wn.PopImage1File.SaveAs(pimage1Path);
                wn.PopImage1 = pimage1Name;

                if (wn.PopImage2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }

                string pimage2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.PopImage2File.FileName;
                string pimage2Path = Path.Combine(Server.MapPath("~/Uploads/"), pimage2Name);

                wn.PopImage2File.SaveAs(pimage2Path);
                wn.PopImage2 = pimage2Name;

                if (wn.VideoImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(wn);
                }

                string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.VideoImageFile.FileName;
                string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                wn.VideoImageFile.SaveAs(vimagePath);
                wn.VideoImage = vimageName;

                db.WinePages.Add(wn);
                db.SaveChanges();

                return RedirectToAction("WineIndex");
            }

            return View(wn);
        }

        public ActionResult WineUpdate(int id)
        {
            WinePage wn = db.WinePages.Find(id);
            if (wn == null)
            {
                return HttpNotFound();
            }

            return View(wn);
        }

        [HttpPost]
        public ActionResult WineUpdate(WinePage wn)
        {
            if (ModelState.IsValid)
            {
                WinePage wns = db.WinePages.Find(wn.Id);

                if (wn.IntroImage1File != null)
                {
                    string i1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage1File.FileName;
                    string i1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1imageName);

                    string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.IntroImage1);
                    System.IO.File.Delete(i1oldImagePath);

                    wn.IntroImage1File.SaveAs(i1imagePath);
                    wns.IntroImage1 = i1imageName;

                }

                if (wn.IntroImage1sFile != null)
                {
                    string i1simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage1sFile.FileName;
                    string i1simagePath = Path.Combine(Server.MapPath("~/Uploads/"), i1simageName);

                    string i1soldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.IntroImage1s);
                    System.IO.File.Delete(i1soldImagePath);

                    wn.IntroImage1sFile.SaveAs(i1simagePath);
                    wns.IntroImage1s = i1simageName;
                }

                if (wn.IntroImage2File != null)
                {
                    string i2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage2File.FileName;
                    string i2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2imageName);

                    string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.IntroImage2);
                    System.IO.File.Delete(i2oldImagePath);

                    wn.IntroImage2File.SaveAs(i2imagePath);
                    wns.IntroImage2 = i2imageName;

                }

                if (wn.IntroImage2sFile != null)
                {
                    string i2simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage2sFile.FileName;
                    string i2simagePath = Path.Combine(Server.MapPath("~/Uploads/"), i2simageName);

                    string i2soldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.IntroImage2s);
                    System.IO.File.Delete(i2soldImagePath);

                    wn.IntroImage2sFile.SaveAs(i2simagePath);
                    wns.IntroImage2s = i2simageName;
                }

                if (wn.IntroImage3File != null)
                {
                    string i3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage3File.FileName;
                    string i3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3imageName);

                    string i3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.IntroImage3);
                    System.IO.File.Delete(i3oldImagePath);

                    wn.IntroImage3File.SaveAs(i3imagePath);
                    wns.IntroImage3 = i3imageName;

                }

                if (wn.IntroImage3sFile != null)
                {
                    string i3simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.IntroImage3sFile.FileName;
                    string i3simagePath = Path.Combine(Server.MapPath("~/Uploads/"), i3simageName);

                    string i3soldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.IntroImage3s);
                    System.IO.File.Delete(i3soldImagePath);

                    wn.IntroImage3sFile.SaveAs(i3simagePath);
                    wns.IntroImage3s = i3simageName;
                }

                if (wn.introTitleImage1File != null)
                {
                    string it1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.introTitleImage1File.FileName;
                    string it1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), it1imageName);

                    string it1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.introTitleImage1);
                    System.IO.File.Delete(it1oldImagePath);

                    wn.introTitleImage1File.SaveAs(it1imagePath);
                    wns.introTitleImage1 = it1imageName;
                }
                if (wn.introTitleImage2File != null)
                {
                    string it2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.introTitleImage2File.FileName;
                    string it2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), it2imageName);

                    string it2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.introTitleImage2);
                    System.IO.File.Delete(it2oldImagePath);

                    wn.introTitleImage2File.SaveAs(it2imagePath);
                    wns.introTitleImage2 = it2imageName;
                }
                if (wn.introTitleImage3File != null)
                {
                    string it3imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.introTitleImage3File.FileName;
                    string it3imagePath = Path.Combine(Server.MapPath("~/Uploads/"), it3imageName);

                    string it3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.introTitleImage3);
                    System.IO.File.Delete(it3oldImagePath);

                    wn.introTitleImage3File.SaveAs(it3imagePath);
                    wns.introTitleImage3 = it3imageName;
                }

                if (wn.PopImage1File != null)
                {
                    string p1imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.PopImage1File.FileName;
                    string p1imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p1imageName);

                    string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.PopImage1);
                    System.IO.File.Delete(p1oldImagePath);

                    wn.PopImage1File.SaveAs(p1imagePath);
                    wns.PopImage1 = p1imageName;
                }

                if (wn.PopImage2File != null)
                {
                    string p2imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.PopImage2File.FileName;
                    string p2imagePath = Path.Combine(Server.MapPath("~/Uploads/"), p2imageName);

                    string p2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.PopImage2);
                    System.IO.File.Delete(p2oldImagePath);

                    wn.PopImage2File.SaveAs(p2imagePath);
                    wns.PopImage2 = p2imageName;
                }

                if (wn.VideoImageFile != null)
                {
                    string vimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + wn.VideoImageFile.FileName;
                    string vimagePath = Path.Combine(Server.MapPath("~/Uploads/"), vimageName);

                    string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wns.VideoImage);
                    System.IO.File.Delete(voldImagePath);

                    wn.VideoImageFile.SaveAs(vimagePath);
                    wns.VideoImage = vimageName;
                }

                wns.Glasses = wn.Glasses;
                wns.Years = wn.Years;
                wns.Uniques = wn.Uniques;
                wns.Sorts = wn.Sorts;
                wns.PopSlogan = wn.PopSlogan;
                wns.PopText1 = wn.PopText1;
                wns.PopText2 = wn.PopText2;
                wns.PopText3 = wn.PopText3;
                wns.PopText4 = wn.PopText4;

                db.Entry(wns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WineIndex");
            }

            return View(wn);
        }

        public ActionResult WineDelete(int id)
        {
            WinePage wn = db.WinePages.Find(id);
            if (wn == null)
            {
                return HttpNotFound();
            }
            if (wn.IntroImage1File != null)
            {
                string i1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.IntroImage1);
                System.IO.File.Delete(i1oldImagePath);
            }

            if (wn.IntroImage1sFile != null)
            {
                string i1soldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.IntroImage1s);
                System.IO.File.Delete(i1soldImagePath);
            }

            if (wn.IntroImage2File != null)
            {
                string i2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.IntroImage2);
                System.IO.File.Delete(i2oldImagePath);
            }

            if (wn.IntroImage2sFile != null)
            {
                string i2soldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.IntroImage2s);
                System.IO.File.Delete(i2soldImagePath);
            }

            if (wn.IntroImage3File != null)
            {
                string i3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.IntroImage3);
                System.IO.File.Delete(i3oldImagePath);
            }

            if (wn.IntroImage3sFile != null)
            {
                string i3soldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.IntroImage3s);
                System.IO.File.Delete(i3soldImagePath);
            }

            if (wn.introTitleImage1File != null)
            {
                string it1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.introTitleImage1);
                System.IO.File.Delete(it1oldImagePath);
            }
            if (wn.introTitleImage2File != null)
            {
                string it2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.introTitleImage2);
                System.IO.File.Delete(it2oldImagePath);
            }
            if (wn.introTitleImage3File != null)
            {
                string it3oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.introTitleImage3);
                System.IO.File.Delete(it3oldImagePath);
            }

            if (wn.PopImage1File != null)
            {
                string p1oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.PopImage1);
                System.IO.File.Delete(p1oldImagePath);
            }

            if (wn.PopImage2File != null)
            {
                string p2oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.PopImage2);
                System.IO.File.Delete(p2oldImagePath);
            }

            if (wn.VideoImageFile != null)
            {
                string voldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), wn.VideoImage);
                System.IO.File.Delete(voldImagePath);
            }
            db.WinePages.Remove(wn);
            db.SaveChanges();

            return RedirectToAction("WineIndex");
        }

        // WINE PAGE CRUD END //
    }
}