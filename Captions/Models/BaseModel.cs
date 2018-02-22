using Captions.DataMap;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Captions.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Constructor, set created fields
        /// </summary>
        public BaseModel()
        {
            if (IsNew)
            {
                ID = Guid.NewGuid();
                CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (IsModified())
            {
                ModifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                ModifiedDate = null;
            }
        }

        public Guid ID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }

        // this entity is new
        [NotMapped]
        public bool IsNew => ID == Guid.Empty;


        /// <summary>
        /// Determine if the Model is being modified
        /// </summary>
        /// <returns></returns>
        public bool IsModified()
        {
            return IsNew ? new DataContext().Entry(this).Entity.IsModified() : false;
        }       
    }
}