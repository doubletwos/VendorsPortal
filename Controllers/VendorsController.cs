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
    public class VendorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendors
        public ActionResult Index()
        {
            var vendors = db.Vendors
                .Include(v => v.VendorType)
                .Include(a => a.Area)
                .ToList(); 
            
                return View(vendors);
        }


        [ChildActionOnly]
        public ActionResult Vends()
        {
            return PartialView("_Secure");
        }





        public ActionResult IndexAd(string VendorTypeId, string searcharea)
        {
            ViewBag.VendorTypeId = new SelectList(db.VendorTypes, "VendorTypeName", "VendorTypeName");
            var vendors = db.Vendors
            .Include(v => v.VendorType)
            .Include(a => a.Area)
            .ToList();
            ////// returns default value if both are and vendor type are empty
            if (string.IsNullOrWhiteSpace(VendorTypeId) && string.IsNullOrWhiteSpace(searcharea))
            {
                return View(vendors);
            }
            ////// returns values of all vendors in an area if area is selected but no vendor - works fine
            if (string.IsNullOrWhiteSpace(VendorTypeId) && !string.IsNullOrWhiteSpace(searcharea))
            {
                return View(db.Vendors
               .Include(t => t.VendorType)
               .Include(a => a.Area)
               .Where(a => a.Area.AreaName == searcharea)
               .ToList());
            }
            ////// returns values of all vendors if vendor is selected but area isnt - works fine
            if (!string.IsNullOrWhiteSpace(VendorTypeId) && string.IsNullOrWhiteSpace(searcharea))
            {
                return View(db.Vendors
               .Include(t => t.VendorType)
               .Include(a => a.Area)
               .Where(t => t.VendorType.VendorTypeName == VendorTypeId)
               .ToList());
            }
            //// returns values of matching vendors if both area and vendor type are provided
            ///
            if (!string.IsNullOrWhiteSpace(VendorTypeId) && !string.IsNullOrWhiteSpace(searcharea))
            //if (!( string.IsNullOrWhiteSpace(VendorTypeId) && !(string.IsNullOrWhiteSpace(searcharea))))
            {
                return View(db.Vendors
               .Include(t => t.VendorType)
               .Include(a => a.Area)
               .Where(t => t.VendorType.VendorTypeName == VendorTypeId)
               .Where(a => a.Area.AreaName == searcharea)
               .ToList());
            }
            else
                return View(vendors);

        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {

            var vendor = db.Vendors
                .Include(t => t.VendorType)
                 .Include(a => a.Area)
                 .Include(q => q.Quotes)
                .SingleOrDefault(c => c.VendorId == id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (vendor == null)
            {
                return HttpNotFound();
            }

            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {


            ViewBag.VendorTypeId = new SelectList(db.VendorTypes.OrderBy(s=>s.VendorTypeName), "VendorTypeId", "VendorTypeName");
            ViewBag.AreaId = new SelectList(db.Areas.OrderBy(a => a.AreaName), "AreaId", "AreaName");
            return View();
        }

        // POST: Vendors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType


                    };

                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    vendor.Files = new List<File> {avatar};

                }
               
                vendor.RegistrationDate = DateTime.Now;
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorTypeId = new SelectList(db.VendorTypes.OrderByDescending(s => s.VendorTypeName), "VendorTypeId", "VendorTypeName", vendor.VendorTypeId);
            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorTypeId = new SelectList(db.VendorTypes, "VendorTypeId", "VendorTypeName", vendor.VendorTypeId);
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorTypeId = new SelectList(db.VendorTypes, "VendorTypeId", "VendorTypeName", vendor.VendorTypeId);
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
