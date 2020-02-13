using CallManagerPanel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CallManagerPanel.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public virtual ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return (filter == null ? context.Set<TEntity>() : context.Set<TEntity>().Where(filter)).ToList();
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public virtual TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public bool IsPropertiesEdited(TEntity entity, params string[] properties)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (!properties.Any())
                throw new ArgumentException("Input cannot be empty.", nameof(properties));

            using (var context = new TContext())
            {
                var tracked = context.Set<TEntity>().SingleOrDefault(x => x.Id == entity.Id);
                var entry = context.Entry(tracked);
                entry.CurrentValues.SetValues(entity);
                return properties.Any(x => !entry.OriginalValues[x].Equals(entry.CurrentValues[x]));
            }
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return (filter == null ? context.Set<TEntity>() : context.Set<TEntity>().Where(filter)).Count();
            }
        }
    }
}
