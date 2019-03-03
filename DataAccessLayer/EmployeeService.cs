
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeService : IEmployeeService
    {

        private string httpAddress = "http://vmdev26273.cloudapp.net/WEB/WebApiCores/api/Committee/PostReport";
        private string httpAddressParam = "http://vmdev26273.cloudapp.net/WEB/WebApiCores/api/{0}/Committee/PostReport";
        public EmployeeService()
        {
        }

        public async Task<RootObject> GetDataEmployeeService(int? id)
        {
            HttpClient httpClient = new HttpClient();
            if (id == null)
            {
                var jsonInformation = await httpClient.GetStringAsync(httpAddress);
                return JsonConvert.DeserializeObject<RootObject>(jsonInformation);
            }
            else
            {
                string addressParameter = string.Format(httpAddressParam, id.ToString());
                var jsonInformation = await httpClient.GetStringAsync(addressParameter);
                return JsonConvert.DeserializeObject<RootObject>(jsonInformation);
            }
        }
    }

    public class RootObject
    {
        public List<Employee> records { get; set; }
    }
}
 