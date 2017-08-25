using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Models.PageTypes;
using EPiServer;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "e79dff79-6aed-4e5f-8d2b-7b6d7887c31b", GroupName = GroupNames.Other)]
    public class InvestorSharePriceBlock : BlockDataBase
    {
        [Display(Order = 5)]
        public virtual bool IsSticky { get; set; }

        [Display(Order = 10)]
        [CultureSpecific(true)]
        public virtual string CallToActionTitle { get; set; }

        [Display(Order = 20)]
        [CultureSpecific(true)]
        public virtual Url CallToAction { get; set; }

        [Display(Order = 30)]
        [CultureSpecific(true)]
        public virtual Url LeftIFrameSource { get; set; }

        [Display(Order = 40)]
        [CultureSpecific(true)]
        public virtual Url RightIFrameSource { get; set; }
    }
}