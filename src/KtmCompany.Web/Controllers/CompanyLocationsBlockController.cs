using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Framework.Localization;
using EPiServer.Framework.Web.Resources;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.ViewModels;

namespace KtmCompany.Web.Controllers
{
    public class CompanyLocationsBlockController : BlockController<CompanyLocationsBlock>
    {
        public override ActionResult Index(CompanyLocationsBlock currentBlock)
        {                        
            var instance = ServiceLocator.Current.GetInstance<IRequiredClientResourceList>();
            instance.RequireScript("http://maps.googleapis.com/maps/api/js", "GmapApiJS", null).AtHeader();
            instance.RequireScript("/Frontend/KTM/js/map.min.js", "GmapInitJS", null).AtFooter();
            instance.RequireScript("/Frontend/KTM/js/company-location.js", "CompanyLocationJS", new List<string> { "GmapApiJS", "GmapInitJS" }).AtFooter();

            var viewModel = new CompanyLocationsBlockViewModel(currentBlock);

            List<SelectListItem> countrySelections;

            viewModel.RegionSelections = GetRegionSelections(out countrySelections);
            viewModel.CountrySelections = countrySelections;

            return PartialView(viewModel);
        }

        public ActionResult FindLocation(string region, string country)
        {
            var query = SearchClient.Instance.Search<CompanyLocationItemBlock>();
            
            //Seaching
            if (!string.IsNullOrEmpty(region))
            {
                query = query.Filter(x => x.Location.Region.MatchCaseInsensitive(region));
            }

            if (!string.IsNullOrEmpty(country))
            {
                query = query.Filter(x => x.Location.Country.MatchCaseInsensitive(country));
            }

            return Json(query.Take(1000).GetContentResult().Items.Select(x => new CompanyLocationItemViewModel(x)), JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetRegionSelections(out List<SelectListItem> countrySelections)
        {
            var regionSelections = new List<SelectListItem>();
            countrySelections = new List<SelectListItem>();            

            var regions = RegionManager.Current.LoadAllRegions();

            var countries = RegionManager.Current.LoadAllCountries();

            regionSelections.Add(new SelectListItem() { Text = LocalizationService.Current.GetString("/views/companylocationsblock/continent", "Continent"), Value = string.Empty });
            countrySelections.Add(new SelectListItem() { Text = LocalizationService.Current.GetString("/views/companylocationsblock/country", "Country"), Value = string.Empty });

            if (regions != null && regions.Any())
            {
                regionSelections.AddRange(regions.Select(region => new SelectListItem() {Text = region.RegionName, Value = region.RegionId}));
            }

            if (countries != null && countries.Any())
            {
                countrySelections.AddRange(countries.Select(country => new SelectListItem() { Text = country.CountryName, Value = country.CountryKey }));
            }                        

            return regionSelections;
        }
    }
}