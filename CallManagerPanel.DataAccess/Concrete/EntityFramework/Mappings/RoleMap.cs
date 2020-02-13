using System.Data.Entity.ModelConfiguration;
using CallManagerPanel.Entities.Concrete;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework.Mappings
{
    class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Roles");

            // primary key
            HasKey(x => x.Id);
            // unique key 
            HasIndex(x => x.Name).IsUnique().HasName("UK_Name_Roles");

            Property(x => x.Id).HasColumnName("RoleId");
            Property(x => x.Name).IsRequired().HasColumnType("nvarchar");;
        }
    }
}