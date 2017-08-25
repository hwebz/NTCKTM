using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using Foundation.Core.Models;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;
using Geta.EPi.Extensions;
using KtmCompany.Web.Helpers;
using StartPage = KtmCompany.Web.Models.PageTypes.StartPage;
using System.Drawing;

namespace KtmCompany.Web.Controllers
{
    public class GlobalController : Controller
    {
        private StartPage _startPage;
        public StartPage StartPage => _startPage ?? (_startPage = ContentReference.StartPage.Get<StartPage>());

        private readonly IContentLoader _contentLoader;

        public GlobalController(IContentLoader contentLoader)
        {
            if (contentLoader == null)
            {
                throw new ArgumentNullException("GlobalController.contentLoader");
            }
            _contentLoader = contentLoader;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterViewModel
            {
                CompanyName = StartPage.Footer.CompanyName,
                Address1 = StartPage.Footer.Address1,
                Address2 = StartPage.Footer.Address2,
                Country = StartPage.Footer.Country,
                Phone = StartPage.Footer.Phone,
                Fax = StartPage.Footer.Fax,
                CopyrightInfo = StartPage.Footer.CopyrightInfo,
                FooterColumn1Links = StartPage.Footer.FooterColumn1Links,
                FooterColumn2Links = StartPage.Footer.FooterColumn2Links,
                FooterColumn3Links = StartPage.Footer.FooterColumn3Links,
                FooterBottomLinks = StartPage.Footer.FooterBottomLinks
            };

            return PartialView("Footer", model);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var pageRouteHelper = ServiceLocator.Current.GetInstance<PageRouteHelper>();
            var currentPage = pageRouteHelper.Page as PageDataBase;
            var languages = ServiceLocator.Current.GetInstance<ILanguageBranchRepository>().ListEnabled().
                Select(langContext => new CultureInfo(langContext.LanguageID)).Select(culture => new SelectListItem
            {
                Value = culture.Name, Text = culture.NativeName, Selected = currentPage != null && string.Equals(currentPage.Language.Name, culture.Name, StringComparison.CurrentCultureIgnoreCase)
            }).ToList();
            var model = new HeaderViewModel
            {
                LogoImage = StartPage.Header.LogoImage,
                BrandLogoLinks = StartPage.Header.BrandLogoLinks,
                MenuItems = GetMenuItems(currentPage),
                SupportedLanguages = languages,
                CurrentPage = currentPage
            };

            return PartialView("Header", model);
        }

        [ChildActionOnly]
        public ActionResult MetaData()
        {
            var pageRouteHelper = ServiceLocator.Current.GetInstance<PageRouteHelper>();
            var currentPage = pageRouteHelper.Page as PageDataBase;

            if (currentPage == null)
            {
                return null;
            }

            var model = new MetaDataViewModel { Title = currentPage.MetaTitle, Description = currentPage.MetaDescription };

            return PartialView("MetaData", model);
        }

        [ChildActionOnly]
        public ActionResult GeneralSocialSharing()
        {
            if (ConfigurationSettingHelpers.GetGeneralSocialShareBlock() == null)
                return null;

            return PartialView("SocialShareBlock", ConfigurationSettingHelpers.GetGeneralSocialShareBlock());
        }

        [ChildActionOnly]
        public ActionResult GeneralSocialSharingMobile()
        {
            if (ConfigurationSettingHelpers.GetGeneralSocialShareMobileBlock() == null)
                return null;

            return PartialView("SocialShareBlock", ConfigurationSettingHelpers.GetGeneralSocialShareMobileBlock());
        }

        [ChildActionOnly]
        public ActionResult GeneralSocialAccounts()
        {
            if (ConfigurationSettingHelpers.GetGeneralSocialAccountBlock() == null)
                return null;

            return PartialView("SocialAccountBlock", ConfigurationSettingHelpers.GetGeneralSocialAccountBlock());
        }

        private IEnumerable<MenuItem> GetMenuItems(PageDataBase currentPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var currentContentLink = new ContentReference();
            var parentLink = new ContentReference();
            if (currentPage != null)
            {
                currentContentLink = currentPage.ContentLink;
                parentLink = contentLoader.GetAncestors(currentContentLink).First().ContentLink;
            }
            var menuItems = new List<MenuItem>
            {
                new MenuItem(ContentReference.StartPage.GetPage())
                {
                    Selected = currentPage != null && (ContentReference.StartPage.CompareToIgnoreWorkID(currentContentLink))
                }
            };
            menuItems.AddRange(GetChildrenMenuItem(contentLoader, ContentReference.StartPage)
                .Select(x => new MenuItem(x)
                {
                    Selected = currentPage != null && (x.ContentLink.CompareToIgnoreWorkID(currentContentLink) || x.ContentLink.CompareToIgnoreWorkID(parentLink)),
                    Children = GetChildrenMenuItem(contentLoader, x.ContentLink).Select(y => new MenuItem(y) {Selected = currentPage != null && y.ContentLink.CompareToIgnoreWorkID(currentContentLink) })
                }));
            return menuItems;
        }

        private IEnumerable<PageData> GetChildrenMenuItem(IContentLoader contentLoader,ContentReference content)
        {
            return contentLoader.GetChildren<PageData>(content).FilterForDisplay(false, true).Where(x => !(x is IHaveNoTemplate));
        } 
    }


    public class MenuItem
    {
        public MenuItem(PageData page)
        {
            Page = page;
        }
        public PageData Page { get; set; }
        public bool Selected { get; set; }
        public IEnumerable<MenuItem> Children { get; set; }
    }
}