using BusinessLayer.Contracts;
using BusinessLayer.Models;

namespace BusinessLayer
{

    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        public void GetEmployeeSalaryByContractType(Employee employee)
        {
            switch (employee.contractTypeName)
            {
                case ContractType.HourlySalary:
                    CalculateHourlySalary(employee);
                    break;
                case ContractType.MonthtlySalary:
                    CalculateMonthlySalary(employee);
                    break;
            }
        }

        private void CalculateMonthlySalary(Employee employee)
        {
            employee.anualSalary = employee.monthlySalary * 12;
        }

        private void CalculateHourlySalary(Employee employee)
        {
            employee.anualSalary = 120 * employee.hourlySalary * 12;
        }
    }
}
