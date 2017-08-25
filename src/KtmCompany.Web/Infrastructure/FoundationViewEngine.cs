using System.Linq;
using System.Web.Mvc;

namespace KtmCompany.Web.Infrastructure
{
    /// <summary>
    /// View engine with additional view mappings so that views can be put in either /Views/Pages, /Views/Blocks, /Views/Partials or /Views/Shared, 
    /// either in a folder named after the controller method or in a flat hierarchy with explicitly named views.
    /// Source: EPiServer Template Foundation http://etf.codeplex.com/SourceControl/latest
    /// </summary>
    /// <remarks>Supports the Razor view engine and C# views with a .cshtml file extension</remarks>
    public class FoundationViewEngine : RazorViewEngine
    {
        public FoundationViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(new[]
                                  {
                                    "~/Views/Shared/Blocks/{0}.cshtml",
                                    "~/Views/Shared/Blocks/EPiServerForms/{0}.cshtml",
                                    "~/Views/Shared/Partials/{0}.cshtml",
                                    "~/Views/Shared/PagePartials/{0}.cshtml",
                                     "~/Views/Shared/DisplayTemplates/{0}.cshtml",
                                    "~/Views/Shared/DisplayTemplates/{1}/{0}.cshtml"
                                  }).ToArray();
        }
    }
}