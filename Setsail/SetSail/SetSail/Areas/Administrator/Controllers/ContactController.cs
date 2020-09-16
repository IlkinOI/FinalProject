using SetSail.Areas.Administrator.Filters;
using SetSail.DAL;
using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetSail.Areas.Administrator.Controllers
{
    [filterAdmin]
    public class ContactController : Controller
    {
        // GET: Administrator/Contact
        SetSailContext db = new SetSailContext();

        // CONTACT COUTRY CRUD START //

        public ActionResult ContactCountryIndex()
        {
            List<ContactCountry> cc = db.ContactCountries.ToList();
            return View(cc);
        }
        public ActionResult ContactCountryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactCountryCreate(ContactCountry cc)
        {
            if (ModelState.IsValid)
            {
                db.ContactCountries.Add(cc);
                db.SaveChanges();

                return RedirectToAction("ContactCountryIndex");
            }

            return View(cc);
        }

        public ActionResult ContactCountryUpdate(int id)
        {
            ContactCountry cc = db.ContactCountries.Find(id);
            if (cc == null)
            {
                return HttpNotFound();
            }

            return View(cc);
        }

        [HttpPost]
        public ActionResult ContactCountryUpdate(ContactCountry cc)
        {
            if (ModelState.IsValid)
            {

                db.Entry(cc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ContactCountryIndex");
            }

            return View(cc);
        }

        public ActionResult ContactCountryDelete(int id)
        {
            ContactCountry cc = db.ContactCountries.Find(id);
            if (cc == null)
            {
                return HttpNotFound();
            }

            db.ContactCountries.Remove(cc);
            db.SaveChanges();

            return RedirectToAction("ContactCountryIndex");
        }

        // CONTACT COUTRY CRUD END //

        // CONTACT CITY CRUD START //

        public ActionResult ContactCityIndex()
        {
            List<ContactCity> ccities = db.ContactCities.Include("ContactCountry").ToList();
            return View(ccities);
        }
        public ActionResult ContactCityCreate(int? id)
        {
            ViewBag.Categories = db.ContactCountries.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ContactCityCreate(ContactCity ccity)
        {
            if (ModelState.IsValid)
            {
                db.ContactCities.Add(ccity);
                db.SaveChanges();

                return RedirectToAction("ContactCityIndex");
            }
            ViewBag.Categories = db.ContactCountries.ToList();
            return View(ccity);
        }
        public ActionResult ContactCityUpdate(int id)
        {
            ContactCity ccity = db.ContactCities.Find(id);
            if (ccity == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.ContactCountries.ToList();
            return View(ccity);
        }

        [HttpPost]
        public ActionResult ContactCityUpdate(ContactCity ccity)
        {
            if (ModelState.IsValid)
            {
                ContactCity ccityy = db.ContactCities.Find(ccity.Id);

                ccityy.Name = ccity.Name;
                ccityy.ContactCountryId = ccity.ContactCountryId;


                db.Entry(ccityy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ContactCityIndex");
            }

            ViewBag.Categories = db.ContactCountries.ToList();
            return View(ccity);
        }

        public ActionResult ContactCityDelete(int id)
        {
            ContactCity ccity = db.ContactCities.Find(id);
            if (ccity == null)
            {
                return HttpNotFound();
            }

            db.ContactCities.Remove(ccity);
            db.SaveChanges();

            return RedirectToAction("ContactCityIndex");
        }

        // CONTACT CITY CRUD END //

        // CONTACT CRUD START //

        public ActionResult Index()
        {
            List<Contact> contacts = db.Contacts.Include("ContactCity").Include("ContactCity.ContactCountry").ToList();
            return View(contacts);
        }
        public ActionResult Create(int? id)
        {
            ViewBag.Categories = db.ContactCities.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.ContactCities.ToList();
            return View(contact);
        }
        public ActionResult Update(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.ContactCities.ToList();
            return View(contact);
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contact contactt = db.Contacts.Find(contact.Id);

                contactt.Email = contact.Email;
                contactt.Phone1 = contact.Phone1;
                contactt.Phone2 = contact.Phone2;
                contactt.Address = contact.Address;
                contactt.Map = contact.Map;
                contactt.ContactCityId = contact.ContactCityId;

                db.Entry(contactt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.ContactCities.ToList();
            return View(contact);
        }

        public ActionResult Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // CONTACT CRUD END //

        // CONTACT SOCIAL CRUD START //

        public ActionResult ContactSocialIndex()
        {
            List<ContactSocial> csocials = db.ContactSocials.Include("Contact").Include("Contact.ContactCity").ToList();
            return View(csocials);
        }
        public ActionResult ContactSocialCreate(int? id)
        {
            ViewBag.Categories = db.Contacts.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ContactSocialCreate(ContactSocial csocial)
        {
            if (ModelState.IsValid)
            {
                db.ContactSocials.Add(csocial);
                db.SaveChanges();

                return RedirectToAction("ContactSocialIndex");
            }
            ViewBag.Categories = db.Contacts.ToList();
            return View(csocial);
        }
        public ActionResult ContactSocialUpdate(int id)
        {
            ContactSocial csocial = db.ContactSocials.Find(id);
            if (csocial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Contacts.ToList();
            return View(csocial);
        }

        [HttpPost]
        public ActionResult ContactSocialUpdate(ContactSocial csocial)
        {
            if (ModelState.IsValid)
            {
                ContactSocial csocialy = db.ContactSocials.Find(csocial.Id);

                csocialy.Icon = csocial.Icon;
                csocialy.Link = csocial.Link;
                csocialy.ContactId = csocial.ContactId;

                db.Entry(csocialy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ContactSocialIndex");
            }

            ViewBag.Categories = db.Contacts.ToList();
            return View(csocial);
        }

        public ActionResult ContactSocialDelete(int id)
        {
            ContactSocial csocial = db.ContactSocials.Find(id);
            if (csocial == null)
            {
                return HttpNotFound();
            }

            db.ContactSocials.Remove(csocial);
            db.SaveChanges();

            return RedirectToAction("ContactSocialIndex");
        }


        // CONTACT SOCIAL CRUD END //

        // CONTACT REPLY CRUD START //

        public ActionResult ContactReplyIndex()
        {
            List<ContactReply> replies = db.contactReplies.ToList();
            return View(replies);
        }

        public ActionResult ContactReplyDelete(int id)
        {
            ContactReply r = db.contactReplies.Find(id);
            if (r == null)
            {
                return HttpNotFound();
            }

            db.contactReplies.Remove(r);
            db.SaveChanges();

            return RedirectToAction("ContactReplyIndex");
        }

        // CONTACT REPLY CRUD END //
    }
}