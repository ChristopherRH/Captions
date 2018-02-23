using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Captions.Models
{
    public class Post : BaseModel
    {
        public Post()
        {
        }
        
        [StringLength(150)]
        [Required]
        public virtual string PostTitle { get; set; }

        [StringLength(5000)]
        [Required]
        public virtual string PostContent { get; set; }

        [Required]
        public virtual string PostedBy { get; set; }

        // The captions that this post has
        public virtual ICollection<Caption> Captions { get; set; }
    } 
}