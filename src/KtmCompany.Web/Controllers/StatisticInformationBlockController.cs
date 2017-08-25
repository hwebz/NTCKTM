using System.Globalization;
using System.Web.Mvc;
using System.Xml.Linq;
using EPiServer.Web.Mvc;
using Geta.EPi.Extensions;
using KtmCompany.Web.Infrastructure.Extensions;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.ViewModels;

namespace KtmCompany.Web.Controllers
{
    public class StatisticInformationBlockController : BlockController<StatisticInformationBlock>
    {
        public override ActionResult Index(StatisticInformationBlock currentBlock)
        {
            var model = new StatisticInformationViewModel(currentBlock);
            if (!currentBlock.ExternalSource.IsNullOrEmpty())
            {
                var externalSourceUrl = currentBlock.ExternalSource.GetFriendlyUrl();
                if (!string.IsNullOrEmpty(externalSourceUrl))
                {
                    var document = XDocument.Load(externalSourceUrl);
                    var items = document.Elements().Elements().Elements();
                    var dateLastPrice = "";
                    var timeLastPrice = "";
                    var changeAbsolute = "";
                    foreach (var item in items)
                    {
                        var name = item.Name.LocalName;
                        var value = item.Value.Trim();
                        switch (name)
                        {
                            case "name":
                                model.Title = value;
                                break;
                            case "currency":
                                foreach (var nfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                                {
                                    var region = new RegionInfo(nfo.LCID);
                                    if (region.ISOCurrencySymbol == value.ToUpper())
                                    {
                                        model.Unit = region.CurrencySymbol;
                                        break;
                                    }
                                }
                                break;
                            case "date_last_price":
                                dateLastPrice = value;
                                break;
                            case "time_last_price":
                                timeLastPrice = value;
                                break;
                            case "last_price":
                                model.NumberDisplay = value;
                                break;
                            case "change_absolute":
                                changeAbsolute = value;
                                model.Sign = !string.IsNullOrEmpty(value) && value.Length > 0 && value[0] == '-'
                                    ? "-"
                                    : "+";
                                break;
                            case "isin":
                            case "exchange":
                            case "change_relative":
                                break;
                        }
                    }
                    model.RightTitle = string.Format("{0}\n{1}\n{2}{3}", dateLastPrice, timeLastPrice, changeAbsolute, model.Unit);
                }
            }
            return PartialView(model);
        }
    }
}