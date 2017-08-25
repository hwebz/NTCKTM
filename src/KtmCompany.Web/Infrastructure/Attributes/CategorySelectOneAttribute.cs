using System.Web.Mvc;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Infrastructure.EditorDescriptors;

namespace KtmCompany.Web.Infrastructure.Attributes
{
    public class CategorySelectOneAttribute : SelectOneAttribute, IMetadataAware
    {
        /// <summary>
        /// Category root path in CategoryAttribute
        /// </summary>
        public string CategoryRootPath { get; set; }

        /// <summary>
        /// Category Attribute
        /// </summary>
        /// <param name="categoryRootPath">category root path</param>
        public CategorySelectOneAttribute(string categoryRootPath)
        {
            CategoryRootPath = categoryRootPath;
        }

        public new void OnMetadataCreated(ModelMetadata metadata)
        {
            SelectionFactoryType = typeof(CategorySelectionFactory);
            base.OnMetadataCreated(metadata);
        }
    }
}