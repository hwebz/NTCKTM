using System.Web.Mvc;
using EPiServer.Framework.Localization;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Foundation.Core.Infrastructure.UrlKeeper;
using KtmCompany.Web.Helpers;
using KtmCompany.Web.Models.ViewModels;

namespace KtmCompany.Web.Controllers
{
    public class NotFoundController : Controller
    {
        private readonly IUrlKeeperRepository _urlKeeperRepository;
        private readonly UrlResolver _urlResolver;

        public NotFoundController(IUrlKeeperRepository urlKeeperRepository, UrlResolver urlResolver)
        {
            this._urlKeeperRepository = urlKeeperRepository;
            this._urlResolver = urlResolver;
        }

        public ActionResult Index()
        {
            var item = this._urlKeeperRepository.GetByOldPath(Request.RawUrl);

            if (item != null)
            {
                try
                {
                    var redirectUrl = this._urlResolver.GetUrl(PermanentLinkUtility.FindContentReference(item.ContentGuid));

                    if (redirectUrl != null)
                    {
                        Response.RedirectPermanent(redirectUrl, true);
                    }
                }
                catch
                {
                }
            }

            var pageNotFoundTitle = CommonHelpers.TranslateFallback("/views/pagenotfound/title", "Sorry");
            var pageNotFoundText = CommonHelpers.TranslateFallback("/views/pagenotfound/text", "404\nThat page\ndoesn't seem\nto exist");
            var model = new NotFoundViewModel
            {
                Title = pageNotFoundTitle,
                Text = pageNotFoundText
            };

            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 404;

            return View(model);
        }
    }
}