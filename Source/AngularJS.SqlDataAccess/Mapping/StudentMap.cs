using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AngularJS.Domain.DomainModel;

namespace AngularJS.SqlDataAccess.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Student");
            HasKey(t => t.StudentId);
            Property(t => t.StudentId)
                .IsRequired()
                .HasColumnName("StudentId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasMaxLength(25);
            Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(25);
            Property(t => t.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(3)
                .HasMaxLength(100);
            Property(t => t.Address)
                .IsOptional()
                .HasColumnName("Address")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .HasColumnOrder(4);
        }
    }
}