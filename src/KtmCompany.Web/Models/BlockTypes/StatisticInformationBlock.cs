using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Web;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "ace5484d-7389-441e-8d9e-be0561274f54", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class StatisticInformationBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(Order = 5)]
        [MaxLength(1)]
        public virtual string Sign { get; set; }

        [CultureSpecific]
        [Display(Order = 10)]
        [Range(0, double.MaxValue)]
        public virtual double Number { get; set; }

        [Ignore]
        public string NumberDisplay { get; set; }

        [CultureSpecific]
        [Display(Order = 15)]
        [MaxLength(1)]
        public virtual string Unit { get; set; }

        [CultureSpecific]
        [MaxLength(20)]
        [Display(Order = 20)]
        public virtual string Title { get; set; }

        [Display(GroupName = SystemTabNames.Content,Order = 30)]
        [CultureSpecific(false)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(Order = 40)]
        [UIHint(UIHint.Textarea)]
        [MaxLength(95)]
        public virtual string RightTitle { get; set; }

        [Display(GroupName = SystemTabNames.Content,Order = 60)]
        [CultureSpecific(true)]
        [MaxLength(55)]
        public virtual string CallToActionTitle { get; set; }

        [Display(GroupName = SystemTabNames.Content,Order = 70)]
        [CultureSpecific(false)]
        public virtual Url CallToAction { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 80)]
        [CultureSpecific]
        public virtual Url ExternalSource { get; set; }
    }
}