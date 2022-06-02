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
    public class GatePassController : ApiController
    {
        //[HttpPost]
        //[Route("api/GatePass")]
        public void Post([FromBody] GatePass g)
        {
            g.InsertGatePass();
            //return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("api/GatePass/isActive")]
        public IEnumerable<GatePass> Get(string isActive)
        {
            GatePass gatePass = new GatePass();
            return gatePass.ReadNegativGatePass(isActive);
        }



        public IEnumerable<GatePass> Get()
        {
            GatePass gatePass = new GatePass();
            return gatePass.ReadgatePass();
        }
 


        public HttpResponseMessage Delete([FromBody] GatePass gatePass)
        {
            gatePass.SendGateToArchive();
            return Request.CreateResponse(HttpStatusCode.Created);
        }




        public HttpResponseMessage Put([FromBody] GatePass g)
        {
            g.UpdateGatePass();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

    }
}
