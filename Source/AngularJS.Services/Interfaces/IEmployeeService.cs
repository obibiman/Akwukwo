using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AngularJS.Domain.DomainModel;

namespace AngularJS.Services.Interfaces
{
    public interface IEmployeeService
    {
        void Insert(Employee entity);
        IEnumerable<Employee> GetAll(Expression<Func<Employee, bool>> predicate = null);
        Employee GetById(int Id);
        void Update(Employee entity);
        void Delete(Employee entity);
        long Count();
        void AddRange(IEnumerable<Employee> entities);
        void RemoveRange(IEnumerable<Employee> entities);
        void SaveChanges();
    }
}