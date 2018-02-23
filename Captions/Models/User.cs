using Captions.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Captions.Models
{
    public class User : BaseModel
    {
        public User()
        {
        }

        public enum UserRoles
        {
            Member,
            Admin,
            Super
        }

        [StringLength(25)]
        [Index(IsUnique = true)]
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual UserRoles Role { get; set; }

        [Hash]
        [Required]
        public virtual string Password { get; set; }

    }
}