using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "c53eedfd-efb0-4da8-8d50-9a747b5cc1de", GroupName =  GroupNames.Other)]
    public class DocumentListingBlock : BlockDataBase
    {
        [Display(Order = 10)]
        [CultureSpecific]
        [AllowedTypes(typeof(DocumentFile), typeof(ExcelFile), typeof(PDFFile), typeof(CompressedFile))]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea Documents { get; set; }
    }
}