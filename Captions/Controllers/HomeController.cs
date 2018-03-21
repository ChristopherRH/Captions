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
            var list = new List<PostViewModel>();
            ApplyEntitySorting(db.Posts.ToList(), sortOrder: SortOrder.Descening).ForEach(c => list.Add(new PostViewModel(c)));

            var vm = new PostListViewModel
            {
                Posts = list
            };
            return View(vm);
        }
    }
}