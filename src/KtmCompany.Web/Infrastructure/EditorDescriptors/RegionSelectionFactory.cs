using System.Collections.Generic;
using System.Linq;
using EPiServer.Shell.ObjectEditing;

namespace KtmCompany.Web.Infrastructure.EditorDescriptors
{
    public class RegionSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var regionSelections = new List<ISelectItem> { new SelectItem() { Text = string.Empty, Value = string.Empty } };

            var regions = RegionManager.Current.LoadAllRegions();

            if (regions != null && regions.Any())
            {
                regionSelections.AddRange(regions.Select(region => new SelectItem() {Text = region.RegionName, Value = region.RegionId}));
            }
            return regionSelections;
        }
    }
}