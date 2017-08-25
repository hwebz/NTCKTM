using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Forms.Helpers;
using KtmCompany.Web.Infrastructure.Extensions;
using KtmCompany.Web.Models.BlockTypes;

namespace KtmCompany.Web.Models.ViewModels
{
    public class StatisticInformationViewModel
    {
        public string Sign { get; set; }

        public double Number { get; set; }

        public string NumberDisplay { get; set; }

        public string Unit { get; set; }

        public string Title { get; set; }

        public ContentReference Image { get; set; }

        public string RightTitle { get; set; }

        public string CallToActionTitle { get; set; }

        public Url CallToAction { get; set; }

        public string ExternalSourceUrl { get; set; }

        public StatisticInformationBlock CurrentBlock { get; set; }

        public StatisticInformationViewModel(StatisticInformationBlock currentBlock)
        {
            if (currentBlock != null)
            {
                if(!currentBlock.ExternalSource.IsNullOrEmpty() && !string.IsNullOrEmpty(currentBlock.ExternalSource.GetUrlString()))
                {
                    ExternalSourceUrl = currentBlock.ExternalSource.GetUrlString();
                }
                Sign = currentBlock.Sign;
                Number = currentBlock.Number;
                Unit = currentBlock.Unit;
                Title = currentBlock.Title;
                Image = currentBlock.Image;
                RightTitle = currentBlock.RightTitle;
                CallToAction = currentBlock.CallToAction;
                CallToActionTitle = currentBlock.CallToActionTitle;
                CurrentBlock = currentBlock;
            }
        }
    }
}