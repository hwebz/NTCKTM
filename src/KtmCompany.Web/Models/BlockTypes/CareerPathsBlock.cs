using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;
using EPiServer.Web;
using KtmCompany.Web.Models.EditorModels;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "7a25a50f-3c47-4ec4-a2c1-a7da2d26ccac", GroupName = GroupNames.Other)]
    public class CareerPathsBlock : GenericContentBlockBase
    {
        [CultureSpecific]
        [Display(Order = 100)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationItem>))]
        public virtual IList<TextInformationItem> CareerPathItems { get; set; }
    }
}