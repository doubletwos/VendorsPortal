using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using VendorsPortal.Models;
using VendorsPortal.ViewModels;

namespace VendorsPortal.Controllers
{
    public class QuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quotes
        //public ActionResult Index(int? id)
        //{

        //    var quotes = db.Quotes.Include(c => c.QuotesProvided).ToList();


        //    var vendor = db.Vendors
        //    .SingleOrDefault(c => c.VendorId == id);

        //    return View(db.Quotes
        //    .Where(i => i.VendorId == id)
        //     .ToList());
        //    //return View(quotes);
        //}


        public ActionResult QuotesProvided(int? id)
        {
            var quotes = db.Quotes.SingleOrDefault(c => c.QuoteId == id);

            var viewmodel = new QuotesProvidedViewModel();

            viewmodel.Quotes = db.Quotes
            .Include(q => q.QuotesProvided)
            .Where(i => i.VendorId == id);

            return View(viewmodel);
        }




        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
          
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quote quote, int? id)
        {

            var vendor = db.Vendors.SingleOrDefault(c => c.VendorId == id);



            if (ModelState.IsValid)
            {

                quote.VendorId = (int)id;
             
                db.Quotes.Add(quote);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(quote);
        }



   





        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
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
