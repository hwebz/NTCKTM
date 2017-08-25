using System;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.BlockTypes;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(GUID = "a35c0203-e548-4918-b932-05205cc8c491", GroupName = GroupNames.Popular)]
    [AvailableContentTypes(Availability = Availability.None)]
    public class ArticlePage : EditorialPageBase
    {        
        [Display(Order = 120)]
        [UIHint(UIHint.MediaFile)]
        [CultureSpecific]
        public virtual ContentReference AttachmentFile { get; set; }

        [Display(Order = 130)]
        [CultureSpecific]
        public virtual string AttachmentText { get; set; }

        [Display(Order = 140)]
        public virtual RelatedContentsBlock RelatedNews { get; set; }
    }
}