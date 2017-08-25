using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.ViewModels;

namespace KtmCompany.Web.Controllers
{
    /* Note: This is the global preview controller for all blocks on this site */
    [TemplateDescriptor(
        Inherited = true,
        TemplateTypeCategory = TemplateTypeCategories.MvcController, //Required as controllers for blocks are registered as MvcPartialController by default
        Tags = new[] { RenderingTags.Preview },
        AvailableWithoutTag = false)]
    [VisitorGroupImpersonation]
    public class BlockPreviewController : Controller, IRenderTemplate<BlockData>
    {
        private readonly IContentLoader _contentLoader;
        private readonly DisplayOptions _displayOptions;
        private readonly TemplateResolver _templateResolver;
        public BlockPreviewController(IContentLoader contentLoader, TemplateResolver templateResolver, DisplayOptions displayOptions)
        {
            _contentLoader = contentLoader;
            _templateResolver = templateResolver;
            _displayOptions = displayOptions;
        }

        public ActionResult Index(IContent currentContent)
        {
            //As the layout requires a page for title etc we "borrow" the start page
            var startPage = _contentLoader.Get<StartPage>(ContentReference.StartPage);

            var model = new BlocksPreviewViewModel(startPage, currentContent);
            var supportedDisplayOptions = _displayOptions
             .Select(x => new { Tag = x.Tag, Name = x.Name, Supported = SupportsTag(currentContent, x.Tag) })
             .ToList();
            if (supportedDisplayOptions.Any(x => x.Supported))
            {
                foreach (var displayOption in supportedDisplayOptions)
                {
                    var contentArea = new ContentArea();
                    contentArea.Items.Add(new ContentAreaItem
                    {
                        ContentLink = currentContent.ContentLink
                    });
                    var areaModel = new BlocksPreviewViewModel.PreviewArea
                    {
                        Supported = displayOption.Supported,
                        AreaTag = displayOption.Tag,
                        AreaName = displayOption.Name,
                        ContentArea = contentArea
                    };
                    model.Areas.Add(areaModel);
                }
            }
            return View(model);
        }
        private bool SupportsTag(IContent content, string tag)
        {
            var templateModel = _templateResolver.Resolve(HttpContext,
                                      content.GetOriginalType(),
                                      content,
                                      TemplateTypeCategories.MvcPartial,
                                      tag);

            return templateModel != null;
        }
    }
}