using System.Web.Mvc;
using Captions.Models;

namespace Captions.Service
{
    public class ImageService
    {
        /// <summary>
        /// For the specified Caption, get the image content and return it
        /// </summary>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static FileContentResult GetImage(Caption caption)
        {
            return caption.Data != null ? new FileContentResult(caption.Data, "image/jpeg") : null;
        }
    }
}