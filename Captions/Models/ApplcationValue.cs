using System.ComponentModel.DataAnnotations;
/// <summary>
/// Application values
/// </summary>
namespace Captions.Models
{
    public class ApplicationValue : BaseModel
    {
        public ApplicationValue()
        {

        }

        /// <summary>
        /// name of the application value
        /// </summary>
        [Required]
        public virtual string Name { get; set; }

        /// <summary>
        /// value of app
        /// </summary>
        public virtual string Value { get; set; }

    }
}