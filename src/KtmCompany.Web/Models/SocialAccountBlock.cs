using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.EditorModels;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models
{
    [ContentType(DisplayName = "Social Account Block", GUID = "d6105f67-e7d0-4f4e-aded-c00c12fafe70", GroupName = GroupNames.SocialMedia)]
    public class SocialAccountBlock : BlockDataBase
    {
        [Display(Order = 10)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<SocialLinkItem>))]
        [CultureSpecific]
        public virtual IList<SocialLinkItem> SocialLinkItems { get; set; }
    }
}