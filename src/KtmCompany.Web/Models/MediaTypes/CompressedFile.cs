using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace KtmCompany.Web.Models.MediaTypes
{
    [ContentType(DisplayName = "Compressed File", GUID = "3e717030-cdda-445a-8434-7fac5c9ca7f4", Description = "")]
    [MediaDescriptor(ExtensionString = "zip,rar")]    
    public class CompressedFile : MediaDataBase
    {        
    }
}