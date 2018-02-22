using Captions.Attributes;
using System.Security.Cryptography;
using System.Text;

namespace Captions.Service
{
    public class DataContextService
    {


        /// <summary>
        /// If the object has a HashAttribute, compute the hash before saving that object
        /// </summary>
        /// <param name="entity"></param>
        public static void ComputeHashes(object entity)
        {
            var type = entity.GetType();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    if (attr is HashAttribute hashAttr)
                    {
                        var propName = prop.Name;
                        var hashedValue = ComputeHash(prop.GetValue(entity, null) as string);

                        prop.SetValue(entity, hashedValue);
                    }
                }
            }
        }

        /// <summary>
        /// Compute hash
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string ComputeHash(string inputString)
        {
            var sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private static byte[] GetHash(string inputString)
        {
            var algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
    }
}