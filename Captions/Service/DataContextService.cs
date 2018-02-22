using Captions.Attributes;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity;

namespace Captions.Service
{
    public class DataContextService
    {

        /// <summary>
        /// All models should expected to go through this pre saves
        /// </summary>
        /// <param name="changeTracker"></param>
        public static void PerformPreSaveChanges(DbChangeTracker changeTracker)
        {
            var changes = changeTracker.Entries().Where(x => x.State != EntityState.Unchanged);
            foreach (var change in changes)
            {
                ComputeHashes(change.Entity);
            }
        }

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
            {
                sb.Append(b.ToString("X2"));
            }

            return ApplySalt(sb.ToString());
        }
        
        /// <summary>
        /// generate a hash for the given string
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static byte[] GetHash(string inputString)
        {
            var algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// Apply a salt to a string
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static string ApplySalt(string inputString)
        {
            var salt = ApplicationService.GetApplicationServiceValue("Salt");
            var pdb = new Rfc2898DeriveBytes(inputString, Encoding.ASCII.GetBytes(salt));
            return Encoding.UTF8.GetString(pdb.GetBytes(64));
        }

    }
}