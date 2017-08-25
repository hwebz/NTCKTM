using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Geta.EPi.Extensions;
using Geta.EPi.Extensions.EditorDescriptors;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Infrastructure.Extensions;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "5740512C-5196-45C0-BFE3-C3B93CC96D42", GroupName = GroupNames.Media)]
    public class ContentSliderBlock : BlockDataBase
    {
        [Display(Order = 50)]
        [AllowedTypes(AllowedTypes = new[] { typeof(ImageFile), typeof(TextBlock)})]
        [ClientEditor(ClientEditingClass = "app.editors.ExtendedContentArea")]
        public virtual ContentArea SlidingItems { get; set; }

        [Display(Order = 55)]
        [Enum(typeof(ContentSliderItemType))]
        [DefaultValue(ContentSliderItemType.Image)]
        public virtual ContentSliderItemType SliderItemType { get; set; }

        [Display(Order = 60)]
        [CultureSpecific(false)]
        [DefaultValue(true)]
        public virtual bool IsAutoSliding { get; set; }

        [Display(Order = 70)]
        [CultureSpecific(false)]
        [Range(1000, 10000)]
        [DefaultValue(5000)]
        public virtual int SlidingInterval { get; set; }
        
        [Ignore]
        public List<IContent> FilteredSlidingItems
        {
            get
            {                
                switch (SliderItemType)
                {
                    case ContentSliderItemType.Image:
                        return SlidingItems.GetItems<ImageFile>().Select(x => (IContent)x).ToList();
                    case ContentSliderItemType.Text:
                        return SlidingItems.GetItems<TextBlock>().Select(x => (IContent)x).ToList();                        
                }

                return new List<IContent>();
            }
        }
    }
}