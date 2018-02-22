using Captions.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Initil user class for testing, will be removed when creating user login later
/// </summary>
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