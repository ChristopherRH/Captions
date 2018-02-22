using System.Linq;
using System.Web.Mvc;
using Captions.Service;

namespace Captions.Controllers
{
    public class UserController : BaseController
    {

        /// <summary>
        /// Login Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Log user in
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users.SingleOrDefault(x => x.Name.Equals(username));
            if (user != null && LoginService.ValidateUserLogin(user, password))
            {
                Session[nameof(User)] = user.ID;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
