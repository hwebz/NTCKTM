using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace KtmCompany.Web.Initialization
{
    /// <summary>
    /// Initialization module for EPiServer CMS. We use this instead of Global.asax to avoid exceptions when the application starts in EPiServer.Framework
    /// </summary>
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FilterInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}