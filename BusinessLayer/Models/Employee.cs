

namespace BusinessLayer.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public ContractType contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public int? hourlySalary { get; set; }
        public int? monthlySalary { get; set; }
        public int? anualSalary { get; set; }

    }
}