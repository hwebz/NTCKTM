using System.Web.Mvc;

namespace KtmCompany.Web.Static
{
    public class StaticHtmlController : Controller
    {
        // GET: StaticHtml
        public ActionResult Index()
        {            
            return View("~/Static/StaticHtml.cshtml");
        }    
        
        public ActionResult Release()
        {
            return View("~/Static/StaticHtmlRelease.cshtml");
        }   
    }
}