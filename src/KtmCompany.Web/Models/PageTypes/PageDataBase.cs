using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Infrastructure.Attributes;

namespace KtmCompany.Web.Models.PageTypes
{
    public abstract class PageDataBase : PageData
    {
        [Display(GroupName = SystemTabNames.Content, Order = 10)]
        [CategorySelectOne(CategoryConstants.AllCategory)]
        [UIHint(SiteUIHint.CategorySelectOne)]
        public virtual string ContentCategory { get; set; }

        [Display(Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string Heading
        {
            get
            {
                return this.GetPropertyValue(p => p.Heading) ?? PageName;
            }
            set
            {
                this.SetPropertyValue(p => p.Heading, value);
            }
        }

        [Display(Order = 45)]
        [UIHint(UIHint.LongString)]
        [CultureSpecific]
        public virtual string MainIntro { get; set; }

        [Display(GroupName = GroupNames.Seo, Order = 100)]
        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {
                return this.GetPropertyValue(p => p.MetaTitle) ?? Heading;
            }
            set { this.SetPropertyValue(p => p.MetaTitle, value); }
        }

        [Display(GroupName = GroupNames.Seo, Order = 300)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string MetaDescription { get; set; }

        [Display(GroupName = GroupNames.Seo, Order = 400)]
        [CultureSpecific]
        public virtual bool HideFromSearch { get; set; }

        /// <summary>
        /// Adds the posibility to use DefaultValue attribute on properties instead of having to override the SetDefaultValues method.
        /// Source: http://world.episerver.com/Blogs/Per-Magne-Skuseth/Dates/2014/3/Attribute-based-default-values/ 
        /// </summary>
        /// <param name="contentType"></param>
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