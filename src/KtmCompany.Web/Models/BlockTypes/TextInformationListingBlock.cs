using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Shell.ObjectEditing;
using Geta.EPi.Extensions.EditorDescriptors;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Models.EditorModels;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "9f26d917-d648-42c3-9e07-b91a96300b2b", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class TextInformationListingBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(Order = 100)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationItem>))]
        public virtual IList<TextInformationItem> TextInformationItems { get; set; }

        [Display(Order = 110)]
        [Enum(typeof(NumberOfColumns))]
        [DefaultValue(NumberOfColumns.ThreeColumn)]
        public virtual NumberOfColumns NumberOfColumns { get; set; }

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