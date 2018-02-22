using Captions.DataMap;
using Captions.Models;
using Captions.Service;
using System.Web.Mvc;
using static Captions.Models.User;

namespace Captions.Attributes
{
    public class UserAuthorizationAttribute : ActionFilterAttribute
    {
        private UserRoles userRole;

        public UserAuthorizationAttribute(UserRoles userRole)
        {
            this.userRole = userRole;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                var user = SecurityService.GetLoggedInUser();
                if (user != null && user.Role >= userRole)
                {
                    // do nothing for now
                }                    
                else
                {
                    // todo return an error for not authorized
                    filterContext.Result = new RedirectResult("/Home/Index");
                }
            }
        }
    }
}