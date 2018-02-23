using Captions.Attributes;
using Captions.Models;
using Captions.Service;
using System.Linq;
using System.Web.Mvc;
using static Captions.Models.User;
using static Captions.Service.DataContextService;
using System;
using System.Collections.Generic;

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
        public ActionResult CreatePost(string title, string content)
        {
            var post = new Post
            {
                PostTitle = title,
                PostContent = content,
                PostedBy = SecurityService.GetLoggedInUser().Name
            };

            //TODO: For now just add a random list of captions to the post
            post.Captions = GenerateRandomCaptions();

            db.Posts.Add(post);
            db.SaveChanges();

            // return success
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets a random list of captions, temporary.
        /// </summary>
        /// <returns></returns>
        private ICollection<Caption> GenerateRandomCaptions()
        {
            var captions = db.Captions;
            return captions.OrderBy(arg => Guid.NewGuid()).Take(5).ToList();
        }
    }
}