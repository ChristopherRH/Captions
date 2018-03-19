using Captions.DataMap;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace Captions.Controllers
{
    public class BaseController : Controller
    {
        public DataContext db = new DataContext();

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            // return to home page with not authorized result in url
            if (filterContext.Exception is UnauthorizedAccessException)
            {
                var uri = new RedirectResult("/Home/Index?NotAuthorized=1");
                filterContext.Result = uri;
                filterContext.ExceptionHandled = true;
            }
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var notAuthorized = Request.QueryString.Get("NotAuthorized");
            if (!string.IsNullOrEmpty(notAuthorized))
            {
                ViewData.Add("error", "Not Authorized");
            }

        }
    }
}