using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.PageTypes;
using EPiServer.Find.Framework;
using KtmCompany.Web.Models.ViewModels;
using EPiServer.Find.Cms;
using EPiServer.Find;

namespace KtmCompany.Web.Controllers
{
    public class ArticlesBlockController : BlockController<ArticlesBlock>
    {
        public override ActionResult Index(ArticlesBlock currentContent)
        {
            ArticlesBlockViewModel articleBlock = new ArticlesBlockViewModel { CurrentBlock = currentContent };
            articleBlock.Articles = SearchLatestContents(currentContent);
            return PartialView(articleBlock);
        }

        private IEnumerable<ArticlePage> SearchLatestContents(ArticlesBlock currentContent)
        {
            var numberTake = currentContent.NumberOfArticles > 0 ? currentContent.NumberOfArticles : 6;
            var query = SearchClient.Instance.Search<ArticlePage>().FilterForVisitor();
            query = query.OrderByDescending(x => x.StartPublish).Take(numberTake);

            return query.GetContentResult();
        }
    }
}
