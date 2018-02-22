namespace Captions.Models
{
    public class Caption : BaseModel
    {
        public string Title { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}