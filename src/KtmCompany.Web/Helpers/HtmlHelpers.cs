using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using Geta.EPi.Extensions;
using KtmCompany.Web.Infrastructure;

namespace KtmCompany.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static void RenderNoWrappersContentArea(this HtmlHelper helper, ContentArea contentArea, string templateTag = null)
        {
            var renderer = ServiceLocator.Current.GetInstance<NoWrappersContentAreaRenderer>();
            renderer.Render(helper, contentArea, templateTag);
        }
    }
}