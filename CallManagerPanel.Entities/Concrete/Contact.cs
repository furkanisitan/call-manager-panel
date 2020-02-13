using CallManagerPanel.Core.Entities;
using System;
using System.Collections.Generic;

namespace CallManagerPanel.Entities.Concrete
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Phone { get; set; }
        public string CallReason { get; set; }
        public string CallResult { get; set; }

        public DateTime Date { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<Call> Calls { get; set; }
    }
}