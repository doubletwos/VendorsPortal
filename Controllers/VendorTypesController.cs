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
    public class VendorTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VendorTypes
        public ActionResult Index()
        {
            return View(db.VendorTypes.ToList());
        }

        // GET: VendorTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorType vendorType = db.VendorTypes.Find(id);
            if (vendorType == null)
            {
                return HttpNotFound();
            }
            return View(vendorType);
        }

        // GET: VendorTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorTypeId,VendorTypeName")] VendorType vendorType)
        {
            if (ModelState.IsValid)
            {
                db.VendorTypes.Add(vendorType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorType);
        }

        // GET: VendorTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorType vendorType = db.VendorTypes.Find(id);
            if (vendorType == null)
            {
                return HttpNotFound();
            }
            return View(vendorType);
        }

        // POST: VendorTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorTypeId,VendorTypeName")] VendorType vendorType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorType);
        }

        // GET: VendorTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorType vendorType = db.VendorTypes.Find(id);
            if (vendorType == null)
            {
                return HttpNotFound();
            }
            return View(vendorType);
        }

        // POST: VendorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorType vendorType = db.VendorTypes.Find(id);
            db.VendorTypes.Remove(vendorType);
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
