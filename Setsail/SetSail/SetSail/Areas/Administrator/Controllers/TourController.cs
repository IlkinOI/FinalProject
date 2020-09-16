﻿using Newtonsoft.Json;
using SetSail.DAL;
using SetSail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SetSail.Areas.Administrator.Controllers
{
    public class TourController : Controller
    {
        // GET: Administrator/Tour
        SetSailContext db = new SetSailContext();

        //Tour Category CRUD START//

        public ActionResult TourCategoryIndex()
        {
            List<TourCategory> categories = db.TourCategories.ToList();
            return View(categories);
        }
        public ActionResult TourCategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TourCategoryCreate(TourCategory cat)
        {
            if (ModelState.IsValid)
            {
                
                db.TourCategories.Add(cat);
                db.SaveChanges();

                return RedirectToAction("TourCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult TourCategoryUpdate(int id)
        {
            TourCategory cat = db.TourCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        [HttpPost]
        public ActionResult TourCategoryUpdate(TourCategory cat)
        {
            if (ModelState.IsValid)
            {
                TourCategory tcat = db.TourCategories.Find(cat.Id);

                tcat.Name = cat.Name;

                db.Entry(tcat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TourCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult TourCategoryDelete(int id)
        {
            TourCategory cat = db.TourCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            db.TourCategories.Remove(cat);
            db.SaveChanges();

            return RedirectToAction("TourCategoryIndex");
        }

        //Tour Category CRUD END//


        //Tour Type CRUD START//

        public ActionResult TourTypeIndex()
        {
            List<TourType> types = db.TourTypes.ToList();
            return View(types);
        }
        public ActionResult TourTypeCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TourTypeCreate(TourType type)
        {
            if (ModelState.IsValid)
            {
                db.TourTypes.Add(type);
                db.SaveChanges();

                return RedirectToAction("TourTypeIndex");
            }

            return View(type);
        }

        public ActionResult TourTypeUpdate(int id)
        {
            TourType type = db.TourTypes.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }

            return View(type);
        }

        [HttpPost]
        public ActionResult TourTypeUpdate(TourType type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TourTypeIndex");
            }

            return View(type);
        }

        public ActionResult TourTypeDelete(int id)
        {
            TourType type = db.TourTypes.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }

            db.TourTypes.Remove(type);
            db.SaveChanges();

            return RedirectToAction("TourTypeIndex");
        }

        //Tour Type CRUD END//

        //Destination CRUD START//

        public ActionResult DestinationIndex()
        {
            List<Destination> destinations = db.Destinations.ToList();
            return View(destinations);
        }
        public ActionResult DestinationCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DestinationCreate(Destination des)
        {
            if (ModelState.IsValid)
            {
                if (des.BgImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.BgImageFile.FileName;
                string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                des.BgImageFile.SaveAs(bgimagePath);
                des.BgImage = bgimageName;

                if (des.SlideImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.SlideImageFile.FileName;
                string simagePath = Path.Combine(Server.MapPath("~/Uploads/"), simageName);

                des.SlideImageFile.SaveAs(simagePath);
                des.SliderImage = bgimageName;

                if (des.Pic1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string pic1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic1File.FileName;
                string pic1Path = Path.Combine(Server.MapPath("~/Uploads/"), pic1Name);

                des.Pic1File.SaveAs(pic1Path);
                des.Pic1 = pic1Name;

                if (des.Pic2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string pic2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic2File.FileName;
                string pic2Path = Path.Combine(Server.MapPath("~/Uploads/"), pic2Name);

                des.Pic2File.SaveAs(pic2Path);
                des.Pic2 = pic2Name;

                if (des.Pic3File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string pic3Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic3File.FileName;
                string pic3Path = Path.Combine(Server.MapPath("~/Uploads/"), pic3Name);

                des.Pic3File.SaveAs(pic3Path);
                des.Pic3 = pic3Name;

                if (des.Pic4File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string pic4Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic4File.FileName;
                string pic4Path = Path.Combine(Server.MapPath("~/Uploads/"), pic4Name);

                des.Pic4File.SaveAs(pic4Path);
                des.Pic4 = pic4Name;

                if (des.Pic5File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string pic5Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic5File.FileName;
                string pic5Path = Path.Combine(Server.MapPath("~/Uploads/"), pic5Name);

                des.Pic5File.SaveAs(pic5Path);
                des.Pic5 = pic5Name;

                if (des.Pic6File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(des);
                }
                string pic6Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic6File.FileName;
                string pic6Path = Path.Combine(Server.MapPath("~/Uploads/"), pic6Name);

                des.Pic6File.SaveAs(pic6Path);
                des.Pic6 = pic6Name;

                db.Destinations.Add(des);
                db.SaveChanges();

                return RedirectToAction("DestinationIndex");
            }
            return View(des);
        }
        public ActionResult DestinationUpdate(int id)
        {
            Destination des = db.Destinations.Find(id);
            if (des == null)
            {
                return HttpNotFound();
            }
            return View(des);
        }

        [HttpPost]
        public ActionResult DestinationUpdate(Destination des)
        {
            if (ModelState.IsValid)
            {
                Destination dess = db.Destinations.Find(des.Id);

                if (des.BgImageFile != null)
                {
                    string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.BgImageFile.FileName;
                    string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                    string bgoldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), dess.BgImage);
                    System.IO.File.Delete(bgoldImagePath);

                    des.BgImageFile.SaveAs(bgimagePath);
                    dess.BgImage = bgimageName;
                }

                if (des.SlideImageFile != null)
                {
                    string simageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.SlideImageFile.FileName;
                    string simagePath = Path.Combine(Server.MapPath("~/Uploads/"), simageName);

                    string soldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), dess.SliderImage);
                    System.IO.File.Delete(soldImagePath);

                    des.SlideImageFile.SaveAs(simagePath);
                    dess.SliderImage = simageName;
                }


                if (des.Pic1File != null)
                {
                    string pic1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic1File.FileName;
                    string pic1Path = Path.Combine(Server.MapPath("~/Uploads/"), pic1Name);

                    string oldpic1Path = Path.Combine(Server.MapPath("~/Uploads/"), des.Pic1);
                    System.IO.File.Delete(oldpic1Path);

                    des.Pic1File.SaveAs(pic1Path);
                    dess.Pic1 = pic1Name;
                }

                if (des.Pic1File != null)
                {
                    string pic1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic1File.FileName;
                    string pic1Path = Path.Combine(Server.MapPath("~/Uploads/"), pic1Name);

                    string oldpic1Path = Path.Combine(Server.MapPath("~/Uploads/"), des.Pic1);
                    System.IO.File.Delete(oldpic1Path);

                    des.Pic1File.SaveAs(pic1Path);
                    dess.Pic1 = pic1Name;
                }

                if (des.Pic2File != null)
                {
                    string pic2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic2File.FileName;
                    string pic2Path = Path.Combine(Server.MapPath("~/Uploads/"), pic2Name);

                    string oldpic2Path = Path.Combine(Server.MapPath("~/Uploads/"), des.Pic2);
                    System.IO.File.Delete(oldpic2Path);

                    des.Pic2File.SaveAs(pic2Path);
                    dess.Pic2 = pic2Name;
                }
                if (des.Pic3File != null)
                {
                    string pic3Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic3File.FileName;
                    string pic3Path = Path.Combine(Server.MapPath("~/Uploads/"), pic3Name);

                    string oldpic3Path = Path.Combine(Server.MapPath("~/Uploads/"), des.Pic3);
                    System.IO.File.Delete(oldpic3Path);

                    des.Pic3File.SaveAs(pic3Path);
                    dess.Pic3 = pic3Name;
                }
                if (des.Pic4File != null)
                {
                    string pic4Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic4File.FileName;
                    string pic4Path = Path.Combine(Server.MapPath("~/Uploads/"), pic4Name);

                    string oldpic4Path = Path.Combine(Server.MapPath("~/Uploads/"), des.Pic4);
                    System.IO.File.Delete(oldpic4Path);

                    des.Pic4File.SaveAs(pic4Path);
                    dess.Pic4 = pic4Name;
                }
                if (des.Pic5File != null)
                {
                    string pic5Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic5File.FileName;
                    string pic5Path = Path.Combine(Server.MapPath("~/Uploads/"), pic5Name);

                    string oldpic5Path = Path.Combine(Server.MapPath("~/Uploads/"), des.Pic5);
                    System.IO.File.Delete(oldpic5Path);

                    des.Pic5File.SaveAs(pic5Path);
                    dess.Pic5 = pic5Name;
                }
                if (des.Pic6File != null)
                {
                    string pic6Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + des.Pic6File.FileName;
                    string pic6Path = Path.Combine(Server.MapPath("~/Uploads/"), pic6Name);

                    string oldpic6Path = Path.Combine(Server.MapPath("~/Uploads/"), des.Pic6);
                    System.IO.File.Delete(oldpic6Path);

                    des.Pic6File.SaveAs(pic6Path);
                    dess.Pic6 = pic6Name;
                }

                dess.Name = des.Name;
                dess.Text1 = des.Text1;
                dess.Text2 = des.Text2;
                dess.MunText = des.MunText;
                dess.Visa = des.Visa;
                dess.Language = des.Language;
                dess.Area = des.Area;
                dess.Video = des.Video;

                db.Entry(dess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DestinationIndex");
            }
            return View(des);
        }

        public ActionResult DestinationDelete(int id)
        {
            Destination des = db.Destinations.Find(id);
            if (des == null)
            {
                return HttpNotFound();
            }

            db.Destinations.Remove(des);
            db.SaveChanges();

            return RedirectToAction("DestinationIndex");
        }

        // Destination CRUD  END//

        // Destination to Categories CRUD START//

        public ActionResult DesToCatIndex()
        {
            List<DesToCat> descats = db.DesToCats.Include("Destination").Include("TourCategory").ToList();
            return View(descats);
        }
        public ActionResult DesToCatCreate()
        {
            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourCategories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DesToCatCreate(DesToCat descat)
        {
            if (ModelState.IsValid)
            {
                db.DesToCats.Add(descat);
                db.SaveChanges();

                return RedirectToAction("DesToCatIndex");
            }
            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourCategories.ToList();
            return View(descat);
        }
        public ActionResult DesToCatUpdate(int id)
        {
            DesToCat descat = db.DesToCats.Find(id);
            if (descat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourCategories.ToList();
            return View(descat);
        }

        [HttpPost]
        public ActionResult DesToCatUpdate(DesToCat descat)
        {
            if (ModelState.IsValid)
            {
                DesToCat descatt = db.DesToCats.Find(descat.Id);

                descatt.DestinationId = descat.DestinationId;
                descatt.TourCategoryId = descat.TourCategoryId;

                db.Entry(descatt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DesToCatIndex");
            }

            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourCategories.ToList();
            return View(descat);
        }

        public ActionResult DesToCatDelete(int id)
        {
            DesToCat descat = db.DesToCats.Find(id);
            if (descat == null)
            {
                return HttpNotFound();
            }

            db.DesToCats.Remove(descat);
            db.SaveChanges();

            return RedirectToAction("DesToCatIndex");
        }

        // Destination to Categories CRUD END//

        // Destination to Type CRUD START//

        public ActionResult DesToTypeIndex()
        {
            List<DesToType> destypes = db.DesToTypes.Include("Destination").Include("TourType").ToList();
            return View(destypes);
        }
        public ActionResult DesToTypeCreate()
        {
            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourTypes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DesToTypeCreate(DesToType destype)
        {
            if (ModelState.IsValid)
            {
                db.DesToTypes.Add(destype);
                db.SaveChanges();

                return RedirectToAction("DesToTypeIndex");
            }
            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourTypes.ToList();
            return View(destype);
        }
        public ActionResult DesToTypeUpdate(int id)
        {
            DesToType destype = db.DesToTypes.Find(id);
            if (destype == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourTypes.ToList();
            return View(destype);
        }

        [HttpPost]
        public ActionResult DesToTypeUpdate(DesToType destype)
        {
            if (ModelState.IsValid)
            {
                DesToType destypee = db.DesToTypes.Find(destype.Id);

                destypee.DestinationId = destype.DestinationId;
                destypee.TourTypeId = destype.TourTypeId;

                db.Entry(destypee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DesToTypeIndex");
            }

            ViewBag.Categories1 = db.Destinations.ToList();
            ViewBag.Categories2 = db.TourTypes.ToList();
            return View(destype);
        }

        public ActionResult DesToTypeDelete(int id)
        {
            DesToType destype = db.DesToTypes.Find(id);
            if (destype == null)
            {
                return HttpNotFound();
            }

            db.DesToTypes.Remove(destype);
            db.SaveChanges();

            return RedirectToAction("DesToTypeIndex");
        }

        // Destination to Type CRUD END//

        // TOUR CITY CRUD START //

        public ActionResult TourCityIndex()
        {
            List<TourCity> tcities = db.TourCities.Include("Destination").ToList();
            return View(tcities);
        }
        public ActionResult TourCityCreate()
        {
            ViewBag.Categories = db.Destinations.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult TourCityCreate(TourCity tcity)
        {
            if (ModelState.IsValid)
            {
                db.TourCities.Add(tcity);
                db.SaveChanges();

                return RedirectToAction("TourCityIndex");
            }
            ViewBag.Categories = db.Destinations.ToList();
            return View(tcity);
        }
        public ActionResult TourCityUpdate(int id)
        {
            TourCity tcity = db.TourCities.Find(id);
            if (tcity == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Destinations.ToList();
            return View(tcity);
        }

        [HttpPost]
        public ActionResult TourCityUpdate(TourCity tcity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TourCityIndex");
            }

            ViewBag.Categories = db.Destinations.ToList();
            return View(tcity);
        }

        public ActionResult TourCityDelete(int id)
        {
            TourCity tcity = db.TourCities.Find(id);
            if (tcity == null)
            {
                return HttpNotFound();
            }

            db.TourCities.Remove(tcity);
            db.SaveChanges();

            return RedirectToAction("TourCityIndex");
        }

        // TOUR CITY CRUD END //

        // TOUR CRUD START //

        public ActionResult Index()
        {
            List<Tour> tours = db.Tours.Include("Admin").Include("TourCity").Include("TourCity.Destination").ToList();
            return View(tours);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = db.TourCities.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                Tour Tour = new Tour();

                if (tour.FrontImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(tour);
                }
                string fimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + tour.FrontImageFile.FileName;
                string fimagePath = Path.Combine(Server.MapPath("~/Uploads/"), fimageName);

                tour.FrontImageFile.SaveAs(fimagePath);
                tour.FrontImage = fimageName;

                if (tour.BgImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(tour);
                }
                string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + tour.BgImageFile.FileName;
                string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                tour.BgImageFile.SaveAs(bgimagePath);
                tour.BgImage = bgimageName;

                Tour.Name = tour.Name;
                Tour.Price = tour.Price;
                Tour.About = tour.About;
                Tour.Age = tour.Age;
                Tour.DeparturePlace = tour.DeparturePlace;
                Tour.DressCode = tour.DressCode;
                Tour.Text = tour.Text;
                Tour.TicketsNum = tour.TicketsNum;
                Tour.TourCityId = tour.TourCityId;
                Tour.AdminId = tour.AdminId;
                Tour.CreatedDate = DateTime.Now;

                //TimeSpan datef = TimeSpan.Parse(tour.DepartureTime.ToString("HH:mm"));
                //TimeSpan datet = TimeSpan.Parse(tour.ReturnTime.ToString("HH:mm"));
                //Tour.DepartureTime = datef;
                //Tour.ReturnTime = datet;
                Tour.DepartureTime = TimeSpan.Parse(Convert.ToString(tour.DepartureTime));
                Tour.ReturnTime = TimeSpan.Parse(Convert.ToString(tour.ReturnTime));



                //if (Session["Admin"]==null)
                //{
                //    Tour.AdminId = 1;
                //}
                //else
                //{
                //    Tour.AdminId = (int)Session["AdminId"];
                //}
                
                db.Tours.Add(tour);
                db.SaveChanges();

                foreach (HttpPostedFileBase image in tour.ImageFile)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + image.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                    image.SaveAs(imagePath);

                    TourImage tourImage = new TourImage();
                    tourImage.ImageName = imageName;
                    tourImage.TourId = Tour.Id;

                    db.TourImages.Add(tourImage);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.TourCities.ToList();
            return View(tour);
        }
        public ActionResult Update(int id)
        {
            Tour tour = db.Tours.Include("TourImage").FirstOrDefault(t=>t.Id==id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.TourCities.ToList();
            return View(tour);
        }

        [HttpPost]
        public ActionResult Update(Tour tour)
        {
            if (ModelState.IsValid)
            {
                Tour Tour = db.Tours.Include("TourImage").FirstOrDefault(t => t.Id == tour.Id);
                if (tour.FrontImageFile != null)
                {
                    string fimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + tour.FrontImageFile.FileName;
                    string fimagePath = Path.Combine(Server.MapPath("~/Uploads/"), fimageName);

                    string OldfimagePath = Path.Combine(Server.MapPath("~/Uploads/"), Tour.FrontImage);
                    System.IO.File.Delete(OldfimagePath);

                    tour.FrontImageFile.SaveAs(fimagePath);
                    Tour.FrontImage = fimageName;
                }
                if (tour.BgImageFile != null)
                {
                    string bgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + tour.BgImageFile.FileName;
                    string bgimagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgimageName);

                    string OldbgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Tour.BgImage);
                    System.IO.File.Delete(OldbgImagePath);

                    tour.BgImageFile.SaveAs(bgimagePath);
                    Tour.BgImage = bgimageName;
                }

                Tour.Name = tour.Name;
                Tour.Price = tour.Price;
                Tour.About = tour.About;
                Tour.Age = tour.Age;
                Tour.DeparturePlace = tour.DeparturePlace;
                Tour.DressCode = tour.DressCode;
                Tour.Text = tour.Text;
                Tour.TicketsNum = tour.TicketsNum;
                Tour.TourCityId = tour.TourCityId;
                Tour.AdminId = tour.AdminId;

                Tour.DepartureTime = tour.DepartureTime;
                Tour.ReturnTime = tour.ReturnTime;

                Tour.CreatedDate = tour.CreatedDate;


                db.Entry(Tour).State = EntityState.Modified;
                db.SaveChanges();

                if (tour.ImageFile[0] != null)
                {
                    using (SetSailContext db = new SetSailContext())
                    {
                        foreach (var image in db.TourImages.Where(c => c.TourId == Tour.Id))
                        {
                            string oldImagePath = Path.Combine(Server.MapPath("~/Uploads"), image.ImageName);
                            System.IO.File.Delete(oldImagePath);

                            db.TourImages.Remove(image);
                        }
                        db.SaveChanges();
                    }


                    foreach (HttpPostedFileBase image in tour.ImageFile)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + image.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                        image.SaveAs(imagePath);

                        TourImage tourImage = new TourImage();
                        tourImage.ImageName = imageName;
                        tourImage.TourId = Tour.Id;

                        db.TourImages.Add(tourImage);
                    }

                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.TourCities.ToList();
            return View(tour);
        }
        public ActionResult Delete(int id)
        {
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }

            db.Tours.Remove(tour);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // TOUR CRUD END //

        // TOUR TourDates CRUD START //

        //public ActionResult TourDatesIndex()
        //{
        //    List<TourDates> TourDatess = db.TourDates.Include("Tour").ToList();
        //    return View(TourDatess);
        //}
        //public ActionResult TourDatesCreate()
        //{
        //    ViewBag.Categories = db.Tours.ToList();
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult TourDatesCreate(TourDates TourDates)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TourDates.Add(TourDates);
        //        db.SaveChanges();

        //        return RedirectToAction("TourDatesIndex");
        //    }
        //    ViewBag.Categories = db.Tours.ToList();
        //    return View(TourDates);
        //}
        //public ActionResult TourDatesUpdate(int id)
        //{
        //    TourDates TourDates = db.TourDates.Find(id);
        //    if (TourDates == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Categories = db.Tours.ToList();
        //    return View(TourDates);
        //}

        //[HttpPost]
        //public ActionResult TourDatesUpdate(TourDates TourDates)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        db.Entry(TourDates).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("TourDatesIndex");
        //    }

        //    ViewBag.Categories = db.Tours.ToList();
        //    return View(TourDates);
        //}

        //public ActionResult TourDatesDelete(int id)
        //{
        //    TourDates TourDates = db.TourDates.Find(id);
        //    if (TourDates == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    db.TourDates.Remove(TourDates);
        //    db.SaveChanges();

        //    return RedirectToAction("TourDatesIndex");
        //}

        // TOUR TourDates CRUD END //

        // TOUR INCLUDE CRUD START //

        public ActionResult IncludeIndex()
        {
            List<Include> includes = db.Includes.Include("Tour").ToList();
            return View(includes);
        }
        public ActionResult IncludeCreate()
        {
            ViewBag.Categories = db.Tours.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult IncludeCreate(Include include)
        {
            if (ModelState.IsValid)
            {
                db.Includes.Add(include);
                db.SaveChanges();

                return RedirectToAction("IncludeIndex");
            }
            ViewBag.Categories = db.Tours.ToList();
            return View(include);
        }
        public ActionResult IncludeUpdate(int id)
        {
            Include include = db.Includes.Find(id);
            if (include == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Tours.ToList();
            return View(include);
        }

        [HttpPost]
        public ActionResult IncludeUpdate(Include include)
        {
            if (ModelState.IsValid)
            {

                db.Entry(include).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IncludeIndex");
            }

            ViewBag.Categories = db.Tours.ToList();
            return View(include);
        }

        public ActionResult IncludeDelete(int id)
        {
            Include include = db.Includes.Find(id);
            if (include == null)
            {
                return HttpNotFound();
            }

            db.Includes.Remove(include);
            db.SaveChanges();

            return RedirectToAction("IncludeIndex");
        }

        // TOUR INCLUDE CRUD END //

        // TOUR NOT INCLUDE CRUD START //

        public ActionResult NotIncludeIndex()
        {
            List<NotInclude> notincludes = db.NotIncludes.Include("Tour").ToList();
            return View(notincludes);
        }
        public ActionResult NotIncludeCreate()
        {
            ViewBag.Categories = db.Tours.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult NotIncludeCreate(NotInclude notinclude)
        {
            if (ModelState.IsValid)
            {
                db.NotIncludes.Add(notinclude);
                db.SaveChanges();

                return RedirectToAction("NotIncludeIndex");
            }
            ViewBag.Categories = db.Tours.ToList();
            return View(notinclude);
        }
        public ActionResult NotIncludeUpdate(int id)
        {
            NotInclude notinclude = db.NotIncludes.Find(id);
            if (notinclude == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Tours.ToList();
            return View(notinclude);
        }

        [HttpPost]
        public ActionResult NotIncludeUpdate(NotInclude notinclude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notinclude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NotIncludeIndex");
            }

            ViewBag.Categories = db.Tours.ToList();
            return View(notinclude);
        }

        public ActionResult NotIncludeDelete(int id)
        {
            NotInclude notinclude = db.NotIncludes.Find(id);
            if (notinclude == null)
            {
                return HttpNotFound();
            }

            db.NotIncludes.Remove(notinclude);
            db.SaveChanges();

            return RedirectToAction("NotIncludeIndex");
        }

        // TOUR NOT INCLUDE CRUD END //

        // TOUR DAY CRUD START //

        public ActionResult DayIndex()
        {
            List<Day> days = db.Days.Include("Tour").ToList();
            return View(days);
        }
        public ActionResult DayCreate()
        {
            ViewBag.Categories = db.Tours.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DayCreate(Day day)
        {
            if (ModelState.IsValid)
            {
                db.Days.Add(day);
                db.SaveChanges();

                return RedirectToAction("DayIndex");
            }
            ViewBag.Categories = db.Tours.ToList();
            return View(day);
        }
        public ActionResult DayUpdate(int id)
        {
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Tours.ToList();
            return View(day);
        }

        [HttpPost]
        public ActionResult DayUpdate(Day day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DayIndex");
            }

            ViewBag.Categories = db.Tours.ToList();
            return View(day);
        }

        public ActionResult DayDelete(int id)
        {
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }

            db.Days.Remove(day);
            db.SaveChanges();

            return RedirectToAction("DayIndex");
        }

        // TOUR DAY CRUD END //

        // TOUR DAY INCLUDE CRUD START //

        public ActionResult DayIncludeIndex()
        {
            List<DayInclude> dincludes = db.DayIncludes.Include("Day").ToList();
            return View(dincludes);
        }
        public ActionResult DayIncludeCreate()
        {
            ViewBag.Categories = db.Days.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DayIncludeCreate(DayInclude dinclude)
        {
            if (ModelState.IsValid)
            {
                db.DayIncludes.Add(dinclude);
                db.SaveChanges();

                return RedirectToAction("DayIncludeIndex");
            }
            ViewBag.Categories = db.Days.ToList();
            return View(dinclude);
        }
        public ActionResult DayIncludeUpdate(int id)
        {
            DayInclude dinclude = db.DayIncludes.Find(id);
            if (dinclude == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Days.ToList();
            return View(dinclude);
        }

        [HttpPost]
        public ActionResult DayIncludeUpdate(DayInclude dinclude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dinclude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DayIncludeIndex");
            }

            ViewBag.Categories = db.Days.ToList();
            return View(dinclude);
        }

        public ActionResult DayIncludeDelete(int id)
        {
            DayInclude dinclude = db.DayIncludes.Find(id);
            if (dinclude == null)
            {
                return HttpNotFound();
            }

            db.DayIncludes.Remove(dinclude);
            db.SaveChanges();

            return RedirectToAction("DayIncludeIndex");
        }

        // TOUR DAY INCLUDE CRUD END //

        // TOUR REVIEW RD START //

        public ActionResult TourReviewIndex()
        {
            List<TourReview> reviews = db.TourReviews.ToList();
            return View(reviews);
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

            return RedirectToAction("TourReviewIndex");
        }

        // TOUR REVIEW RD END //

        // TOUR IMAGES RD START //

        public ActionResult TourImagesIndex()
        {
            List<Tour> tours = db.Tours.Include("TourImages").ToList();
            return View(tours);
        }

        public ActionResult TourImagesDelete(int id)
        {
            Tour Tour = db.Tours.Include("TourImage").FirstOrDefault(t => t.Id == id);
            if (Tour.TourImages[0] != null)
            {
                using (SetSailContext db = new SetSailContext())
                {
                    foreach (var image in db.TourImages.Where(c => c.TourId == Tour.Id))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Uploads"), image.ImageName);
                        System.IO.File.Delete(oldImagePath);

                        db.TourImages.Remove(image);
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("TourImagesIndex");
        }

        // TOUR IMAGES RD END //

        // TOUR BOOKING RUD START //

        public ActionResult BookingIndex()
        {
            List<Booking> bookings = db.Bookings.Include("Tour").ToList();
            return View(bookings);
        }
        public ActionResult BookingUpdate(int id)
        {
            Booking bk = db.Bookings.Find(id);
            if (bk == null)
            {
                return HttpNotFound();
            }
            return View(bk);
        }

        [HttpPost]
        public ActionResult BookingUpdate(Booking book)
        {
            if (ModelState.IsValid)
            {
                Tour tour = db.Tours.Find(book.TourId);
                Booking bk = db.Bookings.Find(book.Id);

                tour.TicketsNum = Convert.ToByte(tour.TicketsNum + bk.Tickets);
                if (tour.TicketsNum >= book.Tickets)
                {
                    tour.TicketsNum = Convert.ToByte(tour.TicketsNum - book.Tickets);

                    db.Entry(tour).State = EntityState.Modified;

                    bk.Tickets = book.Tickets;
                    bk.Fullname = book.Fullname;
                    bk.Email = book.Email;
                    bk.Phone = book.Phone;
                    bk.CreatedDate = book.CreatedDate;
                    bk.UserId = book.UserId;
                    bk.DateFrom = book.DateFrom;
                    bk.DateTo = book.DateTo;

                    db.Entry(bk).State = EntityState.Modified;
                    db.SaveChanges();

                    Session["BookSent"] = true;

                    return RedirectToAction("BookingIndex");
                }
                else
                {
                    Session["NoTickets"] = true;
                    ModelState.AddModelError("Tickets", "Not Enough Tickets!. Tour Tickets left: "+tour.TicketsNum.ToString());
                    return View(book);
                }
            }
            return View(book);
        }

        public ActionResult BookingDelete(int id)
        {
            Booking bk = db.Bookings.Find(id);
            if (bk == null)
            {
                return HttpNotFound();
            }

            db.Bookings.Remove(bk);
            db.SaveChanges();

            return RedirectToAction("BookingIndex");
        }

        // TOUR BOOKING RUD END //

    }
}