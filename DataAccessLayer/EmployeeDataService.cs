
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
        private string httpAddressParam = "http://vmdev26273.cloudapp.net/WEB/WebApiCores/api/{0}/Committee/PostReport";
        public EmployeeDataService()
        {
        }

        public List<Employee> GetDataEmployeeService(int? id)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                //if (id == null)
                //{
                    var jsonInformation = new WebClient().DownloadString(httpAddress);

                    //var jsonInformation = await httpClient.GetStringAsync(httpAddress);

                    return JsonConvert.DeserializeObject<List<Employee>>(jsonInformation);
                //}
                //else
                //{
                //    string addressParameter = string.Format(httpAddressParam, id.ToString());
                //    var jsonInformation = await httpClient.GetStringAsync(addressParameter);
                //    return JsonConvert.DeserializeObject<RootObject>(jsonInformation);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }

    public class RootObject
    {
        public List<Employee> records { get; set; }
    }
}
 