using System.Collections.Generic;
using EPiServer.Core;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class RelatedContentsBlockViewModel
    {
        public RelatedContentsBlock CurrentBlock { get; set; }

        public IEnumerable<EditorialPageBase> DynamicContents { get; set; }
    }
}