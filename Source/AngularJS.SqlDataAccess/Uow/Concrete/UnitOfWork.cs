using AngularJS.Domain.DomainModel;
using AngularJS.SqlDataAccess.Repo.Concrete;
using AngularJS.SqlDataAccess.Repo.Interfaces;
using AngularJS.SqlDataAccess.Uow.Interfaces;

namespace AngularJS.SqlDataAccess.Uow.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AngularCrudContext _context;

        public UnitOfWork(AngularCrudContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
            StudentRepository = new StudentRepository(_context);
            Complete();
        }

        public IRepository<Employee> EmployeeRepository { get; }
        public IRepository<Student> StudentRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}