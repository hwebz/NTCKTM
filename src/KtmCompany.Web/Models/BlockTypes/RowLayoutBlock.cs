using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "cbbf570d-3742-4be5-85be-1393f3a4b26c", GroupName = GroupNames.Other)]
    public class RowLayoutBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(Order = 100)]
        public virtual ContentArea ContentArea { get; set; }

    }
}