using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AngularJS.Domain.DomainModel;

namespace AngularJS.SqlDataAccess.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employee");
            HasKey(t => t.EmployeeId);
            Property(t => t.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.EmployeeName)
                .IsRequired()
                .HasColumnName("EmployeeName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasMaxLength(25);
            Property(t => t.EmployeeCity)
                .IsOptional()
                .HasColumnName("EmployeeCity")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .HasColumnOrder(2);
            Property(t => t.EmployeeAge)
                .IsOptional()
                .HasColumnName("EmployeeAge")
                .HasColumnType("INT")
                .HasColumnOrder(3);
        }
    }
}