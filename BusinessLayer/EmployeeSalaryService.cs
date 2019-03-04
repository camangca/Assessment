using BusinessLayer.Contracts;
using BusinessLayer.Models;
using System;

namespace BusinessLayer
{

    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        public void GetEmployeeSalaryByContractType(Employee employee)
        {
            try
            {
                switch (employee.contractTypeName)
                {
                    case ContractType.HourlySalaryEmployee:
                        CalculateHourlySalary(employee);
                        break;
                    case ContractType.MonthtlySalaryEmployee:
                        CalculateMonthlySalary(employee);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

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
