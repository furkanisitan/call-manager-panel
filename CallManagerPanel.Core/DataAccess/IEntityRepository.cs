using CallManagerPanel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CallManagerPanel.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        bool IsPropertiesEdited(T entity, params string[] properties);
        int GetCount(Expression<Func<T, bool>> filter = null);
    }
}
