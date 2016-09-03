using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Text;
using AngularJS.Domain.DomainModel;
using log4net;

namespace AngularJS.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularCrudContext>
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularCrudContext context)
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EmployeeSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    EmployeeName = "Paul",
                    EmployeeCity = "Jefferson City",
                    EmployeeAge = 20
                },
                new Employee
                {
                    EmployeeId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EmployeeSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    EmployeeName = "Paula",
                    EmployeeCity = "Oklahoma City",
                    EmployeeAge = 27
                },
                new Employee
                {
                    EmployeeId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EmployeeSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    EmployeeName = "Michelle",
                    EmployeeCity = "Dallas",
                    EmployeeAge = 12
                },
                new Employee
                {
                    EmployeeId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EmployeeSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    EmployeeName = "Steve",
                    EmployeeCity = "College Station",
                    EmployeeAge = 21
                }
            };
            var students = new List<Student>
            {
                new Student
                {
                    StudentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Paul",
                    LastName = "Winfield",
                    Email = "Paul@mail.net",
                    Address = "123 Main Street, Jefferson City, MO 20103"
                },
                new Student
                {
                    StudentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Paulina",
                    LastName = "Mayflower",
                    Email = "Paul@mail.net",
                    Address = "123 Main Street, Jefferson City, MO 20103"
                },
                new Student
                {
                    StudentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Larry",
                    LastName = "Gonzales",
                    Email = "Paul@mail.net",
                    Address = "123 Main Street, Jefferson City, MO 20103"                },
                new Student
                {
                    StudentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Iris",
                    LastName = "Obijiaku",
                    Email = "Paul@mail.net",
                    Address = "123 Main Street, Jefferson City, MO 20103"
                }
            };

            students.ForEach(m => { context.Students.AddOrUpdate(m); });
            employees.ForEach(m => { context.Employees.AddOrUpdate(m); });

            SaveChanges(context);
        }

        private static void SaveChanges(AngularCrudContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                        Console.WriteLine(sb.ToString());
                        Console.ReadLine();
                        Log.Error(sb.ToString());

                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
        }
    }
}