using System.ComponentModel;
using System.Reflection;
using Castle.Core.Internal;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace KtmCompany.Web.Models.BlockTypes
{
    public abstract class BlockDataBase : BlockData
    {
        public ContentReference ContentLink
        {
            get
            {
                // ReSharper disable once SuspiciousTypeConversion.Global. Fix for when local block.
                if (!(this is IContent))
                {
                    return ContentReference.EmptyReference;
                }

                // ReSharper disable once SuspiciousTypeConversion.Global
                return ((IContent)this).ContentLink;
            }
        }

        public string Name
        {
            get
            {
                // ReSharper disable once SuspiciousTypeConversion.Global. Fix for when local block.
                if (!(this is IContent))
                {
                    return string.Empty;
                }

                // ReSharper disable once SuspiciousTypeConversion.Global
                return ((IContent)this).Name;
            }
        }

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