using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travo.DAL.Interfaces
{
    public interface IEFRepository<T>
    {
        T GetById(object id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Save();
    }
}
