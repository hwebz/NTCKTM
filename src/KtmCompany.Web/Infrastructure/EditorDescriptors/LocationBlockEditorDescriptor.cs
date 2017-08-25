using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using KtmCompany.Web.Models.BlockTypes.Common;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(LocationBlock))]
    public class LocationBlockEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);
            metadata.Properties.Cast<ExtendedMetadata>().First().GroupSettings.ClientLayoutClass = "app.editors.LocationBlockContainer";
        }
    }
}