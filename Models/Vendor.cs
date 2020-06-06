using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendorsPortal.Models
{
    public class Vendor
    {

   
        public int VendorId { get; set; }

        [Display(Name = "Business Name")]
        [Required(ErrorMessage="Please Provide Your Business Name")]
        public string VendorName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Provide Your Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mobile Number")]
        public string VendorMobile { get; set; }

        [Display(Name = "Telephone Number ")]
        [Required(ErrorMessage = "Please Provide Your Telephone Number")]
        public string VendorTelephone { get; set;}

        [Display(Name = "Contact First Name")]
        [Required(ErrorMessage = "A Contact First Name Is Required")]
        public string ContactFirstName { get; set; }

        [Display(Name = "Contact Last Name")]
        [Required(ErrorMessage = "A Contact Last Name Is Required")]
        public string ContactLastName { get; set; }

       
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationDate { get; set; }

       
        [Required(ErrorMessage = "Please Select Your Vendor Type")]
        [Display(Name = "Vendor Type")]
        public int VendorTypeId { get; set; }
        public VendorType VendorType { get; set; }


        [Required(ErrorMessage = "Please Select Area")]
        [Display(Name = "Area")]
        public int AreaId { get; set; }
        public Area Area { get; set; }

        public string LoginErrorMsg { get; set; }   



        public string ContactFullName
        {
            get
            {
                return ContactFirstName + " "+ ContactLastName;
            }
        }

        public virtual ICollection<File> Files { get; set; }


        public virtual ICollection<Quote> Quotes { get; set; }

    }
}