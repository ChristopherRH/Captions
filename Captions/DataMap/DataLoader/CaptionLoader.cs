using Captions.Models;
using System.Collections.Generic;
using System;
using System.IO;

namespace Captions.DataMap.DataLoader
{
    public class CaptionLoader
    {
        
        public List<Caption> LoadCaptions()
        {
            var captions = CreateCaptions(100);
            return captions;          
        }


        /// <summary>
        /// Creates captions using images stored in the Image folder
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private List<Caption> CreateCaptions(int number)
        {
            var captions = new List<Caption>();
            //todo: Don't hardcode this...
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = desktop + @"\Anime";
            var exists = Directory.Exists(path);
            if (exists)
            {
                var files = Directory.GetFiles(path);
                var max = files.Length - 1;
                var start = new Random().Next(0, max - number);
                for (var i = 0; i < number; i++)
                {
                    var file = files[i + start];
                    var fileInfo = new FileInfo(Path.Combine(path, file));
                    var data = new byte[fileInfo.Length];
                    using (var fs = fileInfo.OpenRead())
                    {
                        fs.Read(data, 0, data.Length);
                    }                   

                    var caption =  new Caption
                    {
                        Title = fileInfo.Name,
                        ContentType = "image/png",
                        Data = data
                    };

                    captions.Add(caption);
                }
            }
            return captions;
        }
    }
}