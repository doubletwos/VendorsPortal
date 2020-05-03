using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VendorsPortal.Models;

namespace VendorsPortal.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 

        public ActionResult Index(string VendorTypeId, string searcharea)
        {
            ViewBag.VendorTypeId = new SelectList(db.VendorTypes.OrderBy(s => s.VendorTypeName), "VendorTypeName", "VendorTypeName");

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


        public ActionResult Details1(int? id)
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
           
            return RedirectToAction("Details", "Vendors", new { id });


        }















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminPage()
        {
            return View();
        }


    }
}