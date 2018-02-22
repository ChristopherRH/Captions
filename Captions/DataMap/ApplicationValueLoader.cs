using Captions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Captions.DataMap
{
    public class ApplicationValueLoader
    {
        
        public List<ApplicationValue> LoadApplicationValues()
        {
            return new List<ApplicationValue>
            {
                new ApplicationValue{Name="Salt", Value=GenerateSalt()}
            };

        }
        
        /// <summary>
        /// Generate a salt
        /// </summary>
        /// <returns></returns>
        private static string GenerateSalt()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return Encoding.UTF8.GetString(salt);
        }
    }
}