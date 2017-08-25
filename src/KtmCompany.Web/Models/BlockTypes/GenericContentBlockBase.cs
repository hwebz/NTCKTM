using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using KtmCompany.Web.Models.BlockTypes.Common;

namespace KtmCompany.Web.Models.BlockTypes
{
    public class GenericContentBlockBase : BlockDataBase
    {        
        [Display(
           GroupName = SystemTabNames.Content,
           Order = 10)]        
        public virtual LeftGenericContentBlock LeftContent { get; set; }             
    }
}