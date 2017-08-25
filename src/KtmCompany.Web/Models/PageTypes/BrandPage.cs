using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "a555eb8b-d2a5-492c-8c71-ee463db83e2d", GroupName = GroupNames.Popular)]
    [AvailableContentTypes(Include = new []{typeof(BrandPage)})]
    public class BrandPage : EditorialPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 25)]
        [AllowedTypes(typeof(BackgroundVideoBlock), typeof(ImageBannerBlock))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea TopBodyArea { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea MainBodyArea { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 210)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference Favicon { get; set; }
    }
}