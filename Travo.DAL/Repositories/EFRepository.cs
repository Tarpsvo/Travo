using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
