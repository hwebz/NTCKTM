using System.Collections.Generic;

namespace KtmCompany.Web.Models.ViewModels
{
    public class JobFilterViewModel
    {
        public Dictionary<string, string> JobPositions { get; set; }

        public Dictionary<string, string> Countries { get; set; }

        public string BaseUrl { get; set; }
    }
}