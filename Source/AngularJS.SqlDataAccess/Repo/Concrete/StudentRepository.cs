using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using AngularJS.Domain.DomainModel;
using AngularJS.SqlDataAccess.Repo.Interfaces;

namespace AngularJS.SqlDataAccess.Repo.Concrete
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AngularCrudContext _context;

        public StudentRepository(AngularCrudContext context)
        {
            _context = context;
        }

        public Student Get(Expression<Func<Student, bool>> predicate)
        {
            return _context.Students.Where(predicate).SingleOrDefault();
        }

        public Student GetById(int Id)
        {
            var student = _context.Students.SingleOrDefault(y => y.StudentId == Id);
            return student;
        }

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>> predicate = null)
        {
            IEnumerable<Student> students = new List<Student>();
            if (predicate != null)
            {
                students = _context.Students.OrderByDescending(y => y.StudentId).Where(predicate).ToList();
            }
            else
            {
                students = _context.Students.OrderByDescending(y => y.StudentId);
            }
            return students;
        }

        public void Insert(Student entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.StudentSequence,
                Direction = ParameterDirection.Input
            };
            var outParam = new SqlParameter
            {
                ParameterName = "@SequenceValue",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var returnCode = new SqlParameter
            {
                ParameterName = "@SequenceOutput",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var data = _context.Database
                .SqlQuery<int>("exec @SequenceOutput = sp_AngularCrudAPISequence @SequenceName, @SequenceValue OUT",
                    returnCode, inputValue, outParam)
                .FirstOrDefaultAsync();
            entity.StudentId = data.Result;
            _context.Students.Add(entity);
        }

        public void Update(Student entity)
        {
            var newStudent = new Student();
            var existingEntity = (_context.Students.Where(a => a.StudentId == entity.StudentId)).SingleOrDefault();
            if (existingEntity != null)
            {
                newStudent.StudentId = existingEntity.StudentId;
                newStudent.FirstName = entity.FirstName;
                newStudent.LastName = entity.LastName;
                newStudent.Email = entity.Email;
                newStudent.Address = entity.Address;
            }

            _context.Students.AddOrUpdate(newStudent);
        }

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity);
        }

        public long Count()
        {
            return _context.Students.Count();
        }

        public void AddRange(IEnumerable<Student> entities)
        {
            foreach (var studentData in entities)
            {
                var inputValue = new SqlParameter
                {
                    ParameterName = "@SequenceName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = SequenceIdentifier.StudentSequence,
                    Direction = ParameterDirection.Input
                };
                var outParam = new SqlParameter
                {
                    ParameterName = "@SequenceValue",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var returnCode = new SqlParameter
                {
                    ParameterName = "@SequenceOutput",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var data = _context.Database
                    .SqlQuery<int>("exec @SequenceOutput = sp_AngularCrudAPISequence @SequenceName, @SequenceValue OUT",
                        returnCode, inputValue, outParam)
                    .FirstOrDefaultAsync();

                studentData.StudentId = data.Result;
                _context.Students.Add(studentData);
            }
        }

        public void RemoveRange(IEnumerable<Student> entities)
        {
            foreach (var studentData in entities)
            {
                var itemToRemove = _context.Students.SingleOrDefault(y => y.StudentId == studentData.StudentId);
                _context.Students.Remove(itemToRemove);
            }
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Students.SingleOrDefault(y => y.StudentId == studentId);
        }
    }
}