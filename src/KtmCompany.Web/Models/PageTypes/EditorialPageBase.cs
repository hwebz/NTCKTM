using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Foundation.Core.Infrastructure.TinyMce;
using KtmCompany.Web.Models.MediaTypes;
using Geta.EPi.Extensions;
using EPiServer.DataAbstraction;
using KtmCompany.Web.Infrastructure.Attributes;
using KtmCompany.Web.Infrastructure;

namespace KtmCompany.Web.Models.PageTypes
{
    public abstract class EditorialPageBase : PageDataBase
    {
        [Display(Order = 30)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string SubHeader { get; set; }

        [Display(Order = 40)]
        [UIHint(UIHint.Image)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference MainImage { get; set; }

        //[Display(Order = 50)]
        //[CultureSpecific]
        //public virtual Url ThumbnailImageUrl
        //{
        //    get
        //    {
        //        return this.GetPropertyValue(p => p.ThumbnailImageUrl) ?? MainImage.GetFriendlyUrl();
        //    }
        //    set
        //    {
        //        this.SetPropertyValue(p => p.ThumbnailImageUrl, value);
        //    }
        //}

        [Display(Order = 60)]
        [CultureSpecific]
        [PropertySettings(typeof(GlobalTinyMceSettings))]
        public virtual XhtmlString MainBody { get; set; }
    }
}