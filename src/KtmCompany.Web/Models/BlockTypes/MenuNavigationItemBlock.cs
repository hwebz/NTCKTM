using System.ComponentModel.DataAnnotations;
using System.Linq;
using EPiServer;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Helpers;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web.Routing;
using Geta.EPi.Extensions;
using KtmCompany.Web.Infrastructure.Extensions;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "bb97fd00-68ff-47b6-9e13-f7097d262339", GroupName = GroupNames.Other)]
    public class MenuNavigationItemBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(Order = 10)]
        [Required]
        public virtual Url Link { get; set; }

        [CultureSpecific]
        [Display(Order = 20)]
        public virtual LinkItemCollection SubMenuItems { get; set; }

        [Ignore]
        public bool IsSelectedPage
        {
            get
            {
                var pageRouteHelper = ServiceLocator.Current.GetInstance<PageRouteHelper>();
                if (pageRouteHelper != null)
                {
                    var currentPage = pageRouteHelper.PageLink;
                    if (currentPage.IsNullOrEmpty())
                        return false;

                    if (!Link.IsNullOrEmpty())
                    {
                        if (Link.GetContentReference().CompareToIgnoreWorkID(currentPage))
                        {
                            return true;
                        }
                    }

                    if (SubMenuItems != null && SubMenuItems.Any())
                    {
                        if (SubMenuItems.Any(item => item.ToContentReference().CompareToIgnoreWorkID(currentPage)))
                        {
                            return true;
                        }
                    }
                }               
                return false;
            }
        }
    }
}