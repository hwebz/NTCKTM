using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(DateTime?), UIHint = SiteUIHint.DateOnly)]
    public class DateOnlyEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            ClientEditingClass = "dijit.form.DateTextBox";
            base.ModifyMetadata(metadata, attributes);
        }
    }
}