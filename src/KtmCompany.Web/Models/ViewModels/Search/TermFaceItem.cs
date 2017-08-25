using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KtmCompany.Web.Models.ViewModels.Search
{
    public class TermFacetItem
    {
        public string Term { get; set; }
        public int Count { get; set; }
    }
}