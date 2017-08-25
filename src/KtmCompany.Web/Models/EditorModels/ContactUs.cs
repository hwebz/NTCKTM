using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace KtmCompany.Web.Models.EditorModels
{
    public class ContactUs
    {
        [Display(Order = 10)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string Abstract { get; set; }

        [Display(Order = 30)]
        [CultureSpecific(false)]
        public virtual string BranchName { get; set; }

        [Display(Order = 40)]
        [CultureSpecific(false)]
        public virtual string AddressLine1 { get; set; }

        [Display(Order = 50)]
        [CultureSpecific(false)]
        public virtual string AddressLine2 { get; set; }

        [Display(Order = 60)]
        [CultureSpecific(false)]
        public virtual string PhoneNumber { get; set; }

        [Display(Order = 70)]
        [CultureSpecific(false)]
        public virtual string Email { get; set; }
    }
}