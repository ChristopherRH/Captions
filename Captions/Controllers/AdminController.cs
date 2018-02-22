using Captions.Models;
using Captions.Service;
using System;
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
        public ActionResult UploadFiles()
        {
            var isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    // TODO: Probably want to move this into image service
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var b = new BinaryReader(file.InputStream);
                        var binData = b.ReadBytes(file.ContentLength);

                        var caption = new Caption
                        {
                            Title = file.FileName,
                            ContentType = file.ContentType,
                            Data = binData
                        };

                        db.Captions.Add(caption);
                        db.SaveChanges();

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            // since we are responding to a jquery trigger this content t
            if (isSavedSuccessfully)
            {
                return PartialView("Index");
            }
            else
            {
                return PartialView("Index");
            }
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