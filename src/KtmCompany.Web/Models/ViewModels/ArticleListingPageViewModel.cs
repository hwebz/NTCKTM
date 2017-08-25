using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels.Search;

namespace KtmCompany.Web.Models.ViewModels
{
    public class ArticleListingPageViewModel
    {
        public ArticleListingPage CurrentPage { get; set; }

        public int CurrentPageIndex { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public IEnumerable<ArticlePage> Articles { get; set; }

        public bool IsMoreItemsExist { get; set; }

        public string ArticleCategory { get; set; }

        public IEnumerable<TermFacetItem> TermFacetItem { get; set; }
    }
}