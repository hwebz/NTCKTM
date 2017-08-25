using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "19889076-4eab-4967-8e8f-b36a2c787c9c", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class DataBlock : BlockDataBase
    {        
        [Display(Order = 30)]
        [AllowedTypes(typeof(StatisticInformationBlock))]
        [CultureSpecific(true)]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]        
        public virtual ContentArea StatisticInformationItems { get; set; }
    }
}