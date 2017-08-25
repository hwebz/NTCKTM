using Foundation.Core.Infrastructure.Tasks;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace KtmCompany.Web.Infrastructure.DependencyInjection
{
    public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
            Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory(
                    // TODO move to configuration (prefix of assemblies to scan)
                    a => a.FullName.StartsWith("Foundation") || a.FullName.StartsWith("KtmCompany.Web"));
                scan.AddAllTypesOf<IRunAtInit>();
                scan.AddAllTypesOf<IRunOnEachRequest>();
                scan.AddAllTypesOf<IRunOnError>();
                scan.AddAllTypesOf<IRunAfterEachRequest>();
            });
        }
    }
}