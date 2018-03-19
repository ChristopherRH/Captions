using Captions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Captions.Viewmodels
{
    public class AdminViewModel
    {

        public AdminViewModel(ICollection<Caption> captions, ICollection<Post> posts)
        {
            Captions = new CaptionListViewModel(captions);
            Posts = new PostListViewModel(posts);
        }

        // Captions
        public CaptionListViewModel Captions { get; set; }

        // Posts
        public PostListViewModel Posts { get; set; }

    }
}