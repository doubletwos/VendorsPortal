using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendorsPortal.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }


        [Display(Name = "Your email address")]
        public string SendersEmail { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateReceived { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Your first mame is required")]
        public string ContactFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Your last name is required")]
        public string ContactLastName { get; set; }


        public string ContactFullName
        {
            get
            {
                return ContactFirstName + " " + ContactLastName;
            }
        }


        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set;}

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please type your message")]
        [Display(Name = "Message")]
        [StringLength(250, ErrorMessage = "You are only allowed 250 characters")]
        public string MessageReceived { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "You are only allowed 250 characters")]
        public string MessageSent { get; set; } 


    }
}