
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeesApp.Controllers;
using DataAccessLayer.Contracts;
using Moq;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DeepEqual.Syntax;

namespace EmployeesApp.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {

        #region Attributes

        private Mock<IEmployeeDataService> _employeeDataService;
        private Mock<IEmployeeSalaryService> _employeeSalaryService;
        EmployeeController _controller;
        #endregion

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            _employeeDataService = new Mock<IEmployeeDataService>();
            _employeeSalaryService = new Mock<IEmployeeSalaryService>();
            _controller = new EmployeeController(_employeeSalaryService.Object, _employeeDataService.Object);
        }
        #endregion

        [TestMethod]
        public void Get()
        {
            List<Employee> expected = new List<Employee>();
            expected.Add(new Employee { id = 1, name = "Juan", contractTypeName = BusinessLayer.Models.ContractType.HourlySalaryEmployee, roleId = 1, roleName = "Administrator", roleDescription = null, hourlySalary = 60000, monthlySalary = 80000 });
            expected.Add(new Employee { id = 2, name = "Sebastian", contractTypeName = BusinessLayer.Models.ContractType.MonthtlySalaryEmployee, roleId = 2, roleName = "Contractor", roleDescription = null, hourlySalary = 60000, monthlySalary = 80000 });
            //Given
            List<DataAccessLayer.Models.Employee> expectedList1 = new List<DataAccessLayer.Models.Employee>();
            expectedList1.Add(new DataAccessLayer.Models.Employee { id = 1, name = "Juan", contractTypeName = "HourlySalaryEmployee", roleId = 1, roleName = "Administrator", roleDescription = null, hourlySalary = 60000, monthlySalary = 80000 });
            expectedList1.Add(new DataAccessLayer.Models.Employee { id = 2, name = "Sebastian", contractTypeName = "MonthlySalaryEmployee", roleId = 2, roleName = "Contractor", roleDescription = null, hourlySalary = 60000, monthlySalary = 80000 });

            Employee employee1 = new Employee { id = 1, name = "Juan", contractTypeName = BusinessLayer.Models.ContractType.HourlySalaryEmployee, roleId = 1, roleName = "Administrator", roleDescription = null, hourlySalary = 60000, monthlySalary = 80000, anualSalary = 86400000};
            Employee employee2 = new Employee { id = 2, name = "Sebastian", contractTypeName = BusinessLayer.Models.ContractType.MonthtlySalaryEmployee, roleId = 2, roleName = "Contractor", roleDescription = null, hourlySalary = 60000, monthlySalary = 80000, anualSalary = 960000};

            _employeeDataService.Setup(x => x.GetDataEmployeeService())
                .Returns(() =>
                {
                    return expectedList1;
                });


            _employeeSalaryService.Setup(x => x.GetEmployeeSalaryByContractType(It.IsAny<Employee>())).Callback<Employee>(x => employee1 = x).Verifiable();

            _employeeSalaryService.Setup(x => x.GetEmployeeSalaryByContractType(It.IsAny<Employee>())).Callback<Employee>(x => employee2 = x).Verifiable();

            // Act
            List <Employee> result = _controller.Get();

            // Assert
            result.WithDeepEqual(expected)
               .SkipDefault<Employee>()
               .Assert();

        }

        [TestMethod]
        public void GetById()
        {
            //// Arrange
            //EmployeeController controller = new EmployeeController();

            //// Act
            //string result = controller.Get(5);

            //// Assert
            //Assert.AreEqual("value", result);
        }

    }
}
