using Captions.Models;

namespace Captions.Viewmodels
{
    public class PostViewModel : ViewModel
    {

        public PostViewModel(Post post)
        {
            ID = post.ID.ToString();
            PostTitle = post.PostTitle;
            PostedBy = post.PostedBy;

        }
        
        public string ID { get; set; }
        public string PostTitle { get; set; }        
        public string PostContent { get; set; }        
        public string PostedBy { get; set; }
    }
}