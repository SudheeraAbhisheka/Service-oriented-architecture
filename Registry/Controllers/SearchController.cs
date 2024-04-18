using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Text.Json;

namespace Registry.Controllers
{
    public class SearchController : ApiController
    {
        // GET: api/Search/"Hello"
        public List<Services> Get(string id)
        {
            var ctx = HttpContext.Current;
            string pathRead = ctx.Server.MapPath("~/App_Data/ReadFrom.txt");
            string pathWrite = ctx.Server.MapPath("~/App_Data/WriteTo.txt");

            List<Services> services = new List<Services>();
            using (StreamReader r = new StreamReader(pathRead))
            {
                string json = r.ReadToEnd();
                services = JsonSerializer.Deserialize<List<Services>>(json);
            }

            /*            List<Services> destination = services.Select(d => new Services
                        {
                            Sizes = d.Sizes,
                            Price = d.Price,
                            Expiry = d.Expiry,
                            Name = d.Name
                        }).ToList();*/


            List<Services> destination = new List<Services>();

            foreach (Services d in services)
            {
                Services inputObj = new Services();
                if (d.Name.Contains(id))
                {
                    inputObj.Name = d.Name;
                    inputObj.Description = d.Description;
                    inputObj.APIEndpoint = d.APIEndpoint;
                    inputObj.OperandType = d.OperandType;

                    destination.Add(inputObj);
                }
            }

/*            string jsonString = JsonSerializer.Serialize(destination, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter(pathWrite))
            {
                outputFile.WriteLine(jsonString);
            }*/
            return destination;
        }
    }
}