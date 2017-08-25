using System.ComponentModel.DataAnnotations;
using EPiServer.PlugIn;
using EPiServer.Web;
using KtmCompany.Web.Models.EditorModels;

namespace KtmCompany.Web.Infrastructure.Properties
{
    [PropertyDefinitionTypePlugIn]
    public class MediaItemListProperty : PropertyListBase<MediaItem>
    {
    }
}