using System;
using AngularJS.Domain.DomainModel;
using AngularJS.SqlDataAccess.Repo.Interfaces;

namespace AngularJS.SqlDataAccess.Uow.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Student> StudentRepository { get; }
        int Complete();
    }
}