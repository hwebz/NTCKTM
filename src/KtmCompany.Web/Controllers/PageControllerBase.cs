using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.SessionState;
using EPiServer.Core;
using EPiServer.Editor;
using EPiServer.Web.Mvc;
using Foundation.Core.Infrastructure.ActionResults;
using KtmCompany.Web.Models.PageTypes;
using Geta.EPi.Extensions;

namespace KtmCompany.Web.Controllers
{
    /// <summary>
    /// All controllers that renders pages should inherit from this class so that we can 
    /// apply action filters, such as for output caching site wide, should we want to.
    /// </summary>
    [SessionState(SessionStateBehavior.Disabled)]
    public abstract class PageControllerBase<T> : PageController<T> where T : PageDataBase
    {
        protected T CurrentPage
        {
            get
            {
                return PageContext.Page as T;
            }
        }

        protected StartPage StartPage
        {
            get
            {
                return ContentReference.StartPage.Get<StartPage>();
            }
        }

        [Obsolete("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.")]
        protected JsonResult Json<T>(T data)
        {
            throw new InvalidOperationException("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.");
        }

        protected StandardJsonResult JsonValidationError()
        {
            var result = new StandardJsonResult();

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }

        protected StandardJsonResult JsonError(string errorMessage)
        {
            var result = new StandardJsonResult();

            result.AddError(errorMessage);

            return result;
        }

        protected StandardJsonResult<T> JsonSuccess<T>(T data)
        {
            return new StandardJsonResult<T> { Data = data };
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            // don't throw 404 in edit mode
            if (!PageEditing.PageIsInEditMode)
            {
                if (PageContext.Page.StopPublish <= DateTime.Now)
                {
                    filterContext.Result = new HttpStatusCodeResult(404, "Not found");
                    return;
                }
            }

            base.OnAuthorization(filterContext);
        }
    }
}