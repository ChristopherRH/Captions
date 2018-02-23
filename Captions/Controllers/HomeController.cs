using Captions.Service;
using System;
using System.Linq;
using System.Web.Mvc;
using static Captions.Service.DataContextService;

namespace Captions.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
            return View(ApplyEntitySorting(db.Captions.ToList(), sortOrder: SortOrder.Descening));
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