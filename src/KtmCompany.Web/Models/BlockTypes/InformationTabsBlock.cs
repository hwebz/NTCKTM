using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "ae04b39c-c672-4cfe-8685-ff87f21b15ee", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class InformationTabsBlock : GenericContentBlockBase
    {        
        [Display(Order = 100)]
        [AllowedTypes(typeof(InformationTabItemBlock), typeof(TextBlock), typeof(DocumentListingBlock))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea TabItems { get; set; }

        [Display(Order = 110)]
        [CultureSpecific]
        public virtual string AllItemsTabTitle { get; set; }
    }
}