using BusinessLayer.Models;

namespace BusinessLayer.Contracts
{
    public interface IEmployeeSalaryService
    {
        void GetEmployeeSalaryByContractType(Employee employee);
    }
}
