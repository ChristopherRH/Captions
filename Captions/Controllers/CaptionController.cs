using Captions.Service;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using static Captions.Service.DataContextService;
using Captions.Viewmodels;
using WebGrease.Css.Extensions;

namespace Captions.Controllers
{
    public class CaptionController : BaseController
    {
        public ActionResult Index()
        {
            
            var vm = new CaptionListViewModel
            {
                CurrentPageNumber = 1,
                Captions = new List<CaptionViewModel>()
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
            var vm = new CaptionListViewModel
            {
                CurrentPageNumber = pageNumber + 1,
                Captions = Search(pageNumber)
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
        public ICollection<CaptionViewModel> Search(int pageNumber, int numItems = 16, string searchText = null)
        {
            var list = new List<CaptionViewModel>();

            if (!string.IsNullOrEmpty(searchText))
            {
                var search = db.Captions.Where(x => x.Title.Contains(searchText));
            }

            ApplyEntitySorting(db.Captions.ToList(), sortOrder: SortOrder.Descening)
                .Skip((pageNumber - 1) * numItems)
                .Take(numItems)
                .ForEach(c => list.Add(new CaptionViewModel(c)));

            return list;
        }
    }
}