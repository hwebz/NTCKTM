using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer.Core;
using KtmCompany.Web.Models.BlockTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class CompanyLocationsBlockViewModel
    {
        public CompanyLocationsBlock CurrentBlock { get; set; }

        public List<SelectListItem> RegionSelections { get; set; }

        public List<SelectListItem> CountrySelections { get; set; }

        public ContentReference LeftBackgroundImage { get; set; }

        public CompanyLocationsBlockViewModel(CompanyLocationsBlock currentBlock)
        {
            CurrentBlock = currentBlock;
            LeftBackgroundImage = currentBlock.LeftContent.LeftBackgroundImage;
        }
    }
}