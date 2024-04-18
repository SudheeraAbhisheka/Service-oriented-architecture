using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServiceProvider.Controllers
{
    [RoutePrefix("api/multwonumbers")]
    public class MulThreeNumbersController : ApiController
    {
        [Route("mul/{firstNumber}/{secondNumber}/{thirdNumber}")]
        [Route("mul")]
        [HttpGet]
        public int Mul(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber * secondNumber * thirdNumber;
        }
    }
}