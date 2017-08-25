using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Web;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "1312e0ed-745e-4c3d-ab98-837e96e14ed0", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class TimeLineItemBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 10)]
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "/contenttypes/TimeLineItemBlock/properties/Year/ErrorMessage")]
        public virtual string Year { get; set; }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 20)]
        [UIHint(UIHint.Textarea)]
        [StringLength(100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 30)]
        [UIHint(UIHint.Textarea)]
        public virtual string Abstract { get; set; }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 40)]
        public virtual XhtmlString MainBody { get; set; }
    }
}