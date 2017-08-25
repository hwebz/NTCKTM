using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(DisplayName = "Testimonial Item Block", GUID = "c92b981e-13be-470e-b147-c3a5b307921d", GroupName = GroupNames.Popular)]
    public class TestimonialItemBlock : GenericContentBlockBase
    {
        [Required]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference Image { get; set; }
    }
}