using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace ServiceProvider.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            Services services = new Services
            {
                Name = "Orange",
                Expiry = new DateTime(2010, 07, 23),
                Price = 8.22M,
                Sizes = new[] { "Small", "Large" }
            };

            Post(services);
            return "value";
        }

        // POST api/values
        public void Post([FromBody] Services services)
        {

            string path = @"C:\Users\abhis\Documents\Y2S2\dc\Assignment1\Authenticator\Authenticator\Data\WebAPI.txt";

/*            Services services = new Services
            {
                Name = "Apple",
                Expiry = new DateTime(2008, 12, 28),
                Price = 3.99M,
                Sizes = new[] { "Small", "Medium", "Large" }
            };*/

            string json = JsonConvert.SerializeObject(services, Formatting.Indented);

            Services deserializedProduct = JsonConvert.DeserializeObject<Services>(json);

            File.AppendAllText(path, json + Environment.NewLine);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class Services
    {
        public String[] Sizes { get; set; }
        public decimal Price { get; set; }
        public DateTime Expiry { get; set; }
        public string Name { get; set; }
    }
}
