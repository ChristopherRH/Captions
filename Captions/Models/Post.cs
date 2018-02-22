using Captions.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Captions.Models
{
    public class Post : BaseModel
    {
        public Post()
        {
        }
        
        [StringLength(150)]
        public string PostTitle { get; set; }

        [StringLength(5000)]
        public string PostContent { get; set; }
        public string PostedBy { get; set; }
    }
}