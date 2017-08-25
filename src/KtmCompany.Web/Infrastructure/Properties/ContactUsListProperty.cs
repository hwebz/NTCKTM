using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.PlugIn;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.EditorModels;

namespace KtmCompany.Web.Infrastructure.Properties
{
    [PropertyDefinitionTypePlugIn]
    public class ContactUsListProperty : PropertyListBase<ContactUs>
    {
    }
}