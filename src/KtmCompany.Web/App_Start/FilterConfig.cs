using System.Web.Mvc;
using EPiServer.ServiceLocation;
using Foundation.Core.Infrastructure.Attributes;

namespace KtmCompany.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(ServiceLocator.Current.GetInstance<CustomHandleErrorAttribute>());
        }
    }
}