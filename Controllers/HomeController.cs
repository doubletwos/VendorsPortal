using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

            
            var vendors = db.Vendors
            .Include(v => v.VendorType)
            .ToList();

            ViewBag.VendorTypeId = new SelectList(db.VendorTypes, "VendorTypeId", "VendorTypeName"/*, vendor.VendorTypeId*/);



            return View(vendors);

           
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