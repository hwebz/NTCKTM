using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using KtmCompany.Web.Models.BlockTypes;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "a6206e3e-8970-42ec-a00e-0c9a69a205fc", GroupName = GroupNames.Popular)]
    [AvailableContentTypes(Include = new[] { typeof(ArticlePage) })]
    public class ArticleListingPage : PageDataBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 30)]
        public virtual StageSliderBlock HeaderStageSlider { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 40)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string Abstract { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 50)]
        [DefaultValue(6)]
        [Range(6, 100)]
        public virtual int PageSize { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        [AllowedTypes(typeof(NewsletterBlock))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea BottomContentArea { get; set; }
    }
}