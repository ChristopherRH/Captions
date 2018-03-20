using Captions.Attributes;
using Captions.Models;
using Captions.RenderUtilities;
using Captions.Service;
using Captions.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebGrease.Css.Extensions;
using static Captions.Models.User;

namespace Captions.Controllers
{
    [UserAuthorization(UserRoles.Admin)]
    public class AdminController : BaseController
    {
        /// <summary>
        /// Index for admin
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create Caption View
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadCaption()
        {
            return PartialView("UploadCaption");
        }

        /// <summary>
        /// Create Post View
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatePost()
        {
            var list = new List<CaptionViewModel>();
            DataContextService.ApplyEntitySorting(db.Captions.ToList()).ForEach(c => list.Add(new CaptionViewModel(c)));

            var vm = new CaptionListViewModel
            {
                Captions = list
            };
            return PartialView("CreatePost", vm);
        }

        /// <summary>
        /// Delete Caption View
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCaption()
        {
            var list = new List<CaptionViewModel>();
            DataContextService.ApplyEntitySorting(db.Captions.ToList()).ForEach(c => list.Add(new CaptionViewModel(c)));

            var vm = new CaptionListViewModel
            {
                Captions = list
            };
            return PartialView("DeleteCaption", vm);
        }

        /// <summary>
        /// Delete Post View
        /// </summary>
        /// <returns></returns>
        public ActionResult DeletePost()
        {
            var list = new List<PostViewModel>();
            DataContextService.ApplyEntitySorting(db.Posts.ToList()).ForEach(c => list.Add(new PostViewModel(c)));

            var vm = new PostListViewModel
            {
                Posts = list
            };
            return PartialView("DeletePost", vm);
        }

        #region HTTP Methods
        
        [HttpPost]
        public JsonResult UploadFiles()
        {
            var success = true;
            try
            {
                foreach (var fileName in Request.Files)
                {
                    var caption = ImageService.UploadImage(Request.Files[fileName as string]);
                    db.Captions.Add(caption);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                success = false;
            }

            // return success
            var str = RenderPartialToStringExtensions.RenderPartialToString(ControllerContext, "UploadCaption", null);
            var result = new
            {
                Success = success,
                Data = str
            };

            return Json(result);
        }

        /// <summary>
        /// Deletes from the DB
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteCaption(Guid Id)
        {
            var caption = db.Captions.Find(Id);
            if(caption != null)
            {
                db.Captions.Remove(caption);
                db.SaveChanges();
            }

            // return success
            var list = new List<CaptionViewModel>();
            DataContextService.ApplyEntitySorting(db.Captions.ToList()).ForEach(c => list.Add(new CaptionViewModel(c)));

            var vm = new CaptionListViewModel
            {
                Captions = list
            };
            var str = RenderPartialToStringExtensions.RenderPartialToString(ControllerContext, "DeleteCaption", vm);
            var result = new
            {
                Data = str,
                Success = true
            };
            return Json(result);
        }

        /// <summary>
        /// Deletes from the DB
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeletePost(Guid Id)
        {
            var post = db.Posts.Find(Id);
            if (post != null)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }

            // return success
            var list = new List<PostViewModel>();
            DataContextService.ApplyEntitySorting(db.Posts.ToList()).ForEach(c => list.Add(new PostViewModel(c)));

            var vm = new PostListViewModel
            {
                Posts = list
            };
            var str = RenderPartialToStringExtensions.RenderPartialToString(ControllerContext, "DeletePost", vm);
            var result = new
            {
                Data = str,
                Success = true
            };
            return Json(result);
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

            foreach(var capId in id)
            {
                var cap = db.Captions.Find(capId);
                if(cap != null)
                {
                    post.Captions.Add(cap);
                }
            }

            db.Posts.Add(post);
            db.SaveChanges();

            // return success
            var list = new List<CaptionViewModel>();
            DataContextService.ApplyEntitySorting(db.Captions.ToList()).ForEach(c => list.Add(new CaptionViewModel(c)));

            var vm = new CaptionListViewModel
            {
                Captions = list
            };
            var str = RenderPartialToStringExtensions.RenderPartialToString(ControllerContext, "CreatePost", vm);
            var result = new
            {
                Data = str,
                Success = true
            };
            return Json(result);


        }

        #endregion
    }
}