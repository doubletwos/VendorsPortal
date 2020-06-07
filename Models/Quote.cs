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

        [StringLength(14)]
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please provide your first name")]
        public string FirstName { get; set; }

       
        [StringLength(14)]
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please provide your last name")]
        public string LastName { get; set; }

        [StringLength(11)]
        [Display(Name="Telephone number")]
        [Required(ErrorMessage="Please provide your telephone number")]
        public string Telephone { get; set; }


        [StringLength(15)]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please provide your email address")]
        public string Email { get; set; }

        [StringLength(12)]
        [Display(Name = "Type of event")]
        [Required(ErrorMessage = "Please specify the event type")]
        public string EventType { get; set; }

        [StringLength(40)]
        [Display(Name = "Brief description of your event")]
        public string BriefDescription { get; set; }

      
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventDate { get; set; }

        [Display(Name ="Event date confirmed?")]
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