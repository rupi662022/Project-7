using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_7.Models;

namespace Project_7.Controllers
{
    public class DriversController : ApiController
    {
        //// GET: api/Drivers
        public IEnumerable<Driver> Get()
        {
            Driver driver = new Driver();
            return driver.ReadDrivers();
        }

        // GET: api/Drivers/5
        public string Get(int id)
        {
            return "value";
        }


        //[HttpPost]
        //[Route("api/Drivers")]
        public HttpResponseMessage Post([FromBody] Driver d)
        {
            d.InsertDriver();
            return Request.CreateResponse(HttpStatusCode.Created);
        }




        public HttpResponseMessage Put([FromBody] Driver d)
        {
            d.UpdateDrivers();
            return Request.CreateResponse(HttpStatusCode.Created);
        }


        public HttpResponseMessage Delete([FromBody] Driver d)
        {
            d.DeleteDriver();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // POST: api/Drivers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Drivers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Drivers/5
        public void Delete(int id)
        {

        }
    }
}
