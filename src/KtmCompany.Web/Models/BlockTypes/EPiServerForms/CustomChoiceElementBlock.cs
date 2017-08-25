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
    [ContentType(GUID = "52fb5df0-47e9-4c60-af6f-2bff4af92aaf", GroupName = GroupNames.CustomFormElements)]
    public class CustomChoiceElementBlock : ChoiceElementBlock, ICustomElementBlockBase
    {
        [DefaultValue(1)]
        [Range(1, 3)]
        public virtual int ColumnIndex { get; set; }

        public virtual bool FullRowWidth { get; set; }

        [ScaffoldColumn(false)]
        public override bool AllowMultiSelect
        {
            get { return base.AllowMultiSelect; }
            set { base.AllowMultiSelect = value; }
        }

        [ScaffoldColumn(false)]
        [DefaultValue("FormsFeed_UseManualInput")]
        public override string Feed
        {
            get { return base.Feed; }
            set { base.Feed = value; }
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