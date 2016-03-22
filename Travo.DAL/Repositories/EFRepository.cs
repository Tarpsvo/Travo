using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Travo.DAL.Interfaces;

namespace Travo.DAL.Repositories
{
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        protected TravoDbContext DbContext;
        protected DbSet<T> DbSet;

        public EFRepository(TravoDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.DbSet = dbContext.Set<T>();
        }

        public virtual T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
