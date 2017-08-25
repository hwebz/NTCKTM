using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace KtmCompany.Web.Models.BlockTypes.Common
{
    [ContentType(GUID = "70bbe639-6a67-46e1-84c6-46342b133b68", AvailableInEditMode = false)]
    public class FooterBlock : BlockData
    {
        [Display(Order = 10)]
        [CultureSpecific(false)]
        public virtual string CompanyName { get; set; }

        [Display(Order = 20)]
        [CultureSpecific(true)]
        public virtual string Address1 { get; set; }

        [Display(Order = 30)]
        [CultureSpecific(true)]
        public virtual string Address2 { get; set; }

        [Display(Order = 40)]
        [CultureSpecific(true)]
        public virtual string Country { get; set; }

        [Display(Order = 50)]
        [CultureSpecific(true)]
        public virtual string Phone { get; set; }

        [Display(Order = 60)]
        [CultureSpecific(true)]
        public virtual string Fax { get; set; }

        [Display(Order = 70)]
        [CultureSpecific(true)]
        public virtual string CopyrightInfo { get; set; }

        [Display(Order = 90)]
        [CultureSpecific(true)]
        public virtual LinkItemCollection FooterColumn1Links { get; set; }

        [Display(Order = 100)]
        [CultureSpecific(true)]
        public virtual LinkItemCollection FooterColumn2Links { get; set; }

        [Display(Order = 110)]
        [CultureSpecific(true)]
        public virtual LinkItemCollection FooterColumn3Links { get; set; }

        [Display(Order = 120)]
        [CultureSpecific(true)]
        public virtual LinkItemCollection FooterBottomLinks { get; set; }
    }
}