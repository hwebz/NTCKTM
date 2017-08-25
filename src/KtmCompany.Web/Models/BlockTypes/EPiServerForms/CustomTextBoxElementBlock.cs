using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes.EPiServerForms
{
    [ContentType(GUID = "5004df55-cdf0-483f-8f7b-cceba43dabe8", GroupName = GroupNames.CustomFormElements)]
    public class CustomTextBoxElementBlock : TextboxElementBlock, ICustomElementBlockBase
    {
        [DefaultValue(1)]
        [Range(1, 3)]
        public virtual int ColumnIndex { get; set; }

        public virtual bool FullRowWidth { get; set; }

        public virtual bool IsDigitOnly { get; set; }

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