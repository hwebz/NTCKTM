using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Models.EditorModels
{
    public class LogoLinkItem
    {
        [Display(Name = "Title")]
        public virtual  string Title { get; set; }

        [Display(Name = "Logo Image")]
        [AllowedTypes(typeof(ImageFile))]
        [Required]
        public virtual ContentReference LogoImage { get; set; }

        [Display(Name = "Linked URL")]
        public virtual string Link { get; set; }
    }
}