using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using KtmCompany.Web.Models.EditorModels;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Models.BlockTypes.Common
{
    [ContentType(GUID = "dca5c624-d190-4e54-88d7-b51798adb13f", AvailableInEditMode = false)]
    public class HeaderBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [CultureSpecific(false)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference LogoImage { get; set; }

        //[Display(
        //    GroupName = SystemTabNames.Content, 
        //    Order = 40)]        
        //[AllowedTypes(typeof(MenuNavigationItemBlock))]
        //public virtual ContentArea MainNavigation { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [CultureSpecific(false)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<LogoLinkItem>))]
        public virtual IList<LogoLinkItem> BrandLogoLinks { get; set; }
    }
}