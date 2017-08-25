using System;
using System.Collections.Generic;
using System.Linq;

namespace KtmCompany.Web.Infrastructure
{
    public class RegionManager
    {
        private static Dictionary<string, RegionInfo> _singletonSupportedRegions = null;

        private static Dictionary<string, CountryInfo> _singletonSupportedCountries = null;

        private static object synRegion = new object();

        private static object synCountry = new object();

        private Dictionary<string, RegionInfo> _supportedRegions
        {
            get
            {
                if (_singletonSupportedRegions == null)
                {
                    lock (synRegion)
                    {
                        if (_singletonSupportedRegions == null)
                        {
                            var jsonText = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\JsonResources\regions.json");
                            _singletonSupportedRegions = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, RegionInfo>>(jsonText);
                        }
                    }
                }

                return _singletonSupportedRegions;
            }
        }

        private Dictionary<string, CountryInfo> _supportedCountries
        {
            get
            {
                if (_singletonSupportedCountries == null)
                {
                    lock (synCountry)
                    {
                        if (_singletonSupportedCountries == null)
                        {
                            _singletonSupportedCountries = new Dictionary<string, CountryInfo>();
                            if (_supportedRegions != null && _supportedRegions.Any())
                            {
                                var regions = _supportedRegions.Values;

                                foreach (var region in regions)
                                {
                                    if (region?.Countries != null && region.Countries.Any())
                                    {
                                        foreach (var country in region.Countries)
                                        {
                                            var countryKey = string.Format("{0}_{1}", region.RegionId, country.CountryId);
                                            if (!_singletonSupportedCountries.ContainsKey(countryKey))
                                            {
                                                country.CountryKey = countryKey;
                                                _singletonSupportedCountries.Add(countryKey, country);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                        
                return _singletonSupportedCountries;
            }
        }

        private static RegionManager _regionManager;

        public static RegionManager Current
        {
            get { return _regionManager ?? (_regionManager = new RegionManager()); }
            set { _regionManager = value; }
        }        

        public List<RegionInfo> LoadAllRegions()
        {
            return _supportedRegions?.Values.OrderBy(x => x.RegionName).ToList() ?? new List<RegionInfo>();
        }

        public List<CountryInfo> LoadAllCountries()
        {
            return _supportedCountries?.Values.OrderBy(x => x.CountryName).ToList() ?? new List<CountryInfo>();
        }

        public RegionInfo Get(string regionId)
        {
            if (_supportedRegions.ContainsKey(regionId))
                return _supportedRegions[regionId];
            return null;
        }

        public CountryInfo GetCountryInfo(string countryId)
        {
            if (_supportedCountries.ContainsKey(countryId))
                return _supportedCountries[countryId];
            return null;
        }
    }

    public class RegionInfo
    {
        public string RegionId { get; set; }
        public string RegionName { get; set; }        

        public List<LanguageInfo> SupportedLanguages { get; set; }
                
        public List<CountryInfo> Countries { get; set; }
    }

    public class CountryInfo
    {
        public string CountryKey { get; set; }

        public string CountryId { get; set; }

        public string CountryName { get; set; }        
    }

    public class LanguageInfo
    {
        public LanguageInfo(string langId, string langName)
        {
            LanguageId = langId;
            LanguageName = langName;
        }
        public string LanguageId { get; set; }

        public string LanguageName { get; set; }
    }
}