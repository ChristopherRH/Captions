using Captions.Models;
using System;

namespace Captions.Viewmodels
{
    public class PostViewModel : ViewModel
    {

        public PostViewModel(Post post)
        {
            ID = post.ID.ToString();
            PostTitle = post.PostTitle;
            PostedBy = post.PostedBy;
            PostContent = post.PostContent;
            CreatedDate = Convert.ToDateTime(post.CreatedDate).ToString("dddd, MMMM dd, yyyy");
            Captions = new CaptionListViewModel(post.Captions);
        }
        
        public string PostTitle { get; set; }        
        public string PostContent { get; set; }        
        public string PostedBy { get; set; }
        public string CreatedDate { get; set; }

        // The captions that this post has
        public virtual CaptionListViewModel Captions { get; set; }

    }
}