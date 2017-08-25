using EPiServer.Core;
using EPiServer.Forms.Implementation.Elements;
using Geta.EPi.Extensions;
using KtmCompany.Web.Models;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.BlockTypes.EPiServerForms;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Helpers
{
    public class ConfigurationSettingHelpers
    {
        public static ContentReference GetArticleListingPageUrl(string categoryPath = null)
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.ArticleListingPage;
        }

        public static SocialShareBlock GetGeneralSocialShareBlock()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.SocialSharing;
        }

        public static SocialShareBlock GetGeneralSocialShareMobileBlock()
        {
            var generalSocialShareMobileBlock = ContentReference.StartPage.Get<StartPage>().SiteSettings.SocialSharingMobile;
            generalSocialShareMobileBlock.ForMobile = true;
            return generalSocialShareMobileBlock;
        }

        public static SocialAccountBlock GetGeneralSocialAccountBlock()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.SocialAccounts;
        }

        public static ContentReference GetSearchPage()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.SearchPage;
        }

        public static JobListingPage GetJobListingPage()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.JobListingPage?.Get<JobListingPage>() ?? new JobListingPage();
        }

        public static FormContainerBlock GetApplicationForm()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.ApplicationForm?.Get<FormContainerBlock>();
        }

        public static XhtmlString GetMessageNoResults()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.MessageNoResults;
        }

        public static ContentReference GetDefaultLeftBackgroundImage()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.DefaultLeftBackgroundImage;
        }

        public static string GetGoogleAnalyticsId()
        {
            return ContentReference.StartPage.Get<StartPage>().SiteSettings.GoogleAnalyticsId;
        }
    }
}