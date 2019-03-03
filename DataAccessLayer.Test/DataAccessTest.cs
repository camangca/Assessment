using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Models;

namespace DataAccessLayer.Test
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void GetDataService()
        {
            Employee EmployeeData = new Employee
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
        }
    }
}
