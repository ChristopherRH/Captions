using Captions.Attributes;
using Captions.Models;
using Captions.Service;
using System.Linq;
using System.Web.Mvc;
using static Captions.Models.User;
using static Captions.Service.DataContextService;
using System;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

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

        /// <summary>
        /// Create view
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Craete the post
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        [UserAuthorization(UserRoles.Admin)]
        public ActionResult CreatePost(string title, string content, Guid[] id)
        {
            var post = new Post
            {
                PostTitle = title,
                PostContent = content,
                PostedBy = SecurityService.GetLoggedInUser().Name,
                Captions = new List<Caption>()
            };

            id.ForEach(x => post.Captions.Add(db.Captions.Find(x)));

            db.Posts.Add(post);
            db.SaveChanges();

            // return success
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets all captions
        /// </summary>
        /// <returns></returns>
        public ICollection<Caption> GetCaptions()
        {
            return ApplyEntitySorting(db.Captions.ToList()).ToList();
        }
    }
}
