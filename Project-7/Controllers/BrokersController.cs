﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_7.Models;

namespace Project_7.Controllers
{
    public class BrokersController : ApiController
    {
        //// GET: api/Drivers
        public IEnumerable<CustomsBroker> Get()
        {
            CustomsBroker b = new CustomsBroker();
            return b.ReadBrokers();
        }

        // GET: api/Drivers/5
        public string Get(int id)
        {
            return "value";
        }



        public HttpResponseMessage Post([FromBody] CustomsBroker b)
        {
            b.InsertBroker();
            return Request.CreateResponse(HttpStatusCode.Created);
        }




        public HttpResponseMessage Put([FromBody] CustomsBroker b)
        {
            b.UpdateBroker();
            return Request.CreateResponse(HttpStatusCode.Created);
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