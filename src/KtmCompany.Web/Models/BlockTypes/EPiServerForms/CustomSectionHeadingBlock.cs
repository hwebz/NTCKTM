using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Core;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes.EPiServerForms
{
    [ContentType(GUID = "318a9a44-f823-4399-8633-64292204fdfd", GroupName = GroupNames.CustomFormElements)]
    public class CustomSectionHeadingBlock : ElementBlockBase, ICustomElementBlockBase
    {
        [DefaultValue(1)]
        [Range(1, 3)]
        public virtual int ColumnIndex { get; set; }

        public virtual bool FullRowWidth { get; set; }

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