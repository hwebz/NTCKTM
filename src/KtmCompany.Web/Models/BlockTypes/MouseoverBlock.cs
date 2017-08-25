using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "73bd04ba-88ed-4c4b-b02a-1b8b7061b531", GroupName = GroupNames.Media)]
    public class MouseoverBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(Order = 10)]
        [AllowedTypes(new[] { typeof(MouseoverItemBlock) })]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea MouseoverArea { get; set; }

        [CultureSpecific]
        [Display(Order = 20)]
        [DefaultValue(200)]
        [Range(200, 2000)]
        public virtual int LoopTime { get; set; }
    }
}