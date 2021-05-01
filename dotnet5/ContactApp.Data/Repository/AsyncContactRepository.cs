using ContactApp.Data.DBContext;
using ContactApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Data.Repository
{
    public class AsyncContactRepository<T> : IAsyncContactRepository<T> where T : BaseEntity
    {
        protected ContactAddressDBContext _contactAddressDBContext;

        public AsyncContactRepository(ContactAddressDBContext contactAddressDBContext) {
            this._contactAddressDBContext = contactAddressDBContext;
        }
        public async Task Add(T entity)
        {
            await _contactAddressDBContext.Set<T>().AddAsync(entity);
            await _contactAddressDBContext.SaveChangesAsync();
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate) => _contactAddressDBContext.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<List<T>> GetAll()
        {
            return await _contactAddressDBContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _contactAddressDBContext.Set<T>().FindAsync(id);

        }


        public async Task<List<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _contactAddressDBContext.Set<T>().Where(predicate).ToListAsync();
        }
        

        public Task Remove(T entity)
        {
            _contactAddressDBContext.Set<T>().Remove(entity);
            return _contactAddressDBContext.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            _contactAddressDBContext.Entry(entity).State = EntityState.Modified;
            return _contactAddressDBContext.SaveChangesAsync();
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate) => await _contactAddressDBContext.Set<T>().Where(predicate).CountAsync();
    }
}
