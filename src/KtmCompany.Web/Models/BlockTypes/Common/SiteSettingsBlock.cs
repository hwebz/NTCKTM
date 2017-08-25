using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.EditorModels;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.BlockTypes.EPiServerForms;
using EPiServer.Forms.Implementation.Elements;

namespace KtmCompany.Web.Models.BlockTypes.Common
{
    [ContentType(GUID = "ee1de037-0781-4619-b524-9de997eb9923", AvailableInEditMode = false)]
    public class SiteSettingsBlock : BlockData
    {
        [Display(Order = 10)]
        public virtual SocialShareBlock SocialSharing { get; set; }

        [Display(Order = 12)]
        public virtual SocialShareBlock SocialSharingMobile { get; set; }

        [Display(Order = 15)]
        public virtual SocialAccountBlock SocialAccounts { get; set; }

        [Display(Order = 20)]
        [AllowedTypes(new[] { typeof(ImageFile) })]
        public virtual ContentReference DefaultImage { get; set; }

        [Display(Order = 30)]
        [Range(200, 5000)]
        [DefaultValue(500)]
        public virtual int FadeInInterval { get; set; }

        [Display(Order = 40)]
        [Range(200, 5000)]
        [DefaultValue(500)]
        public virtual int FadeOutInterval { get; set; }

        [Display(Order = 500)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual ContentReference SearchPage { get; set; }

        [Display(Order = 510)]
        [AllowedTypes(typeof(ArticleListingPage))]
        public virtual ContentReference ArticleListingPage { get; set; }

        [Display(Order = 520)]
        [AllowedTypes(typeof(JobListingPage))]
        public virtual ContentReference JobListingPage { get; set; }

        [Display(Order = 530)]
        [AllowedTypes(typeof(FormContainerBlock))]
        public virtual ContentReference ApplicationForm { get; set; }

        [Display(Order = 540)]
        [CultureSpecific]
        public virtual XhtmlString MessageNoResults { get; set; }

        [Display(Order = 550)]
        [CultureSpecific]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference DefaultLeftBackgroundImage { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 1000)]
        [CultureSpecific(false)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<CategoryColorItem>))]
        public virtual IList<CategoryColorItem> CategoryColors { get; set; }

        [Display(Order = 550)]
        public virtual string GoogleAnalyticsId { get; set; }
    }
}