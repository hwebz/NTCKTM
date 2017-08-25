using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = SiteUIHint.GeoPointSelector)]
    public class GeoPointSelectorEditorDescriptor:EditorDescriptor
    {        
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(CategorySelectionFactory);

            ClientEditingClass = "tedgustaf.googlemaps.Editor";

            base.ModifyMetadata(metadata, attributes);
        }
    }    
}