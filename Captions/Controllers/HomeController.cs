using Captions.Service;
using Captions.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebGrease.Css.Extensions;
using static Captions.Service.DataContextService;

namespace Captions.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var list = new List<CaptionViewModel>();
            ApplyEntitySorting(db.Captions.ToList(), sortOrder: SortOrder.Descening).ForEach(c => list.Add(new CaptionViewModel(c)));

            var vm = new CaptionListViewModel
            {
                Captions = list
            };
            return View(vm);
        }
    }
}