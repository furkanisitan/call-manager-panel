using CallManagerPanel.Core.Entities;
using System;

namespace CallManagerPanel.Entities.Concrete
{
    public class Call : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ContactId { get; set; }

        public DateTime Date { get; set; }

        public bool IsAccess { get; set; }

        public virtual User User { get; set; }
        public virtual Contact Contact { get; set; }
    }
}