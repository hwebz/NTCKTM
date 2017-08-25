using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace KtmCompany.Web.Models.EditorModels
{
    public class HeadLine
    {
        [Display(Name = "Text")]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string Text { get; set; }
    }
}