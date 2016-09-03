using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AngularJS.Domain.DomainModel;
using AngularJS.Services.Interfaces;
using AngularJS.SqlDataAccess.Uow.Interfaces;

namespace AngularJS.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService()
        {
        }

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Student entity)
        {
            _unitOfWork.StudentRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>> predicate = null)
        {
            return _unitOfWork.StudentRepository.GetAll(predicate);
        }

        public Student GetById(int Id)
        {
            return _unitOfWork.StudentRepository.GetById(Id);
        }

        public void Update(Student entity)
        {
            _unitOfWork.StudentRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Student entity)
        {
            _unitOfWork.StudentRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.StudentRepository.Count();
        }

        public void AddRange(IEnumerable<Student> entities)
        {
            _unitOfWork.StudentRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Student> entities)
        {
            _unitOfWork.StudentRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}
