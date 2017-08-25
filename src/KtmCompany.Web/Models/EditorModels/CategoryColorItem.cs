using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using KtmCompany.Web.Infrastructure;
using KtmCompany.Web.Infrastructure.Attributes;

namespace KtmCompany.Web.Models.EditorModels
{
    public class CategoryColorItem
    {
        [CategorySelectOne(CategoryConstants.AllCategory)]
        [UIHint(SiteUIHint.CategorySelectOne)]
        [Required]
        public virtual string Category { get; set; }

        [ClientEditor(ClientEditingClass = "app.editors.ColorPicker")]
        [Required]
        public virtual string Color { get; set; }
    }
}