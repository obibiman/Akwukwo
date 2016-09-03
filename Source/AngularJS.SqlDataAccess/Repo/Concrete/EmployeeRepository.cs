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
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly AngularCrudContext _context;

        public EmployeeRepository(AngularCrudContext context)
        {
            _context = context;
        }

        public Employee Get(Expression<Func<Employee, bool>> predicate)
        {
            return _context.Employees.Where(predicate).SingleOrDefault();
        }

        public Employee GetById(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(y => y.EmployeeId == Id);
            return employee;
        }

        public IEnumerable<Employee> GetAll(Expression<Func<Employee, bool>> predicate = null)
        {
            IEnumerable<Employee> employees = new List<Employee>();
            if (predicate != null)
            {
                employees = _context.Employees.OrderByDescending(y => y.EmployeeId).Where(predicate).ToList();
            }
            else
            {
                employees = _context.Employees.OrderByDescending(y => y.EmployeeId);
            }
            return employees;
        }

        public void Insert(Employee entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.EmployeeSequence,
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
            entity.EmployeeId = data.Result;
            _context.Employees.Add(entity);
        }

        public void Update(Employee entity)
        {
            var newEmployee = new Employee();
            var existingEntity = (_context.Employees.Where(a => a.EmployeeId == entity.EmployeeId)).SingleOrDefault();
            if (existingEntity != null)
            {
                newEmployee.EmployeeId = existingEntity.EmployeeId;
                newEmployee.EmployeeName = entity.EmployeeName;
                newEmployee.EmployeeAge = entity.EmployeeAge;
                newEmployee.EmployeeCity = entity.EmployeeCity;
            }
           
            _context.Employees.AddOrUpdate(newEmployee);
        }

        public void Delete(Employee entity)
        {
            _context.Employees.Remove(entity);
        }

        public long Count()
        {
            return _context.Employees.Count();
        }

        public void AddRange(IEnumerable<Employee> entities)
        {
            foreach (var employeeData in entities)
            {
                var inputValue = new SqlParameter
                {
                    ParameterName = "@SequenceName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = SequenceIdentifier.EmployeeSequence,
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

                employeeData.EmployeeId = data.Result;
                _context.Employees.Add(employeeData);
            }
        }

        public void RemoveRange(IEnumerable<Employee> entities)
        {
            foreach (var employeeData in entities)
            {
                var itemToRemove = _context.Employees.SingleOrDefault(y => y.EmployeeId == employeeData.EmployeeId);
                _context.Employees.Remove(itemToRemove);
            }
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.SingleOrDefault(y => y.EmployeeId == employeeId);
        }
    }
}