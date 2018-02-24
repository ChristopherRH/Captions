using Captions.DataMap;
using System.Web.Mvc;

namespace Captions.Controllers
{
    public class BaseController : Controller
    {
        public DataContext db = new DataContext();

    }
}