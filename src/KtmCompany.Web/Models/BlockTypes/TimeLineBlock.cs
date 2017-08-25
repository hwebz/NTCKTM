using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "5c986b44-01bc-4243-a7b0-a3c9e3361bfd", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class TimeLineBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 20)]
        [AllowedTypes(new []{typeof(TimeLineItemBlock)})]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea TimeLineItemsArea { get; set; }
    }
}