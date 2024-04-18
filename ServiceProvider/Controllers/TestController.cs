using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ServiceProvider.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("add/{firstN}/{secondN}")]
        [Route("add")]
        [HttpGet]
        // GET: Test

        public HttpResponseMessage Get(int firstN, int secondN)
        {
            int sum = firstN + secondN;
            int[] array = { sum, firstN, secondN };
            
            return Request.CreateResponse(HttpStatusCode.OK, array);
        }
    }
}