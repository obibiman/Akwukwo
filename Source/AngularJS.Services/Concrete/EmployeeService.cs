using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AngularJS.Domain.DomainModel;
using AngularJS.Services.Interfaces;
using AngularJS.SqlDataAccess.Uow.Interfaces;

namespace AngularJS.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService()
        {
        }

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Employee entity)
        {
            _unitOfWork.EmployeeRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Employee> GetAll(Expression<Func<Employee, bool>> predicate = null)
        {
            return _unitOfWork.EmployeeRepository.GetAll(predicate);
        }

        public Employee GetById(int Id)
        {
            return _unitOfWork.EmployeeRepository.GetById(Id);
        }

        public void Update(Employee entity)
        {
            _unitOfWork.EmployeeRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _unitOfWork.EmployeeRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.EmployeeRepository.Count();
        }

        public void AddRange(IEnumerable<Employee> entities)
        {
            _unitOfWork.EmployeeRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Employee> entities)
        {
            _unitOfWork.EmployeeRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}