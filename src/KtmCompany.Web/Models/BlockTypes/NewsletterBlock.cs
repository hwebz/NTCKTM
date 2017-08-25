using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using KtmCompany.Web.Models.BlockTypes.EPiServerForms;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "1d970a4a-0b9e-4fd8-86b5-3abb7b38b2ec", GroupName = GroupNames.Other)]
    public class NewsletterBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(Order = 100)]
        [AllowedTypes(typeof(CustomFormContainerBlock))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea FormContainerArea { get; set; }

        [Display(Order = 120)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference BackgroundImage { get; set; }
    }
}