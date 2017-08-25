using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel;

namespace KtmCompany.Web.Models.PageTypes
{
    [ContentType(DisplayName = "SearchPage", GUID = "06638899-256b-4de3-810a-465021a9a7a8", Description = "", GroupName = GroupNames.Other)]
    [AvailableContentTypes(Availability = Availability.None)]
    public class SearchPage : PageDataBase
    {
        [Display(Name = "Abstract", GroupName = SystemTabNames.Content, Order = 10)]
        [CultureSpecific]
        public virtual string Abstract { get; set; }

        [Display(Name = "PageSize", GroupName = SystemTabNames.Content, Order = 20)]
        [DefaultValue(6)]
        [Range(6, 100)]
        public virtual int PageSize { get; set; }
    }
}