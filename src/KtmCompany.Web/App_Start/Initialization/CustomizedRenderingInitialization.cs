using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Web;
using Foundation.Core.Models;
using KtmCompany.Web.Controllers;
using KtmCompany.Web.Infrastructure;
using InitializationModule = EPiServer.Web.InitializationModule;

namespace KtmCompany.Web.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(InitializationModule))]
    public class CustomizedRenderingInitialization : IInitializableModule
    {
        private static bool _initialized;

        public void Initialize(InitializationEngine context)
        {
            if (_initialized)
            {
                return;
            }

            ViewEngines.Engines.Insert(0, new FoundationViewEngine());

            context.Locate.TemplateResolver().TemplateResolved += OnTemplateResolved;

            _initialized = true;
        }

        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            // Disables DefaultPageController for page types that shouldn't have any template
            if ((args.ItemToRender is IHaveNoTemplate) && args.SelectedTemplate != null && args.SelectedTemplate.TemplateType == typeof(DefaultPageController))
            {
                args.SelectedTemplate = null;
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            context.Locate.TemplateResolver().TemplateResolved -= OnTemplateResolved;
        }
    }
}