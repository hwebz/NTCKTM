using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.PageTypes;
using System.Collections.Generic;

namespace KtmCompany.Web.Models.ViewModels
{
    public class ArticlesBlockViewModel
    {
        public ArticlesBlock CurrentBlock { get; set; }
        public IEnumerable<ArticlePage> Articles { get; set; }
    }
}