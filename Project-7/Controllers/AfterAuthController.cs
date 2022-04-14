using Newtonsoft.Json;
using PROJECT_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PROJECT_7.Controllers
{
    public class AfterAuthController : ApiController
    {
        // GET: api/AfterAuth
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AfterAuth/5
        //[HttpGet]
        //[ActionName("GetList")]
        public string Get()
        {

            Email ToGetMsgID = new Email();
            return ToGetMsgID.GetEmailsList();

        }
        //[HttpGet]
        //[ActionName("GetFullMsg")]
        //public string GetFullMsg()
        //{



        //}

        // POST: api/AfterAuth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AfterAuth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AfterAuth/5
        public void Delete(int id)
        {
        }
    }
}
