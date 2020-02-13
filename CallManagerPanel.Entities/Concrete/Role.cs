using CallManagerPanel.Core.Entities;
using System.Collections.Generic;

namespace CallManagerPanel.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}