using System.Linq;
using System.Web.Mvc;

namespace Captions.Controllers
{
    public class PostController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }       
    }
}