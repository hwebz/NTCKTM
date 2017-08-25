using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace KtmCompany.Web.Models.MediaTypes
{
    [ContentType(DisplayName = "Document File", GUID = "97e91feb-c757-4489-ab4f-5ea256341782")]
    [MediaDescriptor(ExtensionString = "doc,docx")]
    public class DocumentFile : MediaDataBase
    {        
    }
}