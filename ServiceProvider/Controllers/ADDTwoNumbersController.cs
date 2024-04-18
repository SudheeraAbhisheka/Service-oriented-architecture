using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServiceProvider.Controllers
{
    [RoutePrefix("api/addtwonumbers")]
    public class ADDTwoNumbersController : ApiController
    {
        [Route("add/{firstNumber}/{secondNumber}")]
        [Route("add")]
        [HttpGet]
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}