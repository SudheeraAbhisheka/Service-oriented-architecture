using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServiceProvider.Controllers
{
    [RoutePrefix("api/addthreenumbers")]
    public class ADDThreeNumbersController : ApiController
    {
        [Route("add/{firstNumber}/{secondNumber}/{thirdNumber}")]
        [Route("add")]
        [HttpGet]
        public int Add(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }
    }
}