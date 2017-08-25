using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;
using System.Linq;

namespace KtmCompany.Web.Controllers
{
    public class RelatedContentsBlockController : BlockController<RelatedContentsBlock>
    {
        private readonly IClient _findClient;

        public RelatedContentsBlockController(IClient client)
        {
            _findClient = client;
        }
        public override ActionResult Index(RelatedContentsBlock currentBlock)
        {
            var model = new RelatedContentsBlockViewModel { CurrentBlock = currentBlock };

            if (currentBlock.DynamicDisplay)
            {
                model.DynamicContents = SearchRelatedContents(currentBlock);
            }

            return PartialView(model);
        }

        private IEnumerable<JobDetailPage> SearchRelatedContents(RelatedContentsBlock currentContent)
        {
            var numberTake = currentContent.MaxItemsPerContent >= 0 ? currentContent.MaxItemsPerContent : 3;
            var query = SearchClient.Instance.Search<JobDetailPage>().FilterForVisitor();

            var pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<PageRouteHelper>();
            var currentPage = pageRouteHelper.Page as JobDetailPage;

            if (currentPage == null || string.IsNullOrEmpty(currentPage.JobPosition))
                return Enumerable.Empty<JobDetailPage>();

            query = query.Filter(x => x.JobPosition.Match(currentPage.JobPosition));

            query = query.Filter(x => !x.ContentLink.ID.Match(currentPage.ContentLink.ID));

            query = query.FilterByExactTypes(new []{currentPage.GetType()});

            query = query.OrderByDescending(x => x.StartPublish)
                         .Take(numberTake);

            return query.GetContentResult();
        }
    }
}