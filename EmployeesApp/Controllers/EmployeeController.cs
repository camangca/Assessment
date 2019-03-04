
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeesApp.Controllers
{
    public enum ContractType
    {
        HourlySalary = 1,
        MonthtlySalary = 2,
    }
    public class EmployeeController : ApiController
    {
        private IEmployeeSalaryService _employeeSalaryService;
        private IEmployeeDataService _employeeDataService;

        //List<Employee> employeeList = new List<Employee>();

        public EmployeeController(IEmployeeSalaryService employeeSalaryService, IEmployeeDataService employeeDataService)
        {
            _employeeSalaryService = employeeSalaryService;
            _employeeDataService = employeeDataService;
            //employeeList.Add(new Employee { id = 1, name = "camilo angel", contractTypeName = BusinessLayer.Models.ContractType.HourlySalary, roleId = 1, roleName = "administrator", hourlySalary = 20 });
            //employeeList.Add(new Employee { id = 2, name = "diego alvarez", contractTypeName = BusinessLayer.Models.ContractType.MonthtlySalary, roleId = 1, roleName = "administrator", monthlySalary = 3000 });
            //employeeList.Add(new Employee { id = 3, name = "edwin martinez", contractTypeName = BusinessLayer.Models.ContractType.HourlySalary, roleId = 2, roleName = "support", hourlySalary = 18 });
        }

        // GET: api/Employee
        [HttpGet]
        public List<Employee> Get()
        {
            List<Employee> employeeList = new List<Employee>();
            var dataList = _employeeDataService.GetDataEmployeeService(null);
            CastList(employeeList, dataList);

            CalculateAnualSalary(employeeList);

            return employeeList;
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            List<Employee> employeeList = new List<Employee>();
            var dataList = _employeeDataService.GetDataEmployeeService(null);
            CastList(employeeList, dataList);
            CalculateAnualSalary(employeeList);
            return employeeList.Where(x => x.id == id).FirstOrDefault();
        }


        private static void CastList(List<Employee> employeeList, List<DataAccessLayer.Models.Employee> dataList)
        {
            foreach (var item in dataList)
            {
                Employee employee = new Employee();
                employee.id = item.id;
                employee.name = item.name;
                employee.contractTypeName = (item.contractTypeName.ToLower().Contains("hourly")) ? BusinessLayer.Models.ContractType.HourlySalary : BusinessLayer.Models.ContractType.MonthtlySalary;
                employee.roleId = item.roleId;
                employee.roleName = item.roleName;
                employee.roleDescription = item.roleDescription;
                employee.hourlySalary = Convert.ToInt32(item.hourlySalary);
                employee.monthlySalary = Convert.ToInt32(item.monthlySalary);
                employeeList.Add(employee);

            }
        }
        private void CalculateAnualSalary(List<Employee> employeeList)
        {
            foreach (var item in employeeList)
            {
                _employeeSalaryService.GetEmployeeSalaryByContractType(item);
            }
        }
    }
}
