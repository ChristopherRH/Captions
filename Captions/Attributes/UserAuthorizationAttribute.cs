using Captions.DataMap;
using Captions.Models;
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
                var userId = filterContext.HttpContext.Session[nameof(User)];
                var user = new DataContext().Users.Find(userId);
                if (user != null && user.Role >= userRole)
                {

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