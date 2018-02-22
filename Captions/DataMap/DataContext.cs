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
        public DbSet<ApplicationValue> ApplicationValues { get; set; }

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
            
            DataContextService.PerformPreSaveChanges(ChangeTracker);
            return base.SaveChanges();
        }
    }
}