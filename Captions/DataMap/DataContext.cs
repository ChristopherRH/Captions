using Captions.Models;
using Captions.Service;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Captions.DataMap
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Caption> Captions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /// <summary>
        /// Default override for save changes
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var changes = ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged);

            foreach(var x in changes)
            {
                DataContextService.ComputeHashes(x.Entity);
            }
            return base.SaveChanges();
        }
    }
}