using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;

namespace KtmCompany.Web.Controllers
{
    public class ManagementBoardPageController : PageControllerBase<ManagementBoardPage>
    {
        public ActionResult Index(ManagementBoardPage currentPage)
        {
            var model = new ManagementBoardPageViewModel(currentPage) {Members = getMembers(currentPage)};
            return View(model);
        }

        private IEnumerable<MemberPage> getMembers(ManagementBoardPage currentPage)
        {
            var query = SearchClient.Instance.Search<MemberPage>();
            query = query.Filter(x => x.ParentLink.Match(currentPage.ContentLink));
            query = query.FilterForVisitor().OrderBy(x => x.SortIndex);
            return query.ExcludeDeleted().GetContentResult();
        }
    }
}