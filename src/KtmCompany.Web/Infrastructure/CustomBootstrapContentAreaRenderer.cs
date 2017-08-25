using System.Web.Mvc;
using EPiBootstrapArea;
using EPiServer.Core;

namespace KtmCompany.Web.Infrastructure
{
    public class CustomBootstrapContentAreaRenderer : BootstrapAwareContentAreaRenderer
    {       
        public override void Render(HtmlHelper htmlHelper, ContentArea contentArea)
        {
            if (contentArea == null || contentArea.IsEmpty)
                return;
            ViewContext viewContext = htmlHelper.ViewContext;
            TagBuilder tagBuilder = null;
            if (!this.IsInEditMode(htmlHelper) && this.ShouldRenderWrappingElement(htmlHelper))
            {
                tagBuilder = new TagBuilder(this.GetContentAreaHtmlTag(htmlHelper, contentArea));
                this.AddNonEmptyCssClass(tagBuilder, viewContext.ViewData["cssclass"] as string);
                if (this.AutoAddRow)
                    this.AddNonEmptyCssClass(tagBuilder, "row-wrapper-block");
                viewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            }
            this.RenderContentAreaItems(htmlHelper, contentArea.FilteredItems);
            if (tagBuilder == null)
                return;
            viewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.EndTag));
        }        
    }
}
