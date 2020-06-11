using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using VendorsPortal.Migrations;
using VendorsPortal.Models;

namespace VendorsPortal.Controllers
{
    public class QuotesProvidedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuotesProvided
        public ActionResult Index(int? id)
        {
            var quotesProvided = db.QuotesProvided.ToList(); ;

            return View(quotesProvided);
        }




        // GET: QuotesProvided/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotesProvided quotesProvided = db.QuotesProvided.Find(id);
            if (quotesProvided == null)
            {
                return HttpNotFound();
            }
            return View(quotesProvided);
        }

        // GET: QuotesProvided/Create
        public ActionResult Create()
        {
            ViewBag.QuoteId = new SelectList(db.Quotes, "QuoteId", "QuoteId");

            return View();
        }

        // POST: QuotesProvided/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuotesProvided quotesProvided, int? id)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Where(q => q.QuoteId == id);

                quotesProvided.QuoteId = (int)id;

                db.QuotesProvided.Add(quotesProvided);
                db.SaveChanges();
                return RedirectToAction("QuotesProvided", "Quotes");

            }

            //ViewBag.QuoteId = new SelectList(db.Quotes, "QuoteId", "FirstName", quotesProvided.QuoteId);
            return View(quotesProvided);
        }

        // GET: QuotesProvided/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotesProvided quotesProvided = db.QuotesProvided.Find(id);
            if (quotesProvided == null)
            {
                return HttpNotFound();
            }
            //ViewBag.QuoteId = new SelectList(db.Quotes, "QuoteId", "FirstName", quotesProvided.QuoteId);
            return View(quotesProvided);
        }

        // POST: QuotesProvided/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuotesProvided quotesProvided)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotesProvided).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.QuoteId = new SelectList(db.Quotes, "QuoteId", "FirstName", quotesProvided.QuoteId);
            return View(quotesProvided);
        }

        // GET: QuotesProvided/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotesProvided quotesProvided = db.QuotesProvided.Find(id);
            if (quotesProvided == null)
            {
                return HttpNotFound();
            }
            return View(quotesProvided);
        }

        // POST: QuotesProvided/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuotesProvided quotesProvided = db.QuotesProvided.Find(id);
            db.QuotesProvided.Remove(quotesProvided);
            db.SaveChanges();
            return RedirectToAction("Index");
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
