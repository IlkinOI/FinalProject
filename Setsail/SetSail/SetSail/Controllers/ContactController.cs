using SetSail.DAL;
using SetSail.Models;
using SetSail.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetSail.Controllers
{
    public class ContactController : Controller
    {
        SetSailContext db = new SetSailContext();
        // GET: Contact
        public ActionResult Index()
        {
            VmContact contact = new VmContact();
            contact.Contacts = db.Contacts.Include("ContactCity").Include("ContactCity.ContactCountry").Take(3).ToList();
            ViewBag.Contact = true;
            return View(contact);
        }

        // CONTACT REPLY CRUD START //
        [HttpPost]
        public ActionResult ContactReply(VmContact vmcr)
        {
            if (string.IsNullOrEmpty(vmcr.Message) || string.IsNullOrEmpty(vmcr.Fullname) ||
                string.IsNullOrEmpty(vmcr.Email))
            {
                Session["EmptyReply"] = true;
                return RedirectToAction("Index");
            }
            if (Session["User"] != null)
            {
                ContactReply cr = new ContactReply();

                cr.Message = vmcr.Message;
                cr.Fullname = vmcr.Fullname;
                cr.Email = vmcr.Email;
                cr.CreatedDate = DateTime.Now;
                cr.UserId = (int)Session["UserId"];

                db.contactReplies.Add(cr);
                db.SaveChanges();

                Session["ReplySent"] = true;
            }
            return RedirectToAction("Index");
        }

        // CONTACT REPLY CRUD END //
    }
}