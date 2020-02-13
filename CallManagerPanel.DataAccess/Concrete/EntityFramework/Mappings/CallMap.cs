using System.Data.Entity.ModelConfiguration;
using CallManagerPanel.Entities.Concrete;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework.Mappings
{
    class CallMap : EntityTypeConfiguration<Call>
    {
        public CallMap()
        {
            ToTable("Calls");

            // primary key
            HasKey(x => x.Id);

            // foreign keys
            // Contact(1) -> Call(n)
            HasRequired(x => x.Contact).WithMany(c => c.Calls).HasForeignKey(x => x.ContactId).WillCascadeOnDelete(true);
            // User(1) -> Call(n)
            HasRequired(x => x.User).WithMany(u => u.Calls).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("CallId");
            Property(x => x.Date).IsRequired();
            Property(x => x.IsAccess);
        }
    }
}