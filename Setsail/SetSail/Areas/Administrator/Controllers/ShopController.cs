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
    public class ShopController : Controller
    {
        // GET: Administrator/Product
        SetSailContext db = new SetSailContext();

        //Product Category CRUD START//

        public ActionResult ProductCategoryIndex()
        {
            List<ProductCategory> categories = db.ProductCategories.ToList();
            return View(categories);
        }
        public ActionResult ProductCategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductCategoryCreate(ProductCategory cat)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(cat);
                db.SaveChanges();

                return RedirectToAction("ProductCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult ProductCategoryUpdate(int id)
        {
            ProductCategory cat = db.ProductCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        [HttpPost]
        public ActionResult ProductCategoryUpdate(ProductCategory cat)
        {
            if (ModelState.IsValid)
            {
                ProductCategory pcat = db.ProductCategories.Find(cat.Id);

                pcat.Name = cat.Name;

                db.Entry(pcat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult ProductCategoryDelete(int id)
        {
            ProductCategory cat = db.ProductCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            db.ProductCategories.Remove(cat);
            db.SaveChanges();

            return RedirectToAction("ProductCategoryIndex");
        }

        // Product Category CRUD End//

        // Product CRUD Start//

        public ActionResult ProductIndex()
        {
            List<Product> products = db.Products.Include("Admin").Include("ProductImages").Include("ProductCategory").Include("ProductReviews").ToList();
            return View(products);
        }
        public ActionResult ProductCreate()
        {
            ViewBag.Categories = db.ProductCategories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product prod)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();

                product.Name = prod.Name;
                product.About = prod.About;
                product.Price = prod.Price;
                product.Quantity = prod.Quantity;
                product.Code = prod.Code;
                product.Description = prod.Description;
                product.Weight = prod.Weight;
                product.Width = prod.Width;
                product.Height = prod.Height;
                product.Length = prod.Length;
                product.CreatedDate = DateTime.Now;
                product.AdminId = (int)Session["AdminId"];
                product.ProductCategoryId = prod.ProductCategoryId;

                db.Products.Add(product);
                db.SaveChanges();

                foreach (HttpPostedFileBase image in prod.ImageFile)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + image.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                    image.SaveAs(imagePath);

                    ProductImage proImage = new ProductImage();
                    proImage.Name = imageName;
                    proImage.ProductId = product.Id;

                    db.ProductImages.Add(proImage);
                    db.SaveChanges();
                }
                return RedirectToAction("ProductIndex");
            }
            ViewBag.Categories = db.ProductCategories.ToList();
            return View(prod);
        }
        public ActionResult ProductUpdate(int id)
        {
            Product product = db.Products.Include("ProductImages").Include("ProductCategory").FirstOrDefault(p=>p.Id==id);
            if (product==null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.ProductCategories.ToList();
            return View(product);
        }
        [HttpPost]
        public ActionResult ProductUpdate(Product prod)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.Include("ProductImages").Include("ProductCategory").FirstOrDefault(p => p.Id == prod.Id);

                product.Name = prod.Name;
                product.About = prod.About;
                product.Price = prod.Price;
                product.Quantity = prod.Quantity;
                product.Code = prod.Code;
                product.Description = prod.Description;
                product.Weight = prod.Weight;
                product.Width = prod.Width;
                product.Height = prod.Height;
                product.Length = prod.Length;

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                if (prod.ImageFile[0] != null)
                {
                    using (SetSailContext db = new SetSailContext())
                    {
                        foreach (var img in db.ProductImages.Where(c => c.ProductId == prod.Id))
                        {
                            string oldImagePath = Path.Combine(Server.MapPath("~/Uploads"), img.Name);
                            System.IO.File.Delete(oldImagePath);

                            db.ProductImages.Remove(img);
                        }
                        db.SaveChanges();
                    }


                    foreach (HttpPostedFileBase image in prod.ImageFile)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + image.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                        image.SaveAs(imagePath);

                        ProductImage prodImage = new ProductImage();
                        prodImage.Name = imageName;
                        prodImage.ProductId = product.Id;

                        db.ProductImages.Add(prodImage);
                    }

                    db.SaveChanges();
                }
                return RedirectToAction("ProductIndex");
            }
            return View(prod);
        }

        public ActionResult ProductDelete(int id)
        {
            Product product = db.Products.Include("ProductImages").FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            if (product.ImageFile[0] != null)
            {
                using (SetSailContext db = new SetSailContext())
                {
                    foreach (var img in db.ProductImages.Where(c => c.ProductId == product.Id))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Uploads"), img.Name);
                        System.IO.File.Delete(oldImagePath);

                        db.ProductImages.Remove(img);
                    }
                    db.SaveChanges();
                }
            }
            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("ProductIndex");
        }

        //Product CRUD End//
    }
}