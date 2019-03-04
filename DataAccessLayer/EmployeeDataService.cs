
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class EmployeeDataService : IEmployeeDataService
    {

        private string httpAddress = "http://masglobaltestapi.azurewebsites.net/api/Employees";
        public EmployeeDataService()
        {
        }

        public List<Employee> GetDataEmployeeService()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                var jsonInformation = new WebClient().DownloadString(httpAddress);

                return JsonConvert.DeserializeObject<List<Employee>>(jsonInformation);

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
 