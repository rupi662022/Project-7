﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_7.Models;

namespace PROJECT_7.Controllers
{
    public class TransportCompanyController : ApiController
    {
        // GET: api/TransportCompany
        public IEnumerable<TransportCompany> Get()
        {
            TransportCompany tCompany = new TransportCompany();
            return tCompany.ReadTransportCompany();
        }


        // GET: api/TransportCompany/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TransportCompany
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TransportCompany/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TransportCompany/5
        public void Delete(int id)
        {
        }
    }
}
