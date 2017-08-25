using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.EditorModels;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(DisplayName = "ContacUsPage", GUID = "dcd61fdd-1bd9-46db-9a79-178da6344bb0", GroupName = GroupNames.Other)]
    [AvailableContentTypes(Availability = Availability.None)]
    public class ContactUsPage : PageDataBase
    {
        [Display(Order = 20)]
        public virtual ImageBannerBlock ImageBannerBlock { get; set; }

        [Display(Order = 30)]
        [CultureSpecific]
        public virtual XhtmlString Abstract { get; set; }

        [Display(Order = 40)]
        [CultureSpecific]
        public virtual LinkItemCollection ProductWebsiteLinks { get; set; }

        [Display(Order = 50)]
        [CultureSpecific]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<ContactUs>))]
        public virtual IList<ContactUs> ContactUsContent { get; set; }

        [Display(Order = 60)]
        [CultureSpecific]
        public virtual string ContactFormHeading { get; set; }

        [Display(Order = 70)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string ContactFormAbstract { get; set; }

        [Display(Order = 80)]
        [CultureSpecific]
        [AllowedTypes(typeof(FormContainerBlock))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea ContactFormContainer { get; set; }

    }
}