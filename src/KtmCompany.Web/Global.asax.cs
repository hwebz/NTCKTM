using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EPiServer.ServiceLocation;
using Foundation.Core.Infrastructure;
using Foundation.Core.Infrastructure.Tasks;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Infrastructure.Bundling;
using StructureMap;

namespace KtmCompany.Web
{
    public class Global : EPiServer.Global
    {
        public IContainer Container
        {
            get { return (IContainer)HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Insert(0, new FoundationViewEngine());

            // Remove Visual Basic
            foreach (var engine in ViewEngines.Engines)
            {
                DisableVbhtml(engine as RazorViewEngine);
            }

            ModelBinders.Binders.DefaultBinder = new BetterDefaultModelBinder();

            foreach (var task in ServiceLocator.Current.GetAllInstances<IRunAtInit>())
            {
                task.Execute();
            }
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            base.RegisterRoutes(routes);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public void Application_BeginRequest()
        {
            Container = ObjectFactory.Container.GetNestedContainer();

            foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (var task in Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

        public void Application_EndRequest()
        {
            if (Container == null)
            {
                return;
            }

            try
            {
                foreach (var task in Container.GetAllInstances<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            finally
            {
                Container.Dispose();
                Container = null;
            }
        }

        public void DisableVbhtml(RazorViewEngine engine)
        {
            if (engine == null)
            {
                return;
            }

            engine.AreaViewLocationFormats = RemoveVbhtml(engine.AreaViewLocationFormats);
            engine.AreaMasterLocationFormats = RemoveVbhtml(engine.AreaMasterLocationFormats);
            engine.AreaPartialViewLocationFormats = RemoveVbhtml(engine.AreaPartialViewLocationFormats);
            engine.ViewLocationFormats = RemoveVbhtml(engine.ViewLocationFormats);
            engine.MasterLocationFormats = RemoveVbhtml(engine.MasterLocationFormats);
            engine.PartialViewLocationFormats = RemoveVbhtml(engine.PartialViewLocationFormats);
            engine.FileExtensions = RemoveVbhtml(engine.FileExtensions);
        }

        private string[] RemoveVbhtml(IEnumerable<string> source)
        {
            return source.Where(s => !s.Contains("vbhtml")).ToArray();
        }
    }
}
