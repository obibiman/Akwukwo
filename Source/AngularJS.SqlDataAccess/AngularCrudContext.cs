using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using AngularJS.Domain.DomainModel;
using AngularJS.SqlDataAccess.Mapping;

namespace AngularJS.SqlDataAccess
{
    public class AngularCrudContext : DbContext
    {
        public AngularCrudContext() : base("name=AngularCrudContext")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public virtual DbSet <Employee> Employees { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new StudentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}