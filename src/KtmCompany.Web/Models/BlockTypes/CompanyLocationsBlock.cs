using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;
using EPiServer.Web;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(DisplayName = "Company Locations Block", GUID = "e5373468-6ea5-4a28-9763-5d8e243be063", Description = "", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class CompanyLocationsBlock : GenericContentBlockBase
    {
        [Display(Order = 100)]
        [CultureSpecific(false)]
        [AllowedTypes(typeof(CompanyLocationItemBlock))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea CompanyLocationItemsArea { get; set; }
    }
}