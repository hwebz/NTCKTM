using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.BlockTypes;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using KtmCompany.Web.Infrastructure.EditorDescriptors;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "7a6d16b3-ea62-47c8-9d9a-7023d614e20d", GroupName = GroupNames.Popular)]
    [AvailableContentTypes(Availability = Availability.None)]
    public class JobDetailPage : EditorialPageBase
    {
        [Display(Order = 120)]
        [BackingType(typeof(PropertyDropDownList))]
        public virtual string JobPosition { get; set; }

        [Display(Order = 130)]
        [ClientEditor(ClientEditingClass = "app.editors.FilterableSelectionEditor", SelectionFactoryType = typeof(CountrySelectionFactory))]
        public virtual string Country { get; set; }

        [Display(Order = 150)]
        public virtual RelatedContentsBlock RelatedJobs { get; set; }

        [ScaffoldColumn(false)]
        public override string SubHeader
        {
            get { return base.SubHeader; }
            set { base.SubHeader = value; }
        }
    }
}