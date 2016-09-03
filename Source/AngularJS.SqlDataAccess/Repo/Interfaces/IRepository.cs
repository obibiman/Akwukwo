using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularJS.SqlDataAccess.Repo.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(int Id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        long Count();
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
    }
}