using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace KtmCompany.Web.Models.MediaTypes
{
    [ContentType(DisplayName = "PDF File", GUID = "206e60be-1a33-4f8d-98ca-97601c210a6f", Description = "")]
    [MediaDescriptor(ExtensionString = "pdf")]
    public class PDFFile : MediaDataBase
    {        
    }
}