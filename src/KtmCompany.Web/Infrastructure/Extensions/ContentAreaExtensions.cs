using System.Collections.Generic;
using EPiServer.Core;
using Geta.EPi.Extensions;

namespace KtmCompany.Web.Infrastructure.Extensions
{
    public static class ContentAreaExtensions
    {
        public static List<T> GetItems<T>(this ContentArea contentArea)
        {
            var result = new List<T>();
            if (contentArea?.FilteredItems != null)
            {
                foreach (var item in contentArea.FilteredItems)
                {
                    var itemContent = item.ContentLink.Get<IContent>();
                    if (itemContent is T)
                    {
                        result.Add((T)itemContent);
                    }
                }
            }
            return result;
        }
    }
}