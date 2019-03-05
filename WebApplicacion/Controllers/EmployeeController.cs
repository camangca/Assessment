using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplicacion.Models;

namespace WebApplicacion.Controllers
{
    public class EmployeeController : Controller
    {

        private string wepApiURL = "http://employeesapiassessment.azurewebsites.net/api/employee";

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee

        [HttpPost]
        public ActionResult Index(int? idEmployee)
        {
            
            var employees = GetEmployeesFromAPI();
            if (idEmployee == null)
            {
                var employeeList = from a in employees
                                   where a.id == a.id
                                   select a;
                return View(employeeList);
            }
            else
            {
                var employeeList = from a in employees
                                   where a.id == idEmployee
                                   select a;
                return View(employeeList);
            }
        }
       
        
        private List<Employee> GetEmployeesFromAPI()
        {
            try
            {
                List<Employee> resultList = new List<Employee>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync(wepApiURL)
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Employee>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return resultList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
