using Captions.Models;

namespace Captions.Viewmodels
{
    public class CaptionViewModel : ViewModel
    {

        public CaptionViewModel(Caption caption)
        {
            ID = caption.ID.ToString();
            Title = caption.Title;
            ContentType = caption.ContentType;           
        }

        public string Title { get; set; }
        public string ContentType { get; set; }

    }
}