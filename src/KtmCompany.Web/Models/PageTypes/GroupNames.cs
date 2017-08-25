using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace KtmCompany.Web.Models.PageTypes
{
    [GroupDefinitions]
    public static class GroupNames
    {
        [Display(GroupName = "Popular", Order = 10)]
        public const string Popular = "Popular";

        [Display(GroupName = "Data", Order = 15)]
        public const string Data = "Data";

        [Display(GroupName = "Media", Order = 20)]
        public const string Media = "Media";

        [Display(GroupName = "SEO", Order = 30)]
        public const string Seo = "SEO";

        [Display(GroupName = "Header", Order = 40)]
        public const string Header = "Header";

        [Display(GroupName = "Footer", Order = 50)]
        public const string Footer = "Footer";

        [Display(GroupName = "Advanced", Order = 70)]
        public const string Advanced = "Advanced";

        [Display(GroupName = "Site settings", Order = 100)]
        public const string SiteSettings = "Site settings";

        [Display(GroupName = "Custom Form Elements", Order = 120)]
        public const string CustomFormElements = "Custom Form Elements";

        [Display(GroupName = "Social Media", Order = 130)]
        public const string SocialMedia = "Social Media";

        [Display(GroupName = "Other", Order = 200)]
        public const string Other = "Other";
    }
}
