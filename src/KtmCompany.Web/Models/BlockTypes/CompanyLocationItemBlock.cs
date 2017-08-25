using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Web;
using Geta.EPi.Extensions.EditorDescriptors;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Models.BlockTypes.Common;
using KtmCompany.Web.Models.PageTypes;
using KtmCompany.Web.Models.PersistentModels;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(DisplayName = "Company Location Item Block", GUID = "9AB5B812-9EF2-427D-9776-C1E942C753A1", Description = "", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class CompanyLocationItemBlock : BlockDataBase
    {        
        [Display(Order = 10)]
        public virtual LocationBlock Location { get; set; }        

        [Display(Order = 30)]
        [CultureSpecific(false)]
        public virtual string City { get; set; }

        [Display(Order = 40)]
        [CultureSpecific(false)]
        [UIHint(UIHint.Textarea)]
        [Required]
        public virtual string AddressLine1 { get; set; }

        [Display(Order = 50)]
        [CultureSpecific(false)]
        [UIHint(UIHint.Textarea)]
        public virtual string AddressLine2 { get; set; }        

        [Display(Order = 60)]
        [CultureSpecific(false)]
        public virtual string PhoneNumber { get; set; }

        [Display(Order = 70)]
        [CultureSpecific(false)]
        public virtual string FaxNumber { get; set; }

        [Display(Order = 75)]
        [CultureSpecific(false)]
        public virtual string Email { get; set; }

        [Display(Order = 80)]
        [CultureSpecific(false)]
        public virtual string Website { get; set; }

        [Display(Order = 90)]
        [CultureSpecific(false)]        
        [UIHint(SiteUIHint.GeoPointSelector)]
        [Required]
        public virtual string GeoLocationString { get; set; }
                
        public GeoPoint GeoLocation => new GeoPoint(GeoLocationString);

        [Display(Order = 100)]
        [Enum(typeof(GoogleMapMarker))]
        public virtual GoogleMapMarker GoogleMapMarker { get; set; }

        [Display(Order = 110)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference LeftBackgroundImage { get; set; }
    }
}