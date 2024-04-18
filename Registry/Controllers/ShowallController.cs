using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Registry.Controllers
{
    public class ShowallController : ApiController
    {
        // GET: api/Showall/"Hello"
        public List<Services> Get(string id)
        {
            var ctx = HttpContext.Current;
            string pathRead = ctx.Server.MapPath("~/App_Data/ReadFrom.txt");
            string pathWrite = ctx.Server.MapPath("~/App_Data/WriteTo.txt");

            List<Services> destination = new List<Services>();
            using (StreamReader r = new StreamReader(pathRead))
            {
                string json = r.ReadToEnd();
                destination = JsonSerializer.Deserialize<List<Services>>(json);
            }

/*            List<Services> destination = services.Select(d => new Services
            {
                Sizes = d.Sizes,
                Price = d.Price,
                Expiry = d.Expiry,
                Name = d.Name
            }).ToList();*/

            string jsonString = JsonSerializer.Serialize(destination, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter(pathWrite))
            {
                outputFile.WriteLine(jsonString);
            }

            return destination;
        }
    }
}