
using BusinessLayer;
using BusinessLayer.Contracts;
using DataAccessLayer;
using DataAccessLayer.Contracts;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace EmployeesApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeSalaryService, EmployeeSalaryService>();
            container.RegisterType<IEmployeeDataService, EmployeeDataService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}