using System.Web.Mvc;
using Captions.Models;
using System.Web;
using System.IO;

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

        /// <summary>
        /// Uploads the file to the database
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Caption UploadImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var b = new BinaryReader(file.InputStream);
                var binData = b.ReadBytes(file.ContentLength);

                return new Caption
                {
                    Title = file.FileName,
                    ContentType = file.ContentType,
                    Data = binData
                };                
            }

            return null;
        }
    }
}