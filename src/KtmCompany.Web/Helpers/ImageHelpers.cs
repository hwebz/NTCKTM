using EPiServer;
using KtmCompany.Web.Enums;

namespace KtmCompany.Web.Helpers
{
    public class ImageHelpers
    {
        public static string StandardPercentageCrop(string url, short percentage)
        {
            return PercentageCrop(url, (100 - percentage) / 2, 0, (100 + percentage) / 2);
        }
        public static string PercentageCrop(string url, int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            var urlBuilder = new UrlBuilder(url);
            urlBuilder.QueryCollection.Add("cropxunits", "100");
            urlBuilder.QueryCollection.Add("cropyunits", "100");
            urlBuilder.QueryCollection.Add("crop", string.Join(",",x1.ToString(), y1.ToString(), x2.ToString(), y2.ToString()));

            return urlBuilder.ToString();
        }
        public static string Resizing(string url, short size, byte quality = 100)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            var urlBuilder = new UrlBuilder(url);
            urlBuilder.QueryCollection.Add("maxwidth", size.ToString());
            urlBuilder.QueryCollection.Add("quality", quality.ToString());

            return urlBuilder.ToString();
        }

        public static string Resizing(string url, ImageWidth image)
        {
            return Resizing(url, (short)image);
        }

        public static string ResizingW36(string url)
        {
            return Resizing(url, ImageWidth.W36);
        }

        public static string ResizingW40(string url)
        {
            return Resizing(url, ImageWidth.W40);
        }

        public static string ResizingW60(string url)
        {
            return Resizing(url, ImageWidth.W60);
        }

        public static string ResizingW80(string url)
        {
            return Resizing(url, ImageWidth.W80);
        }

        public static string ResizingW100(string url)
        {
            return Resizing(url, ImageWidth.W100);
        }

        public static string ResizingW120(string url)
        {
            return Resizing(url, ImageWidth.W120);
        }

        public static string ResizingW240(string url)
        {
            return Resizing(url, ImageWidth.W240);
        }

        public static string ResizingW280(string url)
        {
            return Resizing(url, ImageWidth.W280);
        }

        public static string ResizingW300(string url)
        {
            return Resizing(url, ImageWidth.W300);
        }

        public static string ResizingW420(string url)
        {
            return Resizing(url, ImageWidth.W420);
        }

        public static string ResizingW480(string url)
        {
            return Resizing(url, ImageWidth.W480);
        }

        public static string ResizingW960(string url)
        {
            return Resizing(url, ImageWidth.W960);
        }

        public static string ResizingW1240(string url)
        {
            return Resizing(url, ImageWidth.W1240);
        }
    }
}