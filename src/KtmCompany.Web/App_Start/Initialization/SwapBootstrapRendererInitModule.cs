using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiBootstrapArea;
using EPiBootstrapArea.Initialization;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using KtmCompany.Web.Infrastructure;

namespace KtmCompany.Web.App_Start.Initialization
{
    [ModuleDependency(typeof(SwapRendererInitModule))]
    [InitializableModule]
    public class SwapBootstrapRendererInitModule : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(container => container
                                            .For<ContentAreaRenderer>()
                                            .Use<CustomBootstrapContentAreaRenderer>()
                                            .SetProperty(i => i.RowSupportEnabled = false)
                                            .SetProperty(i => i.AutoAddRow = true));
        }

        public void Initialize(InitializationEngine context) { }

        public void Uninitialize(InitializationEngine context) { }
    }
}