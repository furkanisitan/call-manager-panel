using CallManagerPanel.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework.Mappings
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            // primary key
            HasKey(x => x.Id);
            // unique key
            HasIndex(x => x.Username).IsUnique().HasName("UK_Username_Users");
            // many-to-many
            HasMany(u => u.Roles).WithMany(r => r.Users).Map(ur => ur.ToTable("UserRoles").MapLeftKey("UserId").MapRightKey("RoleId"));

            Property(x => x.Id).HasColumnName("UserId");
            Property(x => x.Fullname).IsRequired();
            Property(x => x.Username).IsRequired().HasColumnType("nvarchar");
            Property(x => x.Password).IsRequired();
        }
    }
}
