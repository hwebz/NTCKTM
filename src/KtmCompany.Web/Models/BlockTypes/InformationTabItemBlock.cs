using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "a7a1be12-40c8-4e12-99d6-fff8dd65b2d9", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class InformationTabItemBlock : BlockDataBase
    {
        [Display(Order = 20)]
        [CultureSpecific]
        public virtual string SubHeader { get; set; }

        [Display(Order = 30)]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }        

        [Display(Order = 40)]
        [CultureSpecific(false)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference BackgroundImage { get; set; }

        [Display(Order = 50)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(DocumentListingBlock), typeof(TextBlock) })]
        public virtual ContentArea AddtionalContentArea { get; set; }
    }
}