using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts
{
    public interface IEmployeeSalaryService
    {
        void GetEmployeeSalaryByContractType(Employee employee);
    }
}
