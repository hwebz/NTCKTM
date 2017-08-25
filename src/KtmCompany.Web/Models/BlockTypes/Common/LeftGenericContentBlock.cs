using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Geta.EPi.Extensions;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Models.BlockTypes.Common
{
    [ContentType(DisplayName = "Left Generic Content Block", GUID = "914b8472-6f55-46cd-9c2e-38e8db3f38b7", Description = "", AvailableInEditMode = false)]
    public class LeftGenericContentBlock : BlockDataBase
    {
        [Display(Order = 10)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string Heading { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 11)]
        [CultureSpecific]
        public virtual LinkItemCollection AttachmentLinks { get; set; }

        [CultureSpecific(true)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 12)]        
        public virtual XhtmlString Abstract { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 14)]
        [CultureSpecific(true)]
        public virtual string CallToActionTitle { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 16)]
        [CultureSpecific(true)]
        public virtual Url CallToAction { get; set; }

        [Display(Order = 18)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference LeftBackgroundImage { get; set; }

        [Display(Order = 20)]
        public virtual bool ShowSocialAccountBlock { get; set; }
    }
}