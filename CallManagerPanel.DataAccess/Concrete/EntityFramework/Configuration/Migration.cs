using CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration.SampleDatabases;
using System.Data.Entity.Migrations;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration
{
    public class Migration : DbMigrationsConfiguration<CallManagerPanelContext>
    {
        public Migration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CallManagerPanelContext context)
        {
            SampleDatabase1.InitDatabase(context);
        }
    }
}
