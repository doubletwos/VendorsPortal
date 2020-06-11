using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendorsPortal.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string EventType { get; set; }

        public DateTime? EventDate { get; set; }

        public DateTime? BookingDate { get; set; }

        public Double? Price { get; set; }

        public bool? IsBooked { get; set; }

        public Vendor Vendor { get; set; }

        [ForeignKey("QuotesProvided")]
        public int QuoteId { get; set; }

        public QuotesProvided   QuotesProvided { get; set; }


        // test

        public string AdditionalInformation { get; set; }

     

        //test



        //public DateTime BookingStartTime { get; set; }

        //public DateTime BookingEndTime { get; set; }

        //public int NumberOfGuests { get; set; }

        //public string VenueAddress { get; set; }    


















    }
}