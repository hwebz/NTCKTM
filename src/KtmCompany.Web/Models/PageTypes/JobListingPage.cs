using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using KtmCompany.Web.Models.BlockTypes;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "c23b66df-125b-4426-ab3f-b4dd3283cea1", GroupName = GroupNames.Popular)]
    [AvailableContentTypes(Include = new[]{typeof(JobDetailPage)})]
    public class JobListingPage : PageDataBase
    {
        [Display(Order = 20)]
        [UIHint(UIHint.LongString)]
        [CultureSpecific]
        public virtual string Abstract { get; set; }

        [Display(Order = 22)]
        [UIHint(UIHint.LongString)]
        [CultureSpecific]
        public virtual string SubHeader { get; set; }

        [Display(Order = 25)]
        [CultureSpecific]
        public virtual XhtmlString Introduction { get; set; }

        [Display(Order = 30)]
        [DefaultValue(6)]
        [Range(6, 100)]
        public virtual int PageSize { get; set; }
    }
}