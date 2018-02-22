using Captions.DataMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Captions.Controllers
{
    public class BaseController : Controller
    {
        public DataContext db = new DataContext();

    }
}