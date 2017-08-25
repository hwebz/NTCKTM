using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "6a16317a-5a3d-46a5-874c-9424d74246b5", GroupName = GroupNames.Media)]
    public class ImageBannerBlock : BlockDataBase
    {
        [Display(Order = 10)]
        [AllowedTypes(typeof(ImageFile))]
        [Required]
        public virtual ContentReference BackgroundImage { get; set; }

        [Display(Order = 20)]
        [CultureSpecific]
        [MaxLength(80)]
        public virtual string Subline { get; set; }

        [Display(Order = 30)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string Headline { get; set; }

        [Display(Order = 40)]
        [CultureSpecific]
        public virtual LinkItemCollection AttachmentLinks { get; set; }

        [Display(Order = 50)]
        [CultureSpecific]
        public virtual string LinkMoreTitle { get; set; }
    }
}