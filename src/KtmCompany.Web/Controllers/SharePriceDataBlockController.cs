using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using KtmCompany.Web.Models.BlockTypes;
using EPiServer.Find.Cms;
using Excel;
using Geta.EPi.Extensions;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Controllers
{
    public class SharePriceDataBlockController : BlockController<SharePriceDataBlock>
    {
        public override ActionResult Index(SharePriceDataBlock currentContent)
        {
            List<string> columnNames;
            currentContent.SharePriceIndexes = LoadSharePriceData(currentContent.ImportDataFile, out columnNames);
            currentContent.ColumnNames = columnNames;
            return PartialView(currentContent);
        }

        private List<SharePriceIndex> LoadSharePriceData(ContentReference importDataFile, out List<string> columnNames)
        {
            var result = new List<SharePriceIndex>();
            columnNames = new List<string>();
            if (!importDataFile.IsNullOrEmpty())
            {
                var dataFileContent = importDataFile.Get<IContent>() as ExcelFile;                
                if (dataFileContent != null)
                {
                    var fileExtension = dataFileContent.SearchFileExtension();
                    if (fileExtension == "xls" || fileExtension == "xlsx")
                    {
                        using (var stream = dataFileContent.BinaryData.OpenRead())
                        {
                            var excelReader = fileExtension == "xls" ? ExcelReaderFactory.CreateBinaryReader(stream) : ExcelReaderFactory.CreateOpenXmlReader(stream);

                            excelReader.IsFirstRowAsColumnNames = true;
                            DataSet importData = excelReader.AsDataSet();

                            if (importData != null && importData.Tables.Count > 0)
                            {
                                var importDataTable = importData.Tables[0];
                                if (importDataTable.Columns.Count > 0)
                                {
                                    columnNames.AddRange(from DataColumn column in importDataTable.Columns select column.ColumnName);
                                }                                
                                foreach (DataRow dataRow in importDataTable.Rows)
                                {
                                    var sharePriceIndex = new SharePriceIndex();
                                    var sharePriceIndexData = new List<SharePriceIndexData>();
                                    for (var i = 0; i < importDataTable.Columns.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                            sharePriceIndex.IndexName = dataRow[i]?.ToString();
                                        }
                                        else
                                        {
                                            sharePriceIndexData.Add(new SharePriceIndexData() {Time = columnNames[i], Value = dataRow[i]?.ToString()});
                                        }
                                    }
                                    sharePriceIndex.Data = sharePriceIndexData;
                                    if (!string.IsNullOrEmpty(sharePriceIndex.IndexName))
                                    {
                                        result.Add(sharePriceIndex);
                                    }                                    
                                }
                            }
                                                              
                            excelReader.Close();
                        }
                    }
                                                          
                }
            }
            return result;
        }
    }

    public class SharePriceIndex
    {
        public string IndexName { get; set; }
        public List<SharePriceIndexData> Data { get; set; }
    }

    public class SharePriceIndexData
    {
        public string Time { get; set; }
        public string Value { get; set; }
    }
}
