using CallManagerPanel.Core.DataAccess.EntityFramework;
using CallManagerPanel.DataAccess.Abstract;
using CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, CallManagerPanelContext>, IContactDal
    {
        public ICollection<Contact> GetAllWithCallsIncludeUser(Expression<Func<Contact, bool>> filter = null)
        {
            using (var context = new CallManagerPanelContext())
            {
                return (filter == null ? context.Set<Contact>() : context.Set<Contact>().Where(filter))
                    .Include(x => x.Calls.Select(c => c.User)).ToList();
            }
        }

        public Contact GetWithCalls(Expression<Func<Contact, bool>> filter = null)
        {
            using (var context = new CallManagerPanelContext())
            {
                return (filter == null ? context.Set<Contact>() : context.Set<Contact>().Where(filter))
                    .Include(x => x.Calls).SingleOrDefault();
            }
        }
    }
}