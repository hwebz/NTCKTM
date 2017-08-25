using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using KtmCompany.Web.Models.PageTypes;
using Geta.EPi.Extensions;
using KtmCompany.Web.Infrastructure.Extensions;

namespace KtmCompany.Web.Helpers
{
    public class CategoryHelpers
    {
        public static string GetCategoryColor(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                var categoryColorItem = ContentReference.StartPage.Get<StartPage>().SiteSettings.CategoryColors?.FirstOrDefault(x => x.Category == category);
                if (categoryColorItem != null)
                {
                    return categoryColorItem.Color;
                }
            }
            return "#000000";
        }

        public static List<SelectListItem> GetCategorySelectionsByPath(string categoryPath = null)
        {
            var results = new List<SelectListItem>();
            var catRepo = ServiceLocator.Current.GetInstance<CategoryRepository>();
            var catRoot = catRepo.GetRoot();

            if (catRoot != null)
            {
                if (!string.IsNullOrEmpty(categoryPath))
                {
                    catRoot = catRoot.GetCategoryByPath(categoryPath);
                }
                if (catRoot != null)
                {
                    results.AddRange(catRoot.Categories.Select(x => new SelectListItem()
                    {
                        Value = x.Name,
                        Text = x.Name
                    }).ToList());
                }
            }

            return results;
        }
    }
}