using Captions.Models;

namespace Captions.Viewmodels
{
    public class CaptionViewModel : ViewModel
    {

        public CaptionViewModel(Caption caption, bool includeBlobs = false)
        {
            ID = caption.ID.ToString();
            Title = caption.Title;
            ContentType = caption.ContentType;

            if (includeBlobs)
            {
                Data = caption.Data;
            }

        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }

    }
}