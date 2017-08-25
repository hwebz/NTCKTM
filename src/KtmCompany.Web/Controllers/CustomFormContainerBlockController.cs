using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using EPiServer.Forms.Configuration;
using EPiServer.Forms.Controllers;
using EPiServer.Forms.Core.Models;
using EPiServer.Forms.Helpers;
using EPiServer.Forms.Implementation;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Framework.Web.Resources;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using KtmCompany.Web.Models.BlockTypes.EPiServerForms;
using Microsoft.CSharp.RuntimeBinder;

namespace KtmCompany.Web.Controllers
{
    [TemplateDescriptor(AvailableWithoutTag = true, Default = true, ModelType = typeof (CustomFormContainerBlock),
        TemplateTypeCategory = TemplateTypeCategories.MvcPartialController)]
    public class CustomFormContainerBlockController : BlockController<CustomFormContainerBlock>
    {
#pragma warning disable 649
        private Injected<StepValidationHandler> _stepValidationHandler;
#pragma warning restore 649

        protected virtual int? GetCurrentStepIndex(CustomFormContainerBlock currentBlock, Guid expectedFormGuid)
        {
            if (currentBlock.Form.FormGuid == expectedFormGuid)
            {
                int result;
                if (int.TryParse(this.GetParamValue("__FormCurrentStepIndex"), out result))
                {
                    return result;
                }
            }
            if (currentBlock.Form.IsAllStepsAreNotLinked())
            {
                return 0;
            }
            var currentPageLink = FormsExtensions.GetCurrentPageLink();
            var num2 = 0;
            foreach (var step in currentBlock.Form.Steps)
            {
                if (currentPageLink.CompareToIgnoreWorkID(step.AttachedContentLink))
                {
                    return num2;
                }
                num2++;
            }
            return null;
        }

        private Guid GetExpectedFormGuid()
        {
            Guid empty;
            Guid.TryParse(this.GetParamValue("__FormGuid"), out empty);
            return empty;
        }

        protected virtual string GetFormSubmissionId(CustomFormContainerBlock currentBlock)
        {
            object obj2;
            var formSubmissionIdKey = currentBlock.GetFormSubmissionIdKey();
            if (TempData.TryGetValue(formSubmissionIdKey, out obj2))
            {
                TempData.Keep(formSubmissionIdKey);
                return (obj2 as string);
            }
            return this.GetParamValue("__FormSubmissionId");
        }

        public override ActionResult Index(CustomFormContainerBlock currentBlock)
        {
            var contextMode = ControllerContext.RequestContext.GetContextMode();
            var isDefaultOrPreview = (contextMode == ContextMode.Default) || (contextMode == ContextMode.Preview);
            if (isDefaultOrPreview)
            {
                var instance = ServiceLocator.Current.GetInstance<IRequiredClientResourceList>();
                var webResourceUrl = ModuleHelper.GetWebResourceUrl(typeof (FormContainerBlockController),
                    "EPiServer.Forms.ClientResources.ViewMode.EPiServerForms.css");
                var clientResource = new ClientResource
                {
                    Name = "EPiServerForms.css",
                    Dependencies = new List<string> {"EPiServerForms_prerequisite.js"},
                    ResourceType = ClientResourceType.Html,
                    InlineContent =
                        "<link rel='stylesheet' type='text/css' data-epiforms-resource='EPiServerForms.css' href='"
                        + webResourceUrl + "' />"
                };
                instance.Require(clientResource).AtHeader();

                if (!EPiServerFormsSection.Instance.WorkInNonJSMode)
                {
                    InitJs(instance);
                }
            }
            currentBlock.BuildFormModel();
            var result = PartialView("Blocks/EPiServerForms/CustomFormContainerBlock", currentBlock);

            if ((currentBlock.Form != null) && isDefaultOrPreview)
            {
                var expectedFormGuid = GetExpectedFormGuid();
                var currentStepIndex = GetCurrentStepIndex(currentBlock, expectedFormGuid);
                var formSubmissionId = GetFormSubmissionId(currentBlock);
                ViewBag.IsStepValidToDisplay = currentStepIndex.HasValue
                                               && _stepValidationHandler.Service.IsStepValidToDisplay(
                                                   new FormIdentity(), currentBlock, currentStepIndex.Value,
                                                   formSubmissionId);

                SetCurrentStepIndex(currentStepIndex);

                ViewBag.FormSubmissionId = formSubmissionId;
                ViewBag.ValidationFail = false;
                ViewBag.Submittable = false;
                ViewBag.Message = this.GetParamValue("__FormMessage");
                ViewBag.FormFinalized = IsFormFinalized(currentBlock, expectedFormGuid);
                if (currentBlock.Form.IsMalFormSteps())
                {
                    ViewBag.Message =
                        FormsExtensions.LocalizationService.GetString(
                            "/episerver/forms/viewmode/malformstepconfigruation");
                    return result;
                }

                if (IsFormFinalized())
                {
                    return result;
                }

                var submittableStatus = currentBlock.Form.GetSubmittableStatus(ControllerContext.HttpContext);
                ViewBag.Submittable = submittableStatus.Submittable;
                if (!submittableStatus.Submittable)
                {
                    ViewBag.Message = submittableStatus.Message;
                    return result;
                }
                ViewBag.ValidationFail = IsValidationFail(currentBlock, expectedFormGuid);
            }
            return result;
        }

        // Decompiled optimized code
        private bool IsFormFinalized()
        {
            var anotherFunc =
                CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None,
                    ExpressionType.IsTrue, typeof (FormContainerBlockController),
                    new[] {CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)}));
            bool isFormFinalized = !anotherFunc.Target(anotherFunc, !ViewBag.FormFinalized);
            //if (< Index > o__SiteContainer6.<> p__Site11 == null)
            //{
            //    < Index > o__SiteContainer6.<> p__Site11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(FormContainerBlockController), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            //}
            //if (!< Index > o__SiteContainer6.<> p__Site11.Target(< Index > o__SiteContainer6.<> p__Site11, !((dynamic)base.ViewBag).FormFinalized))
            //{
            //    return result;
            //}
            return isFormFinalized;
        }

        // Decompiled optimized code
        private void SetCurrentStepIndex(int? currentStepIndex)
        {
            var someFunc =
                CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None,
                    ExpressionType.IsTrue, typeof (FormContainerBlockController),
                    new[] {CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)}));
            ViewBag.CurrentStepIndex = someFunc.Target(someFunc, ViewBag.IsStepValidToDisplay) &&
                                       currentStepIndex.HasValue
                ? currentStepIndex.Value
                : -1;

            //if (< Index > o__SiteContainer6.<> p__Site9 == null)
            //{
            //    < Index > o__SiteContainer6.<> p__Site9 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(FormContainerBlockController), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            //}
            //ViewBag.CurrentStepIndex = < Index > o__SiteContainer6.<> p__Site9.Target(< Index > o__SiteContainer6.<> p__Site9, ViewBag.IsStepValidToDisplay) ? currentStepIndex.Value : -1;
        }

        private void InitJs(IRequiredClientResourceList instance)
        {
            List<string> scripts;
            List<string> css;
            var scriptContent = "var epi = epi||{}; epi.EPiServer = epi.EPiServer||{}; epi.EPiServer.Forms = epi.EPiServer.Forms||{};\r\nepi.EPiServer.Forms.InjectFormOwnJQuery = "
                                + EPiServerFormsSection.Instance.InjectFormOwnJQuery.ToString().ToLowerInvariant()
                                +
                                ";epi.EPiServer.Forms.OriginalJQuery = typeof jQuery !== 'undefined' ? jQuery : undefined;";
            instance.RequireScriptInline(scriptContent, "EPiServerForms_saveOriginalJQuery.js", new List<string>())
                .AtHeader();
            if (EPiServerFormsSection.Instance.InjectFormOwnJQuery)
            {
                var list2 = new List<string> {"EPiServerForms_saveOriginalJQuery.js"};
                instance.RequireScript(
                    ModuleHelper.GetWebResourceUrl(typeof (FormContainerBlockController),
                        "EPiServer.Forms.ClientResources.ViewMode.jquery-1.7.2.min.js"),
                    "Forms.jquery.js", list2).AtHeader();
            }
            var webResourceContent = ModuleHelper.GetWebResourceContent(typeof (FormContainerBlockController),
                "EPiServer.Forms.ClientResources.ViewMode.EPiServerForms_prerequisite.js");
            FormsExtensions.GetFormExternalResources(out scripts, out css);
            webResourceContent = webResourceContent
                .Replace("___CurrentPageLink___", FormsExtensions.GetCurrentPageLink().ToString())
                .Replace("___CurrentPageLanguage___", FormsExtensions.GetCurrentPageLanguage())
                .Replace("___ExternalScriptSources___", scripts.ToJson())
                .Replace("___ExternalCssSources___", css.ToJson())
                .Replace("___UploadExtensionBlackList___", FormsExtensions.GetUploadExtensionBlackList())
                .Replace("___Messages___", FormsExtensions.GetCommonMessages())
                .Replace("___LocalizedResources___", FormsExtensions.GetLocalizedResources().ToJson());
            var dependencies = new List<string> {"Forms.jquery.js"};
            instance.RequireScriptInline(webResourceContent, "EPiServerForms_prerequisite.js", dependencies).AtHeader();
            var list6 = new List<string>
            {
                "Forms.jquery.js",
                "EPiServerForms_prerequisite.js"
            };
            instance.RequireScript(
                ModuleHelper.GetWebResourceUrl(typeof (FormContainerBlockController),
                    "EPiServer.Forms.ClientResources.ViewMode.EPiServerForms.js"),
                "EPiServerForms.js", list6).AtFooter();
        }

        private bool IsFormFinalized(FormContainerBlock currentBlock, Guid expectedFormGuid)
        {
            bool flag;
            if ((currentBlock.Form.FormGuid != expectedFormGuid) || !IsSuccess())
            {
                return false;
            }
            bool.TryParse(this.GetParamValue("__FormFinalized"), out flag);
            return flag;
        }

        private bool IsSuccess()
        {
            bool flag;
            bool.TryParse(this.GetParamValue("__FormIsSuccess"), out flag);
            return flag;
        }

        private bool IsValidationFail(FormContainerBlock currentBlock, Guid expectedFormGuid)
        {
            bool flag;
            if ((currentBlock.Form.FormGuid != expectedFormGuid) || IsSuccess())
            {
                return false;
            }
            bool.TryParse(this.GetParamValue("__ValidationFail"), out flag);
            return flag;
        }
    }
}