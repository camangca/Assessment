
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
        HourlySalaryEmployee = 1,
        MonthtlySalaryEmployee = 2,
    }
    public class EmployeeController : ApiController
    {
        private IEmployeeSalaryService _employeeSalaryService;
        private IEmployeeDataService _employeeDataService;


        public EmployeeController(IEmployeeSalaryService employeeSalaryService, IEmployeeDataService employeeDataService)
        {
            _employeeSalaryService = employeeSalaryService;
            _employeeDataService = employeeDataService;
        }


        // GET: api/Employee
        public List<Employee> Get()
        {
            List<Employee> employeeList = new List<Employee>();
            var dataList = _employeeDataService.GetDataEmployeeService();
            CastList(employeeList, dataList);
            CalculateAnualSalary(employeeList);
            return employeeList;
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            List<Employee> employeeList = new List<Employee>();
            var dataList = _employeeDataService.GetDataEmployeeService();
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
                employee.contractTypeName = (item.contractTypeName.ToLower().Contains("hourly")) ? BusinessLayer.Models.ContractType.HourlySalaryEmployee : BusinessLayer.Models.ContractType.MonthtlySalaryEmployee;
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
            foreach (Employee item in employeeList)
            {
                _employeeSalaryService.GetEmployeeSalaryByContractType(item);
            }
        }
    }
}
