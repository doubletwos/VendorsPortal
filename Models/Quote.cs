using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendorsPortal.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        [Display(Name = "Telephone Number ")]
        [Required(ErrorMessage = "Please Provide Your Telephone Number")]
        public string Telephone { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Provide Your Email Address")]
        public string Email { get; set; }


        public string EventType { get; set; }   


        public string BriefDescription { get; set; }

        public bool Budget { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventDate { get; set; }

        public bool DateConfirmed { get; set; }

        public string ContactFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }



        public virtual QuotesProvided QuotesProvided { get; set; }




    }
}