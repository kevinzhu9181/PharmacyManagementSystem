using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PMSDbContext _pMSDbContext;
        private readonly DbSet<T> _table;
        public GenericRepository(PMSDbContext pMSDbContext)
        {
            _pMSDbContext = pMSDbContext;
            _table = _pMSDbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }
        public T GetById(object id)
        {
            return _table.Find(id);
        }
        public void Insert(T obj)
        {
            _table.Add(obj);
        }
        public void Update(T obj)
        {
            _table.Attach(obj);
            _pMSDbContext.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }
        public void Save()
        {
            _pMSDbContext.SaveChanges();
        }
    }
}
