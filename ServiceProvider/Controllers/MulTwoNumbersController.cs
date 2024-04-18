using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServiceProvider.Controllers
{
    [RoutePrefix("api/multwonumbers")]
    public class MulTwoNumbersController : ApiController
    {
        [Route("mul/{firstNumber}/{secondNumber}")]
        [Route("mul")]
        [HttpGet]
        public int Mul(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}