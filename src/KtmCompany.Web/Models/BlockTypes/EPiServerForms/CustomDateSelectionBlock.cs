using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Forms.Implementation.Validation;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes.EPiServerForms
{
    [ContentType(GUID = "0dc11a9c-f231-45e7-9491-b1cbbdcc14cc", GroupName = GroupNames.CustomFormElements)]
    public class CustomDateSelectionBlock : TextboxElementBlock, ICustomElementBlockBase
    {
        [DefaultValue(1)]
        [Range(1, 3)]
        [Display(Order = 10)]
        public virtual int ColumnIndex { get; set; }

        [Display(Order = 20)]
        public virtual bool FullRowWidth { get; set; }

        [Ignore]
        public override Type[] ValidatorTypesToBeExcluded
        {
            get
            {
                return new Type[]
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

        [ScaffoldColumn(false)]
        public override string PredefinedValue
        {
            get { return base.PredefinedValue; }
            set { base.PredefinedValue = value; }
        }

        [ScaffoldColumn(false)]
        public override string PlaceHolder
        {
            get { return base.PlaceHolder; }
            set { base.PlaceHolder = value; }
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