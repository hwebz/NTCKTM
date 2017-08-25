using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Infrastructure.Attributes;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "b47c8e6f-24a2-4ed7-b2eb-f1c0cf00d698", GroupName = GroupNames.Media)]
    public class MouseoverItemBlock : BlockData
    {
        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 10)]
        [CategorySelectOne(CategoryConstants.AllCategory)]
        [UIHint(SiteUIHint.CategorySelectOne)]
        [Required]
        public virtual string ContentCategory { get; set; }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 20)]
        [AllowedTypes(new[] { typeof(ImageFile) })]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea ImagesArea { get; set; }

        [CultureSpecific]
        [Display(Order = 30)]
        public virtual Url CallToActionLink { get; set; }

        [CultureSpecific]
        [Display(Order = 40)]
        public virtual string CallToActionTitle { get; set; }
    }
}