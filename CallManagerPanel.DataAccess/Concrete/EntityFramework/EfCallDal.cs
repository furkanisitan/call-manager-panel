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
    public class EfCallDal : EfEntityRepositoryBase<Call, CallManagerPanelContext>, ICallDal
    {
        public ICollection<Call> GetAllWithUsers(Expression<Func<Call, bool>> filter = null)
        {
            using (var context = new CallManagerPanelContext())
            {
                return (filter == null ? context.Set<Call>() : context.Set<Call>().Where(filter))
                    .Include(x => x.User).ToList();
            }
        }
    }
}
