using System;
using System.Linq;
using EPiServer.DataAbstraction;

namespace KtmCompany.Web.Infrastructure.Extensions
{
    public static class CategoryExtensions
    {
        /// <summary>
        /// Get category by path
        /// </summary>
        /// <param name="catRoot">Category Root</param>
        /// <param name="catPath">Category Path (like "parent/sub")</param>
        /// <returns></returns>
        public static Category GetCategoryByPath(this Category catRoot, string catPath)
        {
            Category result = null;
            if (!string.IsNullOrEmpty(catPath))
            {
                var catNames = catPath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                var catCount = catNames.Length;
                var i = 0;

                while (catRoot != null && i < catCount)
                {
                    catRoot = FindChildWithoutRecusive(catRoot, catNames[i]);
                    i++;
                }

                if (catRoot != null && catRoot.Name.Equals(catNames[catCount - 1], StringComparison.InvariantCultureIgnoreCase))
                {
                    result = catRoot;
                }
            }

            return result;
        }

        private static Category FindChildWithoutRecusive(Category catRoot, string catName)
        {
            if (catRoot.Categories.Count == 0)
                return null;

            var category = catRoot.Categories.FirstOrDefault(x => string.Equals(x.Name, catName, StringComparison.InvariantCultureIgnoreCase));

            return category;
        }
    }
}