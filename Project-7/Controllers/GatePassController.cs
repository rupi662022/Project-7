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
        public HttpResponseMessage Post([FromBody] GatePass g)
        {
            g.InsertGatePass();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("api/GatePass/isActive")]
        public IEnumerable<GatePass> Get(string isActive)
        {
            GatePass gatePass = new GatePass();
            return gatePass.ReadNegativGatePass(isActive);
        }

        [HttpGet]
        [Route("api/GatePass/{isActive}/{transportCompany}")]
        public IEnumerable<GatePass> Get(string userType, string transportCompany)
        {
            GatePass gatePass = new GatePass();
            return gatePass.ReadMygatePass(userType, transportCompany);
        }

        public IEnumerable<GatePass> Get()
        {
            GatePass gatePass = new GatePass();
            return gatePass.ReadgatePass();
        }
        //public List<GatePass> Get()
        //{
        //    GatePass gatePass = new GatePass();
        //    return gatePass.ReadgatePassList ();
        //}


        public HttpResponseMessage Delete([FromBody] GatePass gatePass)
        {
            gatePass.SendGateToArchive();
            return Request.CreateResponse(HttpStatusCode.Created);
        }




        //public void Put()
        //{
        //    GatePass g = new GatePass();
        //    g.UpdateGatePass(this);
        //}


        public HttpResponseMessage Put([FromBody] GatePass g)
        {
            g.UpdateGatePass();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

    }
}
