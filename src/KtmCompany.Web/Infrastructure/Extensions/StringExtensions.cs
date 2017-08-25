using System;
using System.Web;
using System.Web.Mvc;

namespace KtmCompany.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string StripPreviewText(this string source, int maxLength)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            if (source.Length <= maxLength)
                return source;
            source = source.Substring(0, maxLength);
            int count = source.Length > 15 ? 15 : source.Length - 1;
            int length = source.LastIndexOfAny(new char[5]
            {
                ' ',
                '.',
                ',',
                '!',
                '?'
            }, source.Length - 1, count);
            if (length >= 0)
                source = source.Substring(0, length);
            return source + " ...";
        }

        public static MvcHtmlString ToMultiLineHTMLText(this string source, int numOfBreaks = 2)
        {
            return string.IsNullOrEmpty(source) ? MvcHtmlString.Create("") : MvcHtmlString.Create(HttpUtility.HtmlDecode(source.Replace("\n", (numOfBreaks == 2) ? "<br><br>" : "<br>").Replace(Environment.NewLine, (numOfBreaks == 2) ? "<br><br>" : "<br>").Replace("\\n", (numOfBreaks == 2) ? "<br><br>" : "<br>")));
        }
    }
}