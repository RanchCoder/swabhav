using NinjectDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NinjectDemoApp.Controllers
{
    public class HomeController : ApiController
    {

        private readonly ICalculator _calculator;
        public HomeController(ICalculator calc)
        {
            _calculator = calc;
        }

        [HttpGet]
        public IHttpActionResult GetSum(int num1, int num)
        {
            int val = _calculator.sum(num1, num);
            return Ok(val);
        }
    }
}
