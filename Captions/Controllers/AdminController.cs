using Captions.Attributes;
using Captions.Service;
using System;
using System.Linq;
using System.Web.Mvc;
using static Captions.Models.User;

namespace Captions.Controllers
{
    [UserAuthorization(UserRoles.Admin)]
    public class AdminController : BaseController
    {
        /// <summary>
        /// Index for admin
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create Caption View
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCaption()
        {
            return View();
        }

        /// <summary>
        /// Create Caption View
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCaption()
        {

            return View(DataContextService.ApplyEntitySorting(db.Captions.ToList()));
        }


        [HttpPost]
        public ActionResult UploadFiles()
        {
            try
            {
                foreach (var fileName in Request.Files)
                {
                    var caption = ImageService.UploadImage(Request.Files[fileName as string]);
                    db.Captions.Add(caption);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                // todo: return an error in some way
                return PartialView("Index");
            }

            // return success
            return PartialView("Index");
        }

        /// <summary>
        /// Deletes from the DB
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCaption(Guid Id)
        {
            var caption = db.Captions.Find(Id);
            if(caption != null)
            {
                db.Captions.Remove(caption);
                db.SaveChanges();
            }
            // return success
            return View("Index");
        }



    }
}