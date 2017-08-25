using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;
using EPiServer.Find.Framework;
using EPiServer.Find.Cms;
using EPiServer.Find;
using System.Collections.Generic;
using EPiServer.Find.Api.Facets;
using KtmCompany.Web.Models.ViewModels.Search;

namespace KtmCompany.Web.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        public ActionResult Index(string category, string searchText)
        {
            var searchPage = new SearchPageViewModel
            {
                CurrentPage = CurrentPage,
                CurrentPageIndex = 1
            };
            SearchingCriteria(searchPage.CurrentPageIndex, CurrentPage.PageSize, category, searchText, searchPage, true);
            return View(searchPage);
        }

        public ActionResult LoadMoreArticles(int pageSize, int currentPageIndex, string category, string searchText)
        {
            var searchPage = new SearchPageViewModel();
            SearchingCriteria(currentPageIndex + 1, pageSize, category, searchText, searchPage);
            return PartialView("ResultListItems", searchPage);
        }
        
        private void SearchingCriteria(int pageIndex, int pageSize, string category, string searchText, SearchPageViewModel searchPage, bool isFirstLoad = false)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 6;
            }

            var query = SearchClient.Instance.Search<PageDataBase>();

            //Seaching
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.For(searchText);
            }

            //filter by Category
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Filter(x => x.ContentCategory.MatchCaseInsensitive(category));
            }

            //paging
            query = query.FilterForVisitor().ExcludeDeleted().OrderByDescending(x => x.StartPublish).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            query = query.TermsFacetFor(x => x.ContentCategory);

            var searchResults = query.GetContentResult();

            searchPage.SearchCriteria = searchText;
            searchPage.TotalResults = searchResults.TotalMatching;
            searchPage.TermFacetItem = GetTermFacetItems(searchResults.TermsFacetFor(x => x.ContentCategory).Terms);

            searchPage.ResultPages = searchResults;
            searchPage.IsMoreItemsExist = searchResults.TotalMatching > pageSize * pageIndex;
            searchPage.ContentCategory = category;
            searchPage.IsFirstLoad = isFirstLoad;
        }

        private IEnumerable<TermFacetItem> GetTermFacetItems(IEnumerable<TermCount> termCounts)
        {
            return termCounts?.Select(tc => new TermFacetItem { Term = tc.Term, Count = tc.Count }) ?? new List<TermFacetItem>();
        }
    }
}