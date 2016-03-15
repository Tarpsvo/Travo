using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Travo.DAL.Interfaces
{
    public interface IEFRepository<T> : IDisposable where T : class
    {
        List<T> All { get; }
        T GetById(params int[] id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(params int[] id);

        void SaveChanges();
    }
}
