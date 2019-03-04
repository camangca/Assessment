using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Models;

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
                contractTypeName = ContractType.HourlySalary,
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
                contractTypeName = ContractType.HourlySalary,
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "Administrator role",
                hourlySalary = 20,
            };

            EmployeeSalaryService employeeSalaryService = new EmployeeSalaryService();

            employeeSalaryService.GetEmployeeSalaryByContractType(employeeInfo);

            // Assert
            Assert.AreEqual(expected.id, employeeInfo.id);
            Assert.AreEqual(expected.name, employeeInfo.name);
            Assert.AreEqual(expected.contractTypeName, employeeInfo.contractTypeName);
            Assert.AreEqual(expected.roleId, employeeInfo.roleId);
            Assert.AreEqual(expected.roleName, employeeInfo.roleName);
            Assert.AreEqual(expected.roleDescription, employeeInfo.roleDescription);
            Assert.AreEqual(expected.hourlySalary, employeeInfo.hourlySalary);
            Assert.AreEqual(expected.anualSalary, employeeInfo.anualSalary);

        }

        [TestMethod]
        public void GetEmployeeSalaryByMonthlySalary()
        {
            //Given
            Employee expected = new Employee
            {
                id = 1,
                name = "Camilo Angel",
                contractTypeName = ContractType.MonthtlySalary,
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
                contractTypeName = ContractType.MonthtlySalary,
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "Administrator role",
                monthlySalary = 3000,
            };

            EmployeeSalaryService employeeSalaryService = new EmployeeSalaryService();

            employeeSalaryService.GetEmployeeSalaryByContractType(employeeInfo);

            // Assert
            Assert.AreEqual(expected.id, employeeInfo.id);
            Assert.AreEqual(expected.name, employeeInfo.name);
            Assert.AreEqual(expected.contractTypeName, employeeInfo.contractTypeName);
            Assert.AreEqual(expected.roleId, employeeInfo.roleId);
            Assert.AreEqual(expected.roleName, employeeInfo.roleName);
            Assert.AreEqual(expected.roleDescription, employeeInfo.roleDescription);
            Assert.AreEqual(expected.hourlySalary, employeeInfo.hourlySalary);
            Assert.AreEqual(expected.anualSalary, employeeInfo.anualSalary);

        }
    }
}
