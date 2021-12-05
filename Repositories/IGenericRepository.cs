using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object obj);
        void Save();
    }
}
