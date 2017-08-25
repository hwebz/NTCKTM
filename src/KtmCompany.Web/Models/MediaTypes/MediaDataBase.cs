using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace KtmCompany.Web.Models.MediaTypes
{
    public abstract class MediaDataBase: MediaData
    {
        [Display(Order = 10)]
        [CultureSpecific(true)]
        public virtual string Title
        {
            get
            {
                return this.GetPropertyValue(p => p.Title) ?? Name;
            }
            set
            {
                this.SetPropertyValue(p => p.Title, value);
            }
        }

        [Display(Name = "File size in kb", Order = 30)]
        [Editable(false)]
        public virtual int FileSizeInKb { get; set; }

        [Display(Name = "Publish Date", Order = 100)]
        public virtual DateTime? PublishDate { get; set; }
    }
}