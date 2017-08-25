using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Find.Cms;
using EPiServer.Web;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(DisplayName = "Statement Block", GUID = "af61d70c-56d4-4a38-a5d4-2d6562bd02df", Description = "", GroupName = GroupNames.Data)]
    [IndexInContentAreas]
    public class StatementBlock : BlockDataBase
    {
        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 10)]
        [UIHint(UIHint.Textarea)]
        public virtual string Header
        {
            get
            {
                return this.GetPropertyValue(p => p.Header) ?? Name;
            }
            set
            {
                this.SetPropertyValue(p => p.Header, value);
            }
        }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 20)]
        [UIHint(UIHint.LongString)]
        public virtual string SubHeader { get; set; }
    }
}