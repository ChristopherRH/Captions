using Captions.DataMap;
using Captions.Service;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace Captions.Controllers
{
    public class BaseController : Controller
    {
        public DataContext db = new DataContext();

        /// <summary>
        /// When exception is thrown, check if authorization exception
        /// </summary>
        /// <param name="filterContext"></param>
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

        /// <summary>
        /// When an action is executed, this will intercept and check for authorization
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var notAuthorized = Request.QueryString.Get("NotAuthorized");
            if (!string.IsNullOrEmpty(notAuthorized))
            {
                ViewData.Add("error", "Not Authorized");
            }

        }

        /// <summary>
        /// For this Caption, get the image and return it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileContentResult GetImage(Guid id)
        {
            var caption = db.Captions.Find(id);
            return ImageService.GetImage(caption);
        }
    }
}