using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "6e01a88c-ce9f-4076-b452-5ffc7771d768", GroupName = GroupNames.Media)]
    public class StageSliderBlock : BlockDataBase
    {
        [Display(Order = 50)]
        [AllowedTypes(AllowedTypes = new[] { typeof(ArticlePage), typeof(BrandPage), typeof(JobDetailPage) })]        
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea SlidingItems { get; set; }

        [Display(Order = 60)]
        [CultureSpecific(false)]
        [DefaultValue(true)]
        public virtual bool IsAutoSliding { get; set; }

        [Display(Order = 70)]
        [CultureSpecific(false)]
        [Range(1000, 10000)]
        [DefaultValue(5000)]
        public virtual int SlidingInterval { get; set; }
    }
}