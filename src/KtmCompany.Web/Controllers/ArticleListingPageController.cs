using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KtmCompany.Web.Helpers;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Models.PageTypes;
using EPiServer.Find;
using EPiServer.Find.Api.Facets;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using KtmCompany.Web.Models.ViewModels;
using KtmCompany.Web.Models.ViewModels.Search;

namespace KtmCompany.Web.Controllers
{
    public class ArticleListingPageController : PageControllerBase<ArticleListingPage>
    {
        public ActionResult Index(string cat)
        {
            var articleListingPage = new ArticleListingPageViewModel
            {
                CurrentPage = CurrentPage,
                Categories = CategoryHelpers.GetCategorySelectionsByPath(),
                CurrentPageIndex = 1
            };

            SearchArticles(articleListingPage.CurrentPageIndex, CurrentPage.PageSize, cat, articleListingPage);
            return View(articleListingPage);
        }

        public ActionResult LoadMoreArticles(int pageSize, int currentPageIndex, string category)
        {
            var articleListingPage = new ArticleListingPageViewModel();
            SearchArticles(currentPageIndex + 1, pageSize, category, articleListingPage);
            return PartialView("ArticleListItem", articleListingPage);
        }

        private void SearchArticles(int pageIndex, int pageSize, string category, ArticleListingPageViewModel articleListingPage)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 6;
            }

            var query = SearchClient.Instance.Search<ArticlePage>().FilterForVisitor();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Filter(x => x.ContentCategory.MatchCaseInsensitive(category));
            }
            query = query.FilterForVisitor().OrderByDescending(x => x.StartPublish).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            query = query.TermsFacetFor(x => x.ContentCategory);

            var result = query.GetContentResult();
            articleListingPage.Articles = result;
            articleListingPage.IsMoreItemsExist = result.TotalMatching > pageSize * pageIndex;
            articleListingPage.ArticleCategory = category;
            articleListingPage.TermFacetItem = GetTermFacetItems(result.TermsFacetFor(x => x.ContentCategory).Terms);
        }

        private IEnumerable<TermFacetItem> GetTermFacetItems(IEnumerable<TermCount> termCounts)
        {
            return termCounts?.Select(tc => new TermFacetItem { Term = tc.Term, Count = tc.Count }) ?? new List<TermFacetItem>();
        }
    }
}