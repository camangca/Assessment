using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicacion.Models
{
    public class Employee
    {
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Contract Type")]
        public ContractType contractTypeName { get; set; }
        [DisplayName("Role Id")]
        public int roleId { get; set; }
        [DisplayName("Role Name")]
        public string roleName { get; set; }
        [DisplayName("Role Description")]
        public string roleDescription { get; set; }
        [DisplayName("Hourly Salary")]
        public int? hourlySalary { get; set; }
        [DisplayName("Monthly Salary")]
        public int? monthlySalary { get; set; }
        [DisplayName("Annual Salary")]
        public int? anualSalary { get; set; }

    }
}