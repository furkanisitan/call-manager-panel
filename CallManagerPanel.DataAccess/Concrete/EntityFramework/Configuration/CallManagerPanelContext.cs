using System.Data.Entity;
using CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration.SampleDatabases;
using CallManagerPanel.DataAccess.Concrete.EntityFramework.Mappings;
using CallManagerPanel.Entities.Concrete;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration
{
    public class CallManagerPanelContext : DbContext
    {
        public DbSet<Call> Calls { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public CallManagerPanelContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migration>());
            Database.SetInitializer(new SampleDatabase1());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CallMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }


}
