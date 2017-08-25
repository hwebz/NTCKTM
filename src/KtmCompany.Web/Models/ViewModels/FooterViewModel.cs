using EPiServer.SpecializedProperties;

namespace KtmCompany.Web.Models.ViewModels
{
    public class FooterViewModel
    {
        public string CompanyName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string CopyrightInfo { get; set; }

        public LinkItemCollection FooterColumn1Links { get; set; }

        public LinkItemCollection FooterColumn2Links { get; set; }

        public LinkItemCollection FooterColumn3Links { get; set; }

        public LinkItemCollection FooterBottomLinks { get; set; }
    }
}