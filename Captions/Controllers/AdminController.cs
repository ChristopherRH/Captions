using Captions.Models;
using Captions.Service;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Captions.Controllers
{
    public class AdminController : BaseController
    {
        /// <summary>
        /// Index for admin
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (UserAuthorized())
            {
                return View();
            }
            throw new HttpException(401, "Not Authorized");
        }

        /// <summary>
        /// Login Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            if (postedFile != null)
            {
                BinaryReader b = new BinaryReader(postedFile.InputStream);
                byte[] binData = b.ReadBytes(postedFile.ContentLength);

                var caption = new Caption
                {
                    Title = postedFile.FileName,
                    ContentType = postedFile.ContentType,
                    Data = binData
                };

                db.Captions.Add(caption);
                db.SaveChanges();
                ViewBag.Message = "File uploaded successfully.";
            }

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
            if(user != null && LoginService.ValidateUserLogin(user, password))
            {
                Session[nameof(User)] = user.ID;
            }
            return Redirect("Index");
        }

        /// <summary>
        /// Check to see if the logged in user is authorized, or false if not logged in.
        /// </summary>
        /// <returns></returns>
        private bool UserAuthorized()
        {
            var authorized = false;
            var userId = Session[nameof(User)];
            var user = db.Users.Find(userId);
            
            if (user != null && user.Role.Equals("Admin"))
            {
                authorized = true;
            }

            return authorized;
        }
    }
}