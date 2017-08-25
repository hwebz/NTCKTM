using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using KtmCompany.Web.Controllers;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(DisplayName = "SharePriceDataBlock", GUID = "c341cfa5-8def-4a8f-a068-3e409de8ac64", Description = "", GroupName = GroupNames.Other)]
    public class SharePriceDataBlock : BlockData
    {
        [Display(Order = 10)]
        [AllowedTypes(typeof(ExcelFile))]
        [CultureSpecific(true)]
        public virtual ContentReference ImportDataFile { get; set; }

        [Display(Order = 20)]
        [CultureSpecific(true)]
        public virtual string TableRemarks { get; set; }

        [Ignore]
        public List<SharePriceIndex> SharePriceIndexes { get; set; }

        [Ignore]
        public List<string> ColumnNames { get; set; }
    }
}