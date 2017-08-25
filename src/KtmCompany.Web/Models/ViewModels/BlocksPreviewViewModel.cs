using System.Collections.Generic;
using EPiServer.Core;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class BlocksPreviewViewModel
    {
        public BlocksPreviewViewModel(PageDataBase currentPage, IContent previewContent)
        {
            PreviewContent = previewContent;
            CurrentPage = currentPage;
            Areas = new List<PreviewArea>();
        }

        public PageDataBase CurrentPage { get; private set; }

        public IContent PreviewContent { get; set; }

        public List<PreviewArea> Areas { get; set; }

        public class PreviewArea
        {
            public bool Supported { get; set; }
            public string AreaName { get; set; }
            public string AreaTag { get; set; }
            public ContentArea ContentArea { get; set; }
        }
    }
}