using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class WebApiController : ApiController
    {
        private IEmployeeSalaryService _employeeSalaryService;
        public WebApiController(IEmployeeSalaryService employeeSalaryService)
        {
            _employeeSalaryService = employeeSalaryService;
        }

        //public 

    }
}
