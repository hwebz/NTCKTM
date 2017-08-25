using System.Web.Mvc;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Web.Mvc;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;
using System.Web;

namespace KtmCompany.Web.Controllers
{
    public class JobListingPageController : PageController<JobListingPage>
    {
        public ActionResult Index(JobListingPage currentPage)
        {
            return View(currentPage);
        }

        public ActionResult LoadJobs(int pageSize, int pageIndex, string jobPosition, string country)
        {
            var jobListingPage = SearchJobs(pageIndex, pageSize, HttpUtility.UrlDecode(jobPosition), HttpUtility.UrlDecode(country));
            return PartialView("JobItemList", jobListingPage);
        }

        private JobListingPageViewModel SearchJobs(int pageIndex, int pageSize, string filteredPosition = null, string filteredCountry = null)
        {
            var jobListingPage = new JobListingPageViewModel();
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 6;
            }

            var query = SearchClient.Instance.Search<JobDetailPage>().FilterForVisitor();

            query = query.OrderByDescending(x => x.StartPublish).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            if (!string.IsNullOrEmpty(filteredPosition))
            {
                query = query.Filter(x => x.JobPosition.MatchCaseInsensitive(filteredPosition));
            }

            if (!string.IsNullOrEmpty(filteredCountry))
            {
                query = query.Filter(x => x.Country.MatchCaseInsensitive(filteredCountry));
            }

            var result = query.GetContentResult();
            jobListingPage.JobDetailPages = result;
            jobListingPage.IsMoreItemsExist = result.TotalMatching > pageSize * pageIndex;

            return jobListingPage;
        }
    }
}