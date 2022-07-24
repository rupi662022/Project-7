using System;
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


        public int Post([FromBody] CustomsBroker b)
        {
            return b.InsertBroker();
        }


    
        public IEnumerable<CustomsBroker> Get()
        {
            CustomsBroker b = new CustomsBroker();
            return b.ReadBrokers();
        }

        public string Get(int id)
        {
            return "value";
        }



        public HttpResponseMessage Put([FromBody] CustomsBroker b)
        {
            b.UpdateBroker();
            return Request.CreateResponse(HttpStatusCode.Created);
        }


        public HttpResponseMessage Delete([FromBody] CustomsBroker b)
        {
            b.DeleteBroker();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public void Put(int id, [FromBody]string value)
        {
        }

   
    }
}
