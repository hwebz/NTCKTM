using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Geta.EPi.Extensions.EditorDescriptors;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Models.EditorModels;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "c60e7b42-f276-4125-b3e5-fe96be12da28", GroupName = GroupNames.Media)]
    public class BackgroundVideoBlock : BlockDataBase
    {
        [Display(Order = 50)]
        [CultureSpecific(true)]
        [AllowedTypes(typeof(VideoFile))]
        public virtual ContentReference Video { get; set; }

        [Display(Order = 60)]
        [AllowedTypes(typeof(ImageFile))]
        [CultureSpecific(true)]
        public virtual ContentReference BackupImage { get; set; }

        [Display(Order = 65)]
        [CultureSpecific(true)]
        [Enum(typeof(VideoLayoutOption))]
        public virtual VideoLayoutOption VideoLayoutOption { get; set; }

        [Display(Order = 70)]
        [CultureSpecific(true)]
        public virtual string ButtonLabel { get; set; }

        [Display(Order = 80)]
        [DefaultValue(true)]
        public virtual bool IsHeadlineLooping { get; set; }

        [Display(Order = 90)]
        [Range(1000, 10000)]
        [DefaultValue(3000)]
        public virtual int HeadlineDisplayInterval { get; set; }

        [Display(Order = 300)]
        [CultureSpecific(true)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<HeadLine>))]
        public virtual IList<HeadLine> Headlines { get; set; }
    }
}