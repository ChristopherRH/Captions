using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Captions.Models
{
    public class Caption : BaseModel
    {
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string ContentType { get; set; }
        [Required]
        public virtual byte[] Data { get; set; }

        // The Posts that this caption is on
        public virtual ICollection<Post> Posts { get; set; }
    }
}