using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class JobListingPageViewModel
    {
        public JobListingPage CurrentPage { get; set; }

        public IEnumerable<JobDetailPage> JobDetailPages { get; set; }

        public virtual bool IsMoreItemsExist { get; set; }
    }
}