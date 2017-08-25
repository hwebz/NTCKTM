using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Foundation.Core.Models;
using KtmCompany.Web.Controllers;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.PageTypes.Constants;
using KtmCompany.Web.Models.ViewModels;

namespace KtmCompany.Web.Infrastructure
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class TemplateCoordinator : IViewTemplateModelRegistrator
    {
        public const string BlockFolder = "~/Views/Shared/Blocks/";
        public const string PagePartialsFolder = "~/Views/Shared/Partials/";
        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            // Disables DefaultPageController for page types that shouldn't have any template
            if ((args.ItemToRender is IContainerPage || args.ItemToRender is IHaveNoTemplate)
                && args.SelectedTemplate != null
                && (args.SelectedTemplate.TemplateType == typeof(DefaultPageController) || args.SelectedTemplate.TemplateType == typeof(BlockPreviewController)))
            {
                args.SelectedTemplate = null;
            }
        }

        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(EditorialPageBase), new TemplateModel
            {
                Name = "RelatedContent",
                Inherit = true,
                AvailableWithoutTag = true,
                Path = PagePartialPath("EditorialPageBase.cshtml")
            });
            //viewTemplateModelRegistrator.Add(typeof(BackgroundVideoBlock), new TemplateModel
            //{
            //    Name = "VideoBanner",
            //    Inherit = true,
            //    Tags = new[] { TagNames.VideoBanner },
            //    AvailableWithoutTag = false,
            //    Path = PagePartialPath("VideoBanner.cshtml")
            //});
            viewTemplateModelRegistrator.Add(typeof(ImageFile), new TemplateModel
            {
                Name = "ImageSliderItem",
                Inherit = true,
                Tags = new[] { TagNames.ContentSlider },
                AvailableWithoutTag = false,
                Path = PagePartialPath("ImageSliderItem.cshtml")
            });
            viewTemplateModelRegistrator.Add(typeof(TextBlock), new TemplateModel
            {
                Name = "TextSliderItem",
                Inherit = true,
                Tags = new[] { TagNames.ContentSlider },
                AvailableWithoutTag = false,
                Path = PagePartialPath("TextSliderItem.cshtml")
            });
            viewTemplateModelRegistrator.Add(typeof(MouseoverItemBlock), new TemplateModel
            {
                Name = "MouseoverItem",
                Inherit = true,
                Tags = new[] { TagNames.MouseoverItem },
                AvailableWithoutTag = false,
                Path = PagePartialPath("MouseoverItem.cshtml")
            });
        }

        private static string BlockPath(string fileName)
        {
            return string.Format("{0}{1}", BlockFolder, fileName);
        }

        private static string PagePartialPath(string fileName)
        {
            return string.Format("{0}{1}", PagePartialsFolder, fileName);
        }
    }
}