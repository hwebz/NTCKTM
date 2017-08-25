using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    /// <summary>
    /// Registers an editor to select a category for a string property using a dropdown
    /// </summary>
    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = SiteUIHint.CategorySelectOne)]
    public class CategorySelectOneEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(CategorySelectionFactory);

            ClientEditingClass = "epi.cms.contentediting.editors.SelectionEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}