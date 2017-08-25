using System.Collections.Generic;
using EPiServer.SpecializedProperties;
using KtmCompany.Web.Models.EditorModels;
using System.Web.Mvc;
using EPiServer.Core;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class HeaderViewModel
    {
        public ContentReference LogoImage { get; set; }

        public IList<LogoLinkItem> BrandLogoLinks { get; set; }

        public IEnumerable<Controllers.MenuItem> MenuItems { get; set; } 

        public IEnumerable<SelectListItem> SupportedLanguages { get; set; }

        public PageDataBase CurrentPage { get; set; }
    }
}