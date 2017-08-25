using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Infrastructure.EditorDescriptors;

namespace KtmCompany.Web.Models.BlockTypes.Common
{
    [ContentType(DisplayName = "Location Block", GUID = "cc6fbc54-4e65-466a-9e2f-56170d3d2203", AvailableInEditMode = false)]
    public class LocationBlock : BlockData
    {
        [CultureSpecific(false)]
        [Display(
            Name = "Region",            
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [SelectOne(SelectionFactoryType = typeof(RegionSelectionFactory))]
        public virtual string Region { get; set; }

        [CultureSpecific(false)]
        [Display(
            Name = "Country",
            GroupName = SystemTabNames.Content,
            Order = 20)]        
        [ClientEditor(ClientEditingClass = "app.editors.FilterableSelectionEditor", SelectionFactoryType = typeof(CountrySelectionFactory))]
        public virtual string Country { get; set; }
    }
}