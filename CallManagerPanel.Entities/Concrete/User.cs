using CallManagerPanel.Core.Entities;
using System.Collections.Generic;

namespace CallManagerPanel.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Call> Calls { get; set; }
    }
}