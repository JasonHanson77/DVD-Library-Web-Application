using DVDLibraryDBWEB.Models.Tables;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DVDLibraryDBWEB.Data.EntityFramework
{
    public class DVDContext : DbContext
    {
        public DVDContext()
           : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<DVD> DVD { get; set; }
    }
}