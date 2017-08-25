using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "4d1f62fe-6c92-4f7c-8887-8a676ed44e99", GroupName = GroupNames.Media)]
    public class MediaStreamBlock : GenericContentBlockBase
    {
        [CultureSpecific]
        [Display(Order = 100)]
        [AllowedTypes(typeof(ImageFile))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea ContentArea { get; set; }
    }
}