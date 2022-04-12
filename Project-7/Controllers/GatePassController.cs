﻿using System;
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

        public HttpResponseMessage Post([FromBody] GatePass g)
        {
            g.InsertGatePass();
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        public IEnumerable<GatePass> Get()
        {
            GatePass gatePass = new GatePass();
            return gatePass.ReadNegativGatePass();
        }

        //בדיקה לטבלה
        public List<GatePass> Get(string transportCompany)
        {
            GatePass gatePass = new GatePass();
            return gatePass.ReadgatePass(transportCompany);
        }

        //public List<GatePass> Get()
        //{
        //    GatePass gatePass = new GatePass();
        //    return gatePass.ReadgatePassList ();
        //}

        public void Put(int id)
        {
            GatePass gatePass = new GatePass();
            gatePass.SendGateToArchive(id);
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
