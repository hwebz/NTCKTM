using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.PageTypes;
using EPiServer.Core;
using KtmCompany.Web.Models.BlockTypes.Common;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "aba4f64f-9367-4930-944f-e48df6531f8b", GroupName = GroupNames.Popular)]
    public class TestimonialBlock : GenericContentBlockBase
    {
        [Display(GroupName = SystemTabNames.Content,
           Order = 10)]
        public override LeftGenericContentBlock LeftContent { get; set; }

        [Display(Order = 100)]
        [AllowedTypes(typeof(ImageFile), typeof(TestimonialItemBlock))]        
        public virtual ContentArea Images { get; set; }

        [Display(Order = 120)]
        [DefaultValue(true)]
        public virtual bool IsAutoSliding { get; set; }

        [Display(Order = 130)]
        [CultureSpecific(false)]
        [Range(1000, 10000)]
        [DefaultValue(5000)]
        public virtual int SlidingInterval { get; set; }
    }
}