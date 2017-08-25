using System.Collections.Generic;
using System.Linq;
using EPiServer.Shell.ObjectEditing;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    public class CountrySelectionFactory: ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var countrySelections = new List<ISelectItem> {new SelectItem() {Text = string.Empty, Value = string.Empty}};

            var countries = RegionManager.Current.LoadAllCountries();
            
            if (countries != null && countries.Any())
            {
                countrySelections.AddRange(countries.Select(country => new SelectItem() { Text = country.CountryName, Value = country.CountryKey }));
            }

            return countrySelections.OrderBy(x => x.Text);            
        }
    }
}