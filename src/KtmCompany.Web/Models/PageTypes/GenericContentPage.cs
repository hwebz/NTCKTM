using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.BlockTypes;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(DisplayName = "Generic Content Page", GUID = "47024555-3c7f-4754-b479-1c2376e49733", GroupName = GroupNames.Popular)]
    [AvailableContentTypes(Include = new Type[] {typeof(GenericContentPage), typeof(ManagementBoardPage), typeof(JobListingPage) })]
    public class GenericContentPage : PageDataBase
    {
        [ScaffoldColumn(false)]
        public override string Heading
        {
            get { return base.Heading; }
            set { base.Heading = value; }
        }

        [Display(Order = 100)]        
        [AllowedTypes(new []{typeof(GenericContentBlockBase),
            typeof(PartnersBlock), typeof(ImageBannerBlock), typeof(BackgroundVideoBlock),
            typeof(JobListingPage), typeof(MediaStreamBlock),
            typeof(StageSliderBlock), typeof(StatementBlock), typeof(CareerPathsBlock), typeof(InvestorSharePriceBlock)})]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(Order = 110)]
        public virtual bool HasGrayBackground { get; set; }

        [ScaffoldColumn(false)]
        public override string ContentCategory
        {
            get { return base.ContentCategory; }
            set { base.ContentCategory = value; }
        }

        [ScaffoldColumn(false)]
        public override string MainIntro
        {
            get { return base.MainIntro; }
            set { base.MainIntro = value; }
        }
    }
}