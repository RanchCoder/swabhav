﻿using ContactApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Data.Repository
{
    public interface IAsyncContactRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<List<T>> GetAll();
        Task<List<T>> GetWhere(Expression<Func<T, bool>> predicate);

        //Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

    }
}
