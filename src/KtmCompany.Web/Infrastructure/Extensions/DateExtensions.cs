using System;
using System.Globalization;
using EPiServer.Globalization;
using KtmCompany.Web.Helpers;

namespace KtmCompany.Web.Infrastructure.Extensions
{
    public static class DateExtensions
    {
        public static string ToGenericFormatDateString(this DateTime dateTime)
        {
            var formatString = CommonHelpers.TranslateFallback("/format/datetime/publishdate", "dd MMMM yyyy");
            //store dbDateTime in the database
            DateTime dbDateTime = dateTime.ToUniversalTime();

            //get date time offset for UTC date stored in the database
            DateTimeOffset dbDateTimeOffset = new DateTimeOffset(dbDateTime, TimeSpan.Zero);

            //get user's time zone from profile stored in the database
            TimeZoneInfo userTimeZone = TimeZoneInfo.Local;

            //convert  db offset to user offset
            DateTimeOffset userDateTimeOffset = TimeZoneInfo.ConvertTime(dbDateTimeOffset, userTimeZone);
            
            return userDateTimeOffset.ToString(formatString);
        }
    }
}