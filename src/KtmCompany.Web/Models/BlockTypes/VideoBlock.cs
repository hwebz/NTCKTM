using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "9b1c5f44-4129-4268-8e20-562c452f07fe", GroupName = GroupNames.Media)]
    public class VideoBlock : BlockDataBase
    {
        [Display(Order = 10)]
        [UIHint(UIHint.Video)]
        [AllowedTypes(typeof(VideoFile))]
        [Required]
        public virtual ContentReference Video { get; set; }

        [Display(Order = 20)]
        [UIHint(UIHint.Image)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference BackupImage { get; set; }
    }
}