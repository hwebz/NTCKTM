using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Core;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Forms.Implementation.Elements.BaseClasses;
using EPiServer.Forms.Implementation.Validation;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes.EPiServerForms
{
    [ContentType(GUID = "f148a503-ae34-4da1-9b48-23ab701c93bc", GroupName = GroupNames.CustomFormElements)]
    public class CustomCheckboxBlock : DataElementBlockBase, ICustomElementBlockBase
    {
        public virtual XhtmlString CustomLabel { get; set; }

        [DefaultValue(1)]
        [Range(1, 3)]
        public virtual int ColumnIndex { get; set; }

        public virtual bool FullRowWidth { get; set; }

        [Ignore]
        public override Type[] ValidatorTypesToBeExcluded
        {
            get
            {
                return new Type[7]
                {
                  typeof (RegularExpressionValidator),
                  typeof (EmailValidator),
                  typeof (DateDDMMYYYYValidator),
                  typeof (DateMMDDYYYYValidator),
                  typeof (DateYYYYMMDDValidator),
                  typeof (IntegerValidator),
                  typeof (PositiveIntegerValidator)
                };
            }
            set
            {
            }
        }

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