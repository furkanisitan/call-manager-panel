using CallManagerPanel.Core.DataAccess.EntityFramework;
using CallManagerPanel.DataAccess.Abstract;
using CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CallManagerPanelContext>, IUserDal
    {
        public User GetWithRoles(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new CallManagerPanelContext())
            {
                return (filter == null ? context.Set<User>() : context.Set<User>().Where(filter))
                    .Include(x => x.Roles).SingleOrDefault();
            }
        }
    }
}