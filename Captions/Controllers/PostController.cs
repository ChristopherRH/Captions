using System.Linq;
using System.Web.Mvc;
using static Captions.Service.DataContextService;
using System.Collections.Generic;
using Captions.Viewmodels;
using WebGrease.Css.Extensions;
using System;
using Captions.Service;

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
            var list = new List<PostViewModel>();
            ApplyEntitySorting(db.Posts.ToList(), sortOrder: SortOrder.Descening).ForEach(c => list.Add(new PostViewModel(c)));

            var vm = new PostListViewModel
            {
                Posts = list
            };
            return View(vm);
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
