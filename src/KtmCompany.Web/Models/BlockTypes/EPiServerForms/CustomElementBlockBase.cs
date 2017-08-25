using EPiServer.Core;

namespace KtmCompany.Web.Models.BlockTypes.EPiServerForms
{
    public class CustomElementBlockBase: ICustomElementBlockBase
    {
        public int ColumnIndex { get; set; }

        public bool FullRowWidth { get; set; }

        public IContent SourceContent { get; set; }
    }
}