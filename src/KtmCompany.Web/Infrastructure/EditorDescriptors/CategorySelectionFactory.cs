using System.Collections.Generic;
using System.Linq;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Infrastructure.Attributes;
using KtmCompany.Web.Infrastructure.Extensions;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    public class CategorySelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(
           ExtendedMetadata metadata)
        {
            //Read category root path from attribute
            var categoryRootPath = GetCategoryRootPath(metadata);

            if (string.IsNullOrEmpty(categoryRootPath)) yield break;

            var catRepo = ServiceLocator.Current.GetInstance<CategoryRepository>();
            if (categoryRootPath == CategoryConstants.AllCategory)
            {
                var categories = catRepo.GetRoot().GetList();

                //Add default value for single selection
                if (IsSelectOne(metadata))
                {
                    yield return new SelectItem
                    {
                        Text = string.Empty,
                        Value = string.Empty
                    };
                }

                var dicCatName = new Dictionary<string, string>();

                foreach (Category cat in categories)
                {
                    if (cat.Available && cat.Selectable)
                    {
                        if (!dicCatName.ContainsKey(cat.Name))
                        {
                            yield return new SelectItem
                            {
                                Text = cat.LocalizedDescription,
                                Value = cat.Name
                            };

                            dicCatName.Add(cat.Name, cat.LocalizedDescription);
                        }
                    }
                }
            }
            else
            {
                var catRoot = catRepo.GetRoot().GetCategoryByPath(categoryRootPath);

                if (catRoot == null) yield break;

                //Add default value for single selection
                if (IsSelectOne(metadata))
                {
                    yield return new SelectItem
                    {
                        Text = string.Empty,
                        Value = string.Empty
                    };
                }

                //Get sub categories
                foreach (var cat in catRoot.Categories)
                {
                    if (cat.Available && cat.Selectable)
                    {
                        yield return new SelectItem
                        {
                            Text = cat.LocalizedDescription,
                            Value = cat.Name
                        };
                    }
                }
            }
        }

        private static bool IsSelectOne(ExtendedMetadata metadata)
        {
            var selectOneAttribute = metadata.Attributes.OfType<CategorySelectOneAttribute>().FirstOrDefault();
            return selectOneAttribute != null;
        }

        private static string GetCategoryRootPath(ExtendedMetadata metadata)
        {
            var selectOneAttribute = metadata.Attributes.OfType<CategorySelectOneAttribute>().FirstOrDefault();
            if (selectOneAttribute != null)
            {
                return selectOneAttribute.CategoryRootPath;
            }
            var selectManyAttribute = metadata.Attributes.OfType<CategorySelectManyAttribute>().FirstOrDefault();
            if (selectManyAttribute != null)
            {
                return selectManyAttribute.CategoryRootPath;
            }
            return string.Empty;
        }
    }
}