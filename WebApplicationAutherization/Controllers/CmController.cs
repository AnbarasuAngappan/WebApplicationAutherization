using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationAutherization.Models;

namespace WebApplicationAutherization.Controllers
{
    //[Authorize]
    public class CmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cm
        [Authorize(Roles = "CanRead")]
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Cm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }


        [Authorize(Roles = "canCreate")]
        public ActionResult canCreateView()
        {
            List<Contact> contacts = db.Contacts.ToList();
            return View(contacts);
        }


        // GET: Cm/Create
        [Authorize(Roles = "canCreate")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canCreate")]
        public ActionResult Create([Bind(Include = "ContactID,Name,Address,City,State,Zip,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("canCreateView");
            }

            return View(contact);
        }


        [Authorize(Roles = "canEdit")]
        public ActionResult CanEditView()
        {
            List<Contact> contacts = db.Contacts.ToList();
            return View(contacts);
        }


        // GET: Cm/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Cm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "ContactID,Name,Address,City,State,Zip,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CanEditView");
            }
            return View(contact);
        }

        [Authorize(Roles = "canDelete")]
        public ActionResult canDeleteView()
        {
            List<Contact> contacts = db.Contacts.ToList();
            return View(contacts);
        }


        // GET: Cm/Delete/5
        [Authorize(Roles = "canDelete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Cm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("canDeleteView");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
