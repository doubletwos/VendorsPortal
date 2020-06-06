using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendorsPortal.Migrations;
using VendorsPortal.Models;

namespace VendorsPortal.ViewModels
{
    public class QuotesProvidedViewModel
    {

        public IEnumerable<Quote> Quotes { get; set; }
        public IEnumerable<QuotesProvided> QuoteProvided { get; set; }





    }

}