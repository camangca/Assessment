using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{

    public interface IEmployeeDataService
    {
        List<Employee> GetDataEmployeeService();
    }
}
