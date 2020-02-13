using CallManagerPanel.Core.DataAccess;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Linq.Expressions;

namespace CallManagerPanel.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        User GetWithRoles(Expression<Func<User, bool>> filter = null);
    }
}
