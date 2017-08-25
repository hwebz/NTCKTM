using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using System.ComponentModel;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "1b5108fe-370c-4bea-bea8-ce586c1fd8be", GroupName = GroupNames.Popular)]
    public class ArticlesBlock : BlockDataBase
    {
        [CultureSpecific(false)]
        [Display(Order = 40)]
        [DefaultValue(6)]
        [Range(1, 50)]
        public virtual int NumberOfArticles { get; set; }
    }
}