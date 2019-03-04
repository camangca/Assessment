
using DataAccessLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
            Employee expected = new Employee
            {
                id = 0,
                name = "",
                contractTypeName = "",
                roleId = 0,
                roleName = "",
                roleDescription = "",
                hourlySalary = 1,
                monthlySalary = 1
            };

            //When

            var employeeService = new EmployeeDataService();
            int idEmployee = 0;
            var result = employeeService.GetDataEmployeeService(idEmployee);

            // Assert
            Assert.AreEqual(expected, result);


        }
    }
}
