var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\DevSource\DotNet\AngularJS.CRUD.Operation.UsingASP.NET.MVC\Source\AngularJS.SqlDataAccess\DatabaseScripts\SequenceSelection_CreateStoredProcedureScript.sql");
Sql(File.ReadAllText(sqlFile));

var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\DevSource\DotNet\AngularJS.CRUD.Operation.UsingASP.NET.MVC\Source\AngularJS.SqlDataAccess\DatabaseScripts\SequenceSelection_DropStoredProcedureScript.sql");
Sql(File.ReadAllText(sqlFile));