using Captions.Service;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Captions.Controllers
{
    public class CaptionController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Captions.ToList());
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