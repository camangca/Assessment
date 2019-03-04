using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Models;
using DeepEqual.Syntax;

namespace BusinessLayer.Test
{
    [TestClass]
    public class EmployeeSalaryServiceTest
    {
        [TestMethod]
        public void GetEmployeeSalaryByHourlySalary()
        {
            //Given
            Employee expected = new Employee
            {
                id = 1,
                name = "Camilo Angel",
                contractTypeName = ContractType.HourlySalaryEmployee,
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "Administrator role",
                hourlySalary = 20,
                anualSalary = 28800
            };

            //When

            Employee employeeInfo = new Employee
            {
                id = 1,
                name = "Camilo Angel",
                contractTypeName = ContractType.HourlySalaryEmployee,
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "Administrator role",
                hourlySalary = 20,
            };

            EmployeeSalaryService employeeSalaryService = new EmployeeSalaryService();

            employeeSalaryService.GetEmployeeSalaryByContractType(employeeInfo);


            //Assert
            employeeInfo.WithDeepEqual(expected)
               .SkipDefault<Employee>()
               .Assert();

        }

        [TestMethod]
        public void GetEmployeeSalaryByMonthlySalary()
        {
            //Given
            Employee expected = new Employee
            {
                id = 1,
                name = "Camilo Angel",
                contractTypeName = ContractType.MonthtlySalaryEmployee,
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "Administrator role",
                monthlySalary = 3000,
                anualSalary = 36000
            };

            //When

            Employee employeeInfo = new Employee
            {
                id = 1,
                name = "Camilo Angel",
                contractTypeName = ContractType.MonthtlySalaryEmployee,
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "Administrator role",
                monthlySalary = 3000,
            };

            EmployeeSalaryService employeeSalaryService = new EmployeeSalaryService();

            employeeSalaryService.GetEmployeeSalaryByContractType(employeeInfo);
            
            //Assert
            employeeInfo.WithDeepEqual(expected)
               .SkipDefault<Employee>()
               .Assert();


        }
    }
}
