using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.EditorModels;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(DisplayName = "Partners Block", GUID = "b8956f8c-4ec4-4db1-aa9d-930d53e5d532", GroupName = GroupNames.Media)]
    public class PartnersBlock : BlockDataBase
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [CultureSpecific(false)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<LogoLinkItem>))]
        public virtual IList<LogoLinkItem> Partners { get; set; }
    }
}