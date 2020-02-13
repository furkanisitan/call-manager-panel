using System.Data.Entity.ModelConfiguration;
using CallManagerPanel.Entities.Concrete;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework.Mappings
{
    class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            ToTable("Contacts");

            // primary key
            HasKey(x => x.Id);
            // foreign key
            // User(1) -> Contact(n)
            HasRequired(x => x.User).WithMany(u => u.Contacts).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("ContactId");
            Property(x => x.Date).HasColumnType("date").IsRequired();
            Property(x => x.CallReason).IsOptional();
            Property(x => x.CallResult).IsOptional();
            Property(x => x.Phone).IsOptional();
        }
    }
}