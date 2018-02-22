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
        public string Name { get; set; }
        public UserRoles Role { get; set; }

        [Hash]
        public string Password { get; set; }

    }
}