using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VendorsPortal.Models;

namespace VendorsPortal.Controllers
{
    public class VendorAreasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VendorAreas
        public ActionResult Index()
        {
            return View(db.VendorAreas.ToList());
        }

        // GET: VendorAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorArea vendorArea = db.VendorAreas.Find(id);
            if (vendorArea == null)
            {
                return HttpNotFound();
            }
            return View(vendorArea);
        }

        // GET: VendorAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VendorAreaName")] VendorArea vendorArea)
        {
            if (ModelState.IsValid)
            {
                db.VendorAreas.Add(vendorArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorArea);
        }

        // GET: VendorAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorArea vendorArea = db.VendorAreas.Find(id);
            if (vendorArea == null)
            {
                return HttpNotFound();
            }
            return View(vendorArea);
        }

        // POST: VendorAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VendorAreaName")] VendorArea vendorArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorArea);
        }

        // GET: VendorAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorArea vendorArea = db.VendorAreas.Find(id);
            if (vendorArea == null)
            {
                return HttpNotFound();
            }
            return View(vendorArea);
        }

        // POST: VendorAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorArea vendorArea = db.VendorAreas.Find(id);
            db.VendorAreas.Remove(vendorArea);
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
