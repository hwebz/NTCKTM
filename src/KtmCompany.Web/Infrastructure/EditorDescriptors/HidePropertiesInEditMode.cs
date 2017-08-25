using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.SpecializedProperties;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.BlockTypes.Common;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    #region Hide uneccessary properties in CompanyLocationBLock and InformationTabsBlock

    [EditorDescriptorRegistration(TargetType = typeof(Url))]
    public class HideCallToActionInCompanyLocationBlock : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (metadata.Parent != null)
            {
                var containerType = metadata.Parent.ContainerType;
                if (containerType != null && metadata.PropertyName == "CallToAction" && containerType == typeof(CompanyLocationsBlock))
                {
                    metadata.ShowForEdit = false;
                }
            }
            base.ModifyMetadata(metadata, attributes);
        }
    }

    [EditorDescriptorRegistration(TargetType = typeof(bool?))]
    public class HideShowSocialAccountBlockInCompanyLocationBlock : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (metadata.Parent != null)
            {
                var containerType = metadata.Parent.ContainerType;
                if (containerType != null && metadata.PropertyName == "ShowSocialAccountBlock" && containerType == typeof(CompanyLocationsBlock))
                {
                    metadata.ShowForEdit = false;
                }
            }
            base.ModifyMetadata(metadata, attributes);
        }
    }

    [EditorDescriptorRegistration(TargetType = typeof(LinkItemCollection))]
    public class HideAttachmentLinksInCompanyLocationBlock : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (metadata.Parent != null)
            {
                var containerType = metadata.Parent.ContainerType;
                if (containerType != null && metadata.PropertyName == "AttachmentLinks" && 
                    (containerType == typeof(CompanyLocationsBlock) || containerType == typeof(InformationTabsBlock)))
                {
                    metadata.ShowForEdit = false;
                }
            }
            base.ModifyMetadata(metadata, attributes);
        }
    }
    [EditorDescriptorRegistration(TargetType = typeof(string))]
    public class HideCallToActionTitleInCompanyLocationBlock : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (metadata.Parent != null)
            {
                var containerType = metadata.Parent.ContainerType;
                if (containerType != null && metadata.PropertyName == "CallToActionTitle" && containerType == typeof(CompanyLocationsBlock))
                {
                    metadata.ShowForEdit = false;
                }
            }
            base.ModifyMetadata(metadata, attributes);
        }
    }

    #endregion
}