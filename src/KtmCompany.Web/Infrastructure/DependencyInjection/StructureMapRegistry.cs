using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace KtmCompany.Web.Infrastructure.DependencyInjection
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            // TODO add some examples here.
            Scan(x =>
            {
                x.TheCallingAssembly();
                //x.ExcludeNamespaceContainingType<IEvent>();
                x.WithDefaultConventions();
            });

            // TODO reported as bug: FIND-853
            //For<IFilterProvider>().Use<StructureMapFilterProvider>();
        }
    }
}