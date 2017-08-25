using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;
using Geta.EPi.Extensions;
using EPiServer.SpecializedProperties;
using EPiServer.Core.PropertySettings;
using EPiServer;
using KtmCompany.Web.Helpers;
using EPiServer.Web.PropertyControls.PropertySettings;
using KtmCompany.Web.Infrastructure;

namespace KtmCompany.Web.Controllers
{
    public class JobFilterController : Controller
    {
        public ActionResult Index()
        {
            var model = GetJobFilterViewModel();
            return PartialView(model);
        }

        public ActionResult Partial()
        {
            var model = GetJobFilterViewModel();
            return PartialView(model);
        }

        private JobFilterViewModel GetJobFilterViewModel()
        {
            var jobListingPage = ConfigurationSettingHelpers.GetJobListingPage();
            if (!jobListingPage.ContentLink.IsNullOrEmpty())
            {
                var jobdetail = DataFactory.Instance.GetDefault<JobDetailPage>(jobListingPage.ContentLink);

                //Find another syntax to avoid "string" (maybe Linq)
                var countryOptions = RegionManager.Current.LoadAllCountries().ToDictionary(x => x.CountryName, x => x.CountryKey);
                var jobPositionOptions = GetDropDownListOption(jobdetail.Property["JobPosition"] as PropertyDropDownList);

                return new JobFilterViewModel
                {
                    JobPositions = jobPositionOptions,
                    Countries = countryOptions,
                    BaseUrl = jobListingPage.GetFriendlyUrl()
                };
            }
            return new JobFilterViewModel();
        }

        private Dictionary<string,string> GetDropDownListOption(PropertyDropDownList property)
        {
            Dictionary<string, string> retval = new Dictionary<string, string>();
            if (property == null)
            {
                return retval;
            }
            var propRepository = new PropertySettingsRepository();
            PropertySettingsContainer container;
            if (propRepository.TryGetContainer(property.SettingsID, out container))
            {
                var multiSelectSettings = container.Settings.Values.FirstOrDefault(value => value.PropertySettings.GetType() == typeof(MultipleOptionsListSettings));

                if (multiSelectSettings != null)
                {
                    var settings = ((MultipleOptionsListSettings)multiSelectSettings.PropertySettings);
                    retval = settings.ListOptions;
                }
            }

            return retval;
        }
    }
}