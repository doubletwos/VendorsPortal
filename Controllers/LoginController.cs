using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VendorsPortal.Migrations;
using VendorsPortal.Models;

namespace VendorsPortal.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Signin(Vendor vendor)
        {
            var vendordetails = db.Vendors.Where(x => x.Email == vendor.Email && x.Password == vendor.Password).FirstOrDefault();
            if (vendordetails == null)
            {
                vendor.LoginErrorMsg = "Invalid Email or Password";
                return View("Index", vendor);
            }
            else
            {
                Session["vendorId"] = vendordetails.VendorId.ToString();
                Session["Email"] = vendor.Email.ToString();
                return RedirectToAction("Details", "Vendors", new { id = vendordetails.VendorId });
            }
        }
    }


}