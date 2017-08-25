using System;
using System.Linq;

namespace KtmCompany.Web.Models.PersistentModels
{        
    public class GeoPoint
    {
        private string separator = ",";

        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public GeoPoint(string geoPointString)
        {
            var list = geoPointString.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (list.Any())
            {
                float longitude, latitude;                
                if (float.TryParse(list[0], out latitude))
                {
                    Latitude = latitude;
                }
                if (float.TryParse(list.ElementAtOrDefault(1), out longitude))
                {
                    Longitude = longitude;
                }
            }
        }
    }
}