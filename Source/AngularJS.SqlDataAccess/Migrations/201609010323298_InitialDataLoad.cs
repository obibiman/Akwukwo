using System.IO;

namespace AngularJS.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataLoad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false, maxLength: 25),
                        EmployeeCity = c.String(maxLength: 50),
                        EmployeeAge = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.StudentId);

            Sql("CREATE SEQUENCE [dbo].[EmployeeSequence] AS [int] START WITH 1000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[StudentSequence] AS [int] START WITH 1000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");

            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\DevSource\DotNet\AngularJS.CRUD.Operation.UsingASP.NET.MVC\Source\AngularJS.SqlDataAccess\DatabaseScripts\SequenceSelection_CreateStoredProcedureScript.sql");
            Sql(File.ReadAllText(sqlFile));
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.Employee");

            Sql("DROP SEQUENCE [dbo].[EmployeeSequence] ");
            Sql("DROP SEQUENCE [dbo].[StudentSequence] ");

            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\DevSource\DotNet\AngularJS.CRUD.Operation.UsingASP.NET.MVC\Source\AngularJS.SqlDataAccess\DatabaseScripts\SequenceSelection_DropStoredProcedureScript.sql");
            Sql(File.ReadAllText(sqlFile));
        }
    }
}
