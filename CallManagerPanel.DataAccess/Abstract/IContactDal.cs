using CallManagerPanel.Core.DataAccess;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CallManagerPanel.DataAccess.Abstract
{
    public interface IContactDal : IEntityRepository<Contact>
    {
        ICollection<Contact> GetAllWithCallsIncludeUser(Expression<Func<Contact, bool>> filter = null);
        Contact GetWithCalls(Expression<Func<Contact, bool>> filter = null);
    }
}