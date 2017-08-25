using System.Web.Mvc;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Web.Mvc;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;
using EPiServer;
using System;
using EPiServer.Core;

namespace KtmCompany.Web.Controllers
{
    public class JobDetailPageController : PageController<JobDetailPage>
    {
        private readonly IContentLoader _contentLoader;

        public JobDetailPageController(IContentLoader contentLoader)
        {
            if (contentLoader == null)
            {
                throw new ArgumentNullException("JobDetailPageController.contentLoader");
            }
            _contentLoader = contentLoader;
        }
        public ActionResult Index(JobDetailPage currentPage)
        {
            return View(currentPage);
        }

        public ActionResult Partial(string pageId)
        {
            var jobDetailPage = _contentLoader.Get<JobDetailPage>(ContentReference.Parse(pageId));
            return PartialView("JobDetail", jobDetailPage);
        }
    }
}