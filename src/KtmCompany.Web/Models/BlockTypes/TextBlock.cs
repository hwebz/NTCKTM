using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "494dc26a-63e1-4ce3-9c80-cdfb54ee3238", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class TextBlock : BlockDataBase
    {
        [Display(Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(GroupName = SystemTabNames.Content, Order = 30)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(GroupName = SystemTabNames.Content,Order = 40)]
        [CultureSpecific]
        public virtual LinkItemCollection AttachmentLinks { get; set; }
    }
}