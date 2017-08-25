using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.EditorModels;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "dc678b01-4d47-49a3-b681-9a434e5526c7", GroupName = GroupNames.Media)]
    public class MediaListingBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(Order = 100)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<MediaItem>))]
        public virtual IList<MediaItem> MediaItems { get; set; }
    }
}