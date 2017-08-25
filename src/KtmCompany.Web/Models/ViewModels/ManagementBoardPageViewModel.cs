using System.Collections.Generic;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class ManagementBoardPageViewModel
    {
        public ManagementBoardPage CurrentPage { get; set; }

        public IEnumerable<MemberPage> Members { get; set; }

        public ManagementBoardPageViewModel(ManagementBoardPage currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}