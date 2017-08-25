using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.BlockTypes;
using EPiServer.Web;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "2c33732b-1298-424e-9f9d-936582da913c", GroupName = GroupNames.Other)]
    [AvailableContentTypes(Include = new[] { typeof(MemberPage) })]
    public class ManagementBoardPage : PageDataBase
    {
        [Display(Order = 30)]
        public virtual ImageBannerBlock ImageBanner { get; set; }

        [Display(Order = 40)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string BottomText { get; set; }

        [ScaffoldColumn(false)]
        public override string ContentCategory
        {
            get { return base.ContentCategory; }
            set { base.ContentCategory = value; }
        }
    }
}