using Captions.Models;
using System.Linq;
using System.Web.Mvc;
using static Captions.Service.DataContextService;
using System.Collections.Generic;

namespace Captions.Controllers
{
    public class PostController : BaseController
    {

        /// <summary>
        /// Index view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {            
            return View(ApplyEntitySorting(db.Posts.ToList(), sortOrder: SortOrder.Descening));
        }
    }
}
