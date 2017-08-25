using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.BlockTypes.Common;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "de547149-f342-44cf-8aec-ac2334a03cdf", Order = 10, AvailableInEditMode = false)]
    [AvailableContentTypes(Include = new []{typeof(GenericContentPage), typeof(JobListingPage),
        typeof(ArticleListingPage), typeof(BrandPage), typeof(ContactUsPage), typeof(SearchPage), typeof(ManagementBoardPage)})]
    public class StartPage : PageDataBase
    {
        [Display(Order = 100)]
        [AllowedTypes(new []{typeof(GenericContentBlock), typeof(MouseoverBlock), typeof(StatementBlock),
            typeof(PartnersBlock), typeof(TestimonialBlock), typeof(TestimonialItemBlock),
            typeof(StatementBlock), typeof(ArticlesBlock), typeof(BackgroundVideoBlock)})]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea Body { get; set; }

        [Display(Order = 200, GroupName = GroupNames.Header)]
        public virtual HeaderBlock Header { get; set; }

        [Display(Order = 300, GroupName = GroupNames.Footer)]
        public virtual FooterBlock Footer { get; set; }

        [Display(Order = 400, GroupName = GroupNames.SiteSettings)]
        public virtual SiteSettingsBlock SiteSettings { get; set; }

        [ScaffoldColumn(false)]
        public override string ContentCategory
        {
            get { return base.ContentCategory; }
            set { base.ContentCategory = value; }
        }

        [ScaffoldColumn(false)]
        public override string MainIntro
        {
            get { return base.MainIntro; }
            set { base.MainIntro = value; }
        }
    }
}