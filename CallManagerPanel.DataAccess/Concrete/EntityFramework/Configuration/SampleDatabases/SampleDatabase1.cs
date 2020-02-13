using Bogus;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration.SampleDatabases
{
    class SampleDatabase1 : DropCreateDatabaseAlways<CallManagerPanelContext>
    {
        private static readonly Faker Faker;

        static SampleDatabase1()
        {
            Faker = new Faker("tr");
        }

        public override void InitializeDatabase(CallManagerPanelContext context)
        {
            // Veritabanını tek kullanıcı moduna alır. Aktif bir bağlantı varsa kapatır ve bekeyen işlemleri geri alır.
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            base.InitializeDatabase(context);
        }

        protected override void Seed(CallManagerPanelContext context)
        {
            InitDatabase(context);
        }

        public static void InitDatabase(CallManagerPanelContext context)
        {
            const int maxCallCountPerContact = 6;
            const int userCount = 7;

            // Add roles
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Manager" },
                new Role { Name = "Staff" }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();

            // Add users
            var userList = new List<User>
            {
                new User { Fullname = Faker.Name.FullName(), Password = "1234", Username = "admin", Roles = new List<Role> { roles[0] } },
                new User { Fullname = Faker.Name.FullName(), Password = "1234", Username = "manager", Roles = new List<Role> { roles[1], roles[2] } },
                new User { Fullname = Faker.Name.FullName(), Password = "1234", Username = "staff", Roles = new List<Role> { roles[2] } }
            };
            var userIds = userList.Count;
            var users = new Faker<User>()
                .RuleFor(x => x.Id, f => userIds++)
                .RuleFor(x => x.Fullname, f => f.Name.FullName())
                .RuleFor(x => x.Password, f => f.Internet.Password(4))
                .RuleFor(x => x.Username, (f, x) => $"{f.Internet.UserName()}_{x.Id}")
                .RuleFor(x => x.Roles, f => new List<Role> { roles[2] });

            var usrCount = Math.Max(0, userCount - userList.Count);
            userList.AddRange(users.Generate(usrCount));
            context.Users.AddRange(userList);
            context.SaveChanges();

            // calls
            var callIds = 0;
            var calls = new Faker<Call>()
                .RuleFor(x => x.Id, f => callIds++)
                .RuleFor(x => x.Date, f => f.Date.Past())
                .RuleFor(x => x.IsAccess, f => f.Random.Bool())
                .RuleFor(x => x.UserId, f => f.Random.Number(1, userCount));

            // Add contacts
            var contactIds = 0;
            var contacts = new Faker<Contact>()
                .RuleFor(x => x.Id, f => contactIds++)
                .RuleFor(x => x.CallReason, f => f.Lorem.Sentence())
                .RuleFor(x => x.Date, f => f.Date.Past())
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber("(5##) ### ####"))
                .RuleFor(x => x.UserId, f => f.Random.Number(1, userCount))
                .RuleFor(x => x.Calls, f => calls.Generate(f.Random.Number(maxCallCountPerContact)))
                .RuleFor(x => x.CallResult, (f, c) =>
                    c.Calls.AsQueryable().Any(t => t.IsAccess) ? f.Lorem.Sentence() : null);

            context.Contacts.AddRange(contacts.Generate(25));
            context.SaveChanges();
        }
    }
}
