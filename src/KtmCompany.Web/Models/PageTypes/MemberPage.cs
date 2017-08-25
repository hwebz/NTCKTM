using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Foundation.Core.Models;
using KtmCompany.Web.Models.MediaTypes;
using EPiServer.Web;
using KtmCompany.Web.Infrastructure;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "93876362-16d2-4f6d-9e99-97d9dcffd51a", GroupName = GroupNames.Other)]
    [AvailableContentTypes(Availability = Availability.None)]
    public class MemberPage : PageData, IHaveNoTemplate
    {
        [Display(Order = 20)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference Image { get; set; }

        [Display(Order = 30)]
        [ClientEditor(ClientEditingClass = "app.editors.DateTextBoxEditor")]
        //[UIHint(SiteUIHint.DateOnly, PresentationLayer.Edit)]
        public virtual DateTime? DateOfBirth { get; set; }

        [Display(Order = 40)]
        [ClientEditor(ClientEditingClass = "app.editors.DateTextBoxEditor")]
        //[UIHint(SiteUIHint.DateOnly, PresentationLayer.Edit)]
        public virtual DateTime? AppointedUntilDate { get; set; }

        [Display(Order = 50)]
        [CultureSpecific]
        [Required]
        [UIHint(UIHint.LongString)]
        public virtual string ResponsibleTitle { get; set; }

        [Display(Order = 60)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string ResponsibleDescription { get; set; }

        [Display(Order = 70)]
        [CultureSpecific]
        public virtual XhtmlString BriefHistory { get; set; }

        public int SortIndex => (int)this["PagePeerOrder"];
    }
}