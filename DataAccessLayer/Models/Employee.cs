using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public enum ContractType
    {
        HourlySalary = 1,
        MonthtlySalary = 2,
    }

    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public ContractType contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public int ? hourlySalary { get; set; }
        public int ? monthlySalary { get; set; }
        public int ? anualSalary { get; set; }
    }
}
