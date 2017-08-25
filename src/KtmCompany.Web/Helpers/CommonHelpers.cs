using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Framework.Localization;
using Geta.EPi.Extensions;

namespace KtmCompany.Web.Helpers
{
    public static class CommonHelpers
    {                         
        public static string Translate(string resurceKey)
        {
            string value;

            if (!LocalizationService.Current.TryGetString(resurceKey, out value))
            {
                value = resurceKey;
            }

            return value;
        }

        public static string TranslateFallback(string resurceKey, string fallbackValue = "")
        {
            string value;

            if (!LocalizationService.Current.TryGetString(resurceKey, out value))
            {
                value = fallbackValue;
            }

            return value;
        }

        public static string GetLeftBackgroundImage(ContentReference image)
        {
            return image.IsNullOrEmpty() 
                ? ConfigurationSettingHelpers.GetDefaultLeftBackgroundImage().IsNullOrEmpty() ? "/Frontend/KTM/images/caption-background.jpg" : ConfigurationSettingHelpers.GetDefaultLeftBackgroundImage().GetFriendlyUrl()
                : image.GetFriendlyUrl();
        }
        
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}