

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

        [StringLength(25)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Role { get; set; }

        [Hash]
        public string Password { get; set; }

    }
}