using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;

namespace KtmCompany.Web.Models.EditorModels
{
    public class SocialLinkItem
    {                
        [Required]
        [Display(Name = "Icon")]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Icon { get; set; }

        [Required]
        [Display(Name = "Social Url")]
        public virtual string Link { get; set; }
    }
}