using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Travo.DAL.Interfaces;

namespace Travo.DAL.Repositories
{
    // Universal base EF repository implementation to be included in all other repos
    // Covers all basic CRUD methods
    // Created by Andres Käver
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public EFRepository(IDbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

            DbContext = dbContext as DbContext;
            if (DbContext != null) DbSet = DbContext.Set<T>();
        }

        public List<T> All => DbSet.ToList();

        public T GetById(params int[] id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached) dbEntityEntry.State = EntityState.Added;
            else DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached) DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted) dbEntityEntry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(params int[] id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }



        public EntityKey GetPrimaryKeyInfo(T entity)
        {
            var properties = typeof(DbSet).GetProperties();
            foreach (
                var objectContext in
                    properties.Select(propertyInfo => ((IObjectContextAdapter)DbContext).ObjectContext))
            {
                ObjectStateEntry objectStateEntry;
                if (null != entity && objectContext.ObjectStateManager
                    .TryGetObjectStateEntry(entity, out objectStateEntry))
                {
                    return objectStateEntry.EntityKey;
                }
            }
            return null;
        }

        public string[] GetKeyNames(T entity)
        {
            var objectSet = ((IObjectContextAdapter)DbContext).ObjectContext.CreateObjectSet<T>();
            var keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
            return keyNames;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            //Nothing to dispose
        }
    }
}
