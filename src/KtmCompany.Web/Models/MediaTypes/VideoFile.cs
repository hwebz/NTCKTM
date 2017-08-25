using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace KtmCompany.Web.Models.MediaTypes
{
    [ContentType(DisplayName = "Video File", GUID = "6db53875-1998-4074-9030-f832eac495a9")]
    [MediaDescriptor(ExtensionString = "mp4,avi")]
    public class VideoFile : VideoData
    {        
    }
}