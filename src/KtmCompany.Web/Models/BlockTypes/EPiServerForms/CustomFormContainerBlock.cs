using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using Geta.EPi.Extensions.EditorDescriptors;
using KtmCompany.Web.Enums;
using KtmCompany.Web.Models.MediaTypes;
using KtmCompany.Web.Models.PageTypes;
using EPiServer;
using EPiServer.Web;

namespace KtmCompany.Web.Models.BlockTypes.EPiServerForms
{
    [ContentType(GUID = "bc64db0a-ef1a-4200-8629-2015ea960f5b", GroupName = GroupNames.CustomFormElements)]
    public class CustomFormContainerBlock : FormContainerBlock
    {
        [DefaultValue(2)]
        [Range(2, 4)]
        [Display(Order = 100)]
        public virtual int NumberOfColumns { get; set; }

        [Enum(typeof(FormType))]
        [Display(Order = 110)]
        public virtual FormType FormType { get; set; }

        [Display(Order = 130)]
        [CultureSpecific]
        public virtual string MessageHeadingAfterSubmit { get; set; }

        [Display(Order = 140)]
        [CultureSpecific]
        public virtual XhtmlString MessageAbstractAfterSubmit { get; set; }

        [ScaffoldColumn(false)]
        public override bool ShowSummarizedData
        {
            get { return base.ShowSummarizedData; }
            set { base.ShowSummarizedData = value; }
        }

        [ScaffoldColumn(false)]
        public override string ConfirmationMessage
        {
            get { return base.ConfirmationMessage; }
            set { base.ConfirmationMessage = value; }
        }

        [ScaffoldColumn(false)]
        public override Url RedirectToPage
        {
            get { return base.RedirectToPage; }
            set { base.RedirectToPage = value; }
        }

        [ScaffoldColumn(false)]
        public override XhtmlString SubmitSuccessMessage
        {
            get { return base.SubmitSuccessMessage; }
            set { base.SubmitSuccessMessage = value; }
        }

        [ScaffoldColumn(false)]
        public override bool ShowNavigationBar
        {
            get { return base.ShowNavigationBar; }
            set { base.ShowNavigationBar = value; }
        }

        [ScaffoldColumn(false)]
        public override bool AllowExposingDataFeeds
        {
            get { return base.AllowExposingDataFeeds; }
            set { base.AllowExposingDataFeeds = value; }
        }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            PropertyInfo[] properties = GetType().BaseType.GetProperties();

            foreach (var property in properties)
            {
                var defaultValueAttribute = property.GetAttribute<DefaultValueAttribute>();

                if (defaultValueAttribute != null)
                {
                    this[property.Name] = defaultValueAttribute.Value;
                }
            }
        }
    }
}