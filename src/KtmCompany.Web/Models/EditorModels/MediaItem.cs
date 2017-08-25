using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Models.EditorModels
{
    public class MediaItem
    {
        [Display(Order = 100)]
        [AllowedTypes(typeof(ImageFile), typeof(VideoFile))]
        public virtual ContentReference MediaFile { get; set; }

        [Display(Order = 110)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference Thumbnail { get; set; }

        [Display(Order = 120)]
        [UIHint(UIHint.LongString)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(Order = 130)]
        [UIHint(UIHint.LongString)]
        [CultureSpecific]
        public virtual string Abstract { get; set; }
    }
}