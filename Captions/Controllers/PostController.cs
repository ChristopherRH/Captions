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
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var vm = new PostListViewModel
            {
                CurrentPageNumber = 1,
                Posts = new List<PostViewModel>(),
            };

            return View(vm);
        }

        /// <summary>
        /// The list page that should be appended to the main-content of the page
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            Int32.TryParse(Request.Params["page"], out var pageNumber);
            var vm = new PostListViewModel
            {
                CurrentPageNumber = pageNumber + 1,
                Posts = Search(pageNumber)
            };

            vm.EndOfSearch = Search(pageNumber + 1).Count == 0;
            return PartialView(vm);
        }

        /// <summary>
        /// Applying searching for the PostViewModel
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="numItems"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public ICollection<PostViewModel> Search(int pageNumber, int numItems = 10, string searchText = null)
        {
            var list = new List<PostViewModel>();

            if (!string.IsNullOrEmpty(searchText))
            {
                var search = db.Posts.Where(x => x.PostTitle.Contains(searchText));
            }

            ApplyEntitySorting(db.Posts.ToList(), sortOrder: SortOrder.Descening)
                .Skip((pageNumber - 1) * numItems)
                .Take(numItems)
                .ForEach(c => list.Add(new PostViewModel(c)));

            return list;
        }
    }
}
