using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;
using EPiServer.Web;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "965ffc9c-b4e9-4a89-b797-639e3db41db2", GroupName = GroupNames.Popular)]
    public class GenericContentBlock : GenericContentBlockBase
    {
        [Display(Order = 110)]        
        [AllowedTypes(new []{typeof(TextBlock), typeof(ContentSliderBlock), typeof(TextInformationListingBlock),
            typeof(MediaListingBlock), typeof(IFrameContentBlock), typeof(SharePriceDataBlock), typeof(DocumentListingBlock), typeof(ArticlesBlock), typeof(DataBlock), typeof(TimeLineBlock), typeof(BackgroundVideoBlock), typeof(RowLayoutBlock)})]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea RightContentArea { get; set; }

        [Display(Order = 130)]
        public virtual bool IsSticky { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 150)]
        public virtual bool ShowRightBottomHrLink { get; set; }
    }
}