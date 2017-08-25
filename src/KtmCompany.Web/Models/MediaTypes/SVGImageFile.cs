using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Blobs;
using EPiServer.Framework.DataAnnotations;

namespace KtmCompany.Web.Models.MediaTypes
{
    [ContentType(GUID = "adc2aa28-6bc9-443d-975b-e551384e86be")]
    [MediaDescriptor(ExtensionString = "svg")]
    public class SVGImageFile :  ImageData
    {
        [CultureSpecific]
        public virtual string Description { get; set; }
        
        /// <summary>
        /// Gets the generated thumbnail for this media.
        /// </summary>
        public override Blob Thumbnail
        {
            get { return BinaryData; }
        }
    }
}