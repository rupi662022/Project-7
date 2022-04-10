using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PROJECT_5.Models;

namespace Project_7.Controllers
{
    public class DriversController : ApiController
    {
        // GET: api/Drivers
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

        //public List<Driver> Get()
        //{
        //    Driver driver = new Driver();
        //    return driver.ReadDrivers();
        //}

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
