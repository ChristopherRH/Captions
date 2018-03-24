using Captions.Models;
using System;
using System.Web;

namespace Captions.Viewmodels
{
    public class PostViewModel : ViewModel
    {

        public PostViewModel(Post post)
        {
            ID = post.ID.ToString();
            PostTitle = post.PostTitle;
            PostedBy = post.PostedBy;
            PostContent = HttpUtility.UrlDecode(post.PostContent);
            CreatedDate = Convert.ToDateTime(post.CreatedDate).AddDays(-1).ToString("dddd, MMMM dd, yyyy"); // off by 1 day, figure out why later
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