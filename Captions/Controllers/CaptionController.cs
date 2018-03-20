﻿using Captions.Service;
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
            var list = new List<CaptionViewModel>();
            ApplyEntitySorting(db.Captions.ToList(), sortOrder: SortOrder.Descening).ForEach(c => list.Add(new CaptionViewModel(c)));

            var vm = new CaptionListViewModel
            {
                Captions = list
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