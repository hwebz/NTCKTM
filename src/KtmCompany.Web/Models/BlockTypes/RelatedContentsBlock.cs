using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "c54a9f1f-d371-4419-abbb-53ef0d6d418f", AvailableInEditMode = false)]
    public class RelatedContentsBlock : BlockDataBase
    {
        [Display(Order = 10)]
        [CultureSpecific(false)]
        [AllowedTypes(typeof(EditorialPageBase))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea ManualItems { get; set; }

        [Display(Order = 20)]
        [DefaultValue(true)]
        public virtual bool DynamicDisplay { get; set; }

        [Display(Order = 30)]
        [CultureSpecific(false)]
        [DefaultValue(3)]
        [Range(0, 9)]
        public virtual int MaxItemsPerContent { get; set; }        
    }
}