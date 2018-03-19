using AutoMapper;
using Captions.Models;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

namespace Captions.Viewmodels
{
    public class PostListViewModel
    {

        /// <summary>
        /// default constructor
        /// </summary>
        public PostListViewModel()
        {
            Posts = new List<PostViewModel>();
        }

        public PostListViewModel(ICollection<Post> posts)
        {
            Posts = new List<PostViewModel>();
            posts.ForEach(x => Posts.Add(new PostViewModel(x)));
        }

        public ICollection<PostViewModel> Posts { get; set; }

    }
}