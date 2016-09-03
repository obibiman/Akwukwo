using Microsoft.Practices.Unity;
using System.Web.Http;
using AngularJS.Services.Concrete;
using AngularJS.Services.Interfaces;
using AngularJS.SqlDataAccess.Uow.Concrete;
using AngularJS.SqlDataAccess.Uow.Interfaces;
using Unity.WebApi;

namespace AngularJS.RESTful.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IEmployeeService, EmployeeService>()
                .RegisterType<IStudentService, StudentService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}