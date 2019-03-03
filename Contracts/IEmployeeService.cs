using Contracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Contracts
{

    public class IEmployeeService
    {
        IEnumerable<Employee> GetDataEmployeeService(int id);
    }
}
