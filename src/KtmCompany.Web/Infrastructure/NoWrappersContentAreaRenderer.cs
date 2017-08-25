using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Editor;
using EPiServer.Framework.Web;
using EPiServer.Logging;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using Geta.EPi.Extensions;
using KtmCompany.Web.Helpers;

namespace KtmCompany.Web.Infrastructure
{
    /// <summary>
    /// Renders blocks without wrapping (div) tags.
    /// </summary>
    public class NoWrappersContentAreaRenderer
    {
        private readonly IContentRenderer _contentRenderer;
        private readonly TemplateResolver _templateResolver;

        public NoWrappersContentAreaRenderer(IContentRenderer contentRenderer,
            TemplateResolver templateResolver)
        {
            _contentRenderer = contentRenderer;
            _templateResolver = templateResolver;
        }

        public virtual void Render(HtmlHelper helper, ContentArea contentArea, string templateTag = null)
        {
            if (contentArea != null)
            {
                var items = (PageEditing.PageIsInEditMode
                    ? contentArea.Items
                    : contentArea.FilteredItems).ToArray();
                foreach (var item in items)
                {
                    try
                    {
                        var content = item.ContentLink.Get<IContent>();

                        var templateModel = _templateResolver.Resolve(helper.ViewContext.HttpContext,
                            content.GetOriginalType(), content,
                            TemplateTypeCategories.MvcPartial, templateTag);

                        using (new ContentAreaContext(helper.ViewContext.RequestContext, content.ContentLink))
                        {
                            helper.RenderContentData(content, true, templateModel, _contentRenderer);
                        }
                    }
                    catch (ContentNotFoundException ex)
                    {
                        LogManager.GetLogger(typeof(HtmlHelpers)).Error(ex.Message, ex);
                    }                   
                }
            }
        }
    }
}