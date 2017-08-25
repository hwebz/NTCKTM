using System;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace KtmCompany.Web.Models.MediaTypes
{
    [ContentType(DisplayName = "Excel File", GUID = "3d9b29a5-645d-44e1-a3a1-779161bbb8ba", Description = "")]
    [MediaDescriptor(ExtensionString = "xls,xlsx")]
    public class ExcelFile : MediaDataBase
    {        
    }
}