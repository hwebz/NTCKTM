using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "ae42c855-2d79-4f7d-bf76-27b22cc15f9c", GroupName = GroupNames.SocialMedia)]
    public class SocialShareBlock : BlockDataBase
    {
        [Display(Order = 20)]
        [CultureSpecific(false)]
        public virtual string PublisherId { get; set; }

        [Ignore]
        public bool ForMobile { get; set; }
    }
}