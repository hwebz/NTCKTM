using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Helpers;
using KtmCompany.Web.Models.PageTypes;

namespace KtmCompany.Web.Models.BlockTypes
{
    [ContentType(GUID = "248c265e-bbcc-42d6-81ab-3b7da5878389", GroupName = GroupNames.Other)]
    public class IFrameContentBlock : BlockDataBase
    {
        private string defaultFrameSource = "http://charts25.equitystory.com/clients/ktm/";
        [CultureSpecific]
        [Display(Order = 100)]
        public virtual Url IFrameSource
        {
            get
            {
                var frameSource = this.GetPropertyValue(p => p.IFrameSource).GetUrlString();
                return String.IsNullOrWhiteSpace(frameSource) ? defaultFrameSource : frameSource;
            }
            set
            {
                this.SetPropertyValue(p=>p.IFrameSource, value);
            }
        }

    }
}