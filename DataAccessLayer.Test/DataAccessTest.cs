
using DataAccessLayer.Models;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataAccessLayer.Test
{
    [TestClass]
    public class DataAccessTest
    {


        #region Initialize

        [TestInitialize]
        public void Initialize()
        {

        }

        #endregion

        [TestMethod]
        public void GetDataService()
        {
            //Given
            List<Employee> expectedList = new List<Employee>();
            expectedList.Add(new Employee { id = 1, name = "Juan", contractTypeName = "HourlySalaryEmployee", roleId = 1, roleName = "Administrator", roleDescription=null, hourlySalary = 60000, monthlySalary = 80000 });
            expectedList.Add(new Employee { id = 2, name = "Sebastian", contractTypeName = "MonthlySalaryEmployee", roleId = 2, roleName = "Contractor", roleDescription = null, hourlySalary=60000 ,monthlySalary = 80000 });

            //When

            var employeeService = new EmployeeDataService();
            List<Employee> result = employeeService.GetDataEmployeeService();

            // Assert
            
            result.WithDeepEqual(expectedList)
               .SkipDefault<List<Employee>>()
               .Assert();

        }
    }
}
