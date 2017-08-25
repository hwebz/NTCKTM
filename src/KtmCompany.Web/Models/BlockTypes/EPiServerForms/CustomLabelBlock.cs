using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.Core;
using EPiServer.Data.Cache;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Core;
using EPiServer.Forms.Implementation.Validation;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Models.PageTypes;
using Geta.EPi.Extensions.EditorDescriptors;

namespace KtmCompany.Web.Models.BlockTypes.EPiServerForms
{
    [ContentType(GUID = "def55b7e-a757-4285-99ee-79664c81cf3d", GroupName = GroupNames.CustomFormElements)]
    public class CustomLabelBlock : ElementBlockBase, ICustomElementBlockBase
    {
        [DefaultValue(1)]
        [Range(1, 3)]
        public virtual int ColumnIndex { get; set; }

        public virtual bool FullRowWidth { get; set; }
        
        public virtual bool AlignRight { get; set; }

        public virtual bool RenderForMobile { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            PropertyInfo[] properties = GetType().BaseType.GetProperties();

            foreach (var property in properties)
            {
                var defaultValueAttribute = property.GetAttribute<DefaultValueAttribute>();

                if (defaultValueAttribute != null)
                {
                    this[property.Name] = defaultValueAttribute.Value;
                }
            }
        }
    }
}