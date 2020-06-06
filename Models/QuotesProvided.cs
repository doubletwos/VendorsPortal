using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendorsPortal.Models
{
    public class QuotesProvided
    {


        [Key]
        [ForeignKey("Quote")]
        public int QuoteId { get; set; }

        [Required]
        public Double? Price { get; set; }

        public string AdditionalInformation { get; set; }

        public virtual Quote Quote { get; set; }










    }
}