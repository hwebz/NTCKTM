using EPiServer.Core;
using Geta.EPi.Extensions;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Models.BlockTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class CompanyLocationItemViewModel
    {
        public string Name { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }
        
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public GoogleMapMarker GoogleMapMarker { get; set; }

        public string LeftBackgroundImage { get; set; }

        public CompanyLocationItemViewModel(CompanyLocationItemBlock currentBlock)
        {
            this.Name = currentBlock.Name;

            if (currentBlock.Location != null)
            {
                if (!string.IsNullOrEmpty(currentBlock.Location.Region))
                {
                    var region = RegionManager.Current.Get(currentBlock.Location.Region);
                    if (region != null)
                    {
                        this.Region = region.RegionName;
                    }
                }
                if (!string.IsNullOrEmpty(currentBlock.Location.Country))
                {
                    var country = RegionManager.Current.GetCountryInfo(currentBlock.Location.Country);
                    if (country != null)
                    {
                        this.Country = country.CountryName;
                    }
                }
            }
                        
            this.City = currentBlock.City;
            this.AddressLine1 = currentBlock.AddressLine1;
            this.AddressLine2 = currentBlock.AddressLine2;
            this.PhoneNumber = currentBlock.PhoneNumber;
            this.FaxNumber = currentBlock.FaxNumber;
            this.Email = currentBlock.Email;
            this.Website = currentBlock.Website;
            this.Latitude = currentBlock.GeoLocation.Latitude;
            this.Longitude = currentBlock.GeoLocation.Longitude;
            this.GoogleMapMarker = currentBlock.GoogleMapMarker;
            this.LeftBackgroundImage = currentBlock.LeftBackgroundImage.IsNullOrEmpty() ? "" : currentBlock.LeftBackgroundImage.GetFriendlyUrl();
        }
    }
}