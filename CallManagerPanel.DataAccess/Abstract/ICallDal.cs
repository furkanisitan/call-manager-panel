using CallManagerPanel.Core.DataAccess;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CallManagerPanel.DataAccess.Abstract
{
    public interface ICallDal : IEntityRepository<Call>
    {
        ICollection<Call> GetAllWithUsers(Expression<Func<Call, bool>> filter = null);

    }
}