using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Geta.EPi.Extensions.EditorDescriptors;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Models.EditorModels
{
    public class TextInformationItem
    {
        [Display(Order = 100)]
        [AllowedTypes(typeof(ImageFile), typeof(SVGImageFile))]
        public virtual ContentReference Image { get; set; }

        [Display(Order = 110)]
        [Enum(typeof(TextAlign))]
        public virtual TextAlign ImageAlign { get; set; }

        [Display(Order = 120)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(Order = 130)]
        [UIHint(UIHint.LongString)]
        [CultureSpecific]
        public virtual string Abstract { get; set; }
    }
}