using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AngularJS.Domain.DomainModel;

namespace AngularJS.Services.Interfaces
{
    public interface IStudentService
    {
        void Insert(Student entity);
        IEnumerable<Student> GetAll(Expression<Func<Student, bool>> predicate = null);
        Student GetById(int Id);
        void Update(Student entity);
        void Delete(Student entity);
        long Count();
        void AddRange(IEnumerable<Student> entities);
        void RemoveRange(IEnumerable<Student> entities);
        void SaveChanges();
    }
}