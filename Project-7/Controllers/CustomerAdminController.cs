using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_7.Models.DAL;
using Project_7.Models;

namespace Project_7.Controllers
{
    public class CustomerAdminController : ApiController
    {


        //public int Post([FromBody] CustomerAdmin c)
        //{
        //    return c.InsertCustomerAdmin();
        //}


        public IEnumerable<CustomerAdmin> Get()
        {
            CustomerAdmin admin = new CustomerAdmin();
            return admin.ReadCustomerAdmins();
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}



        //public HttpResponseMessage Put([FromBody] CustomerAdmin c)
        //{
        //    c.UpdateCustomerAdmin();
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}


        //public HttpResponseMessage Delete([FromBody] CustomerAdmin c)
        //{
        //    c.DeleteCustomerAdmin();
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}



        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {

        }
    }
}
