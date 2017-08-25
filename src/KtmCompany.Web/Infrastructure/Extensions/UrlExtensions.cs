using EPiServer;


namespace KtmCompany.Web.Infrastructure.Extensions
{
    public static class UrlExtensions
    {
        public static bool IsNullOrEmpty(this Url url)
        {
            return (url == null || url.IsEmpty());
        }

        public static string NormalizeUrl(this string urlLink)
        {
            if (string.IsNullOrEmpty(urlLink))
                return string.Empty;
            var url = new Url(urlLink);
            if (string.IsNullOrEmpty(url.Scheme))
            {
                return string.Format("http://{0}", urlLink);
            }
            return urlLink;
        }
    }
}