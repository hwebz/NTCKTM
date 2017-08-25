using KtmCompany.Web.Controllers;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KtmCompany.Web.Models.ViewModels
{
    public class SearchPageViewModel
    {
        public SearchPage CurrentPage { get; set; }

        public virtual int CurrentPageIndex { get; set; }

        public virtual IEnumerable<PageDataBase> ResultPages { get; set; }

        public virtual bool IsMoreItemsExist { get; set; }

        public virtual bool IsFirstLoad { get; set; }

        public virtual string ContentCategory { get; set; }

        public IEnumerable<TermFacetItem> TermFacetItem { get; set; }

        public virtual int TotalResults { get; set; }

        public virtual string SearchCriteria { get; set; }
    }
}