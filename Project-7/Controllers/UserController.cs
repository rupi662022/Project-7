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
    public class UserController : ApiController
    {


        [HttpGet]
        [Route("api/User/userID")]
        public IEnumerable<GatePass> Get(int userID)
        {
            User U = new User();
            return U.ReadMyGatePass(userID);
        }

        
        [HttpGet]
        [Route("api/User/{GetUsers}")]
        public IEnumerable<User> GetUsers()
        {
            User U = new User();
            return U.ReadUsers();
        }

        [HttpPut]
        [Route("api/User")]
        public HttpResponseMessage Put([FromBody] User u)
        {
            u.UpdateUser();
            return Request.CreateResponse(HttpStatusCode.Created);
        }


        [HttpPost]
        [Route("api/User/in")]
        public HttpResponseMessage Post([FromBody] User user)
        {
            user.InsertUser();
            return Request.CreateResponse(HttpStatusCode.Created);
        }




        [HttpGet]
        [Route("api/User/{userEmail}/Pass")]
        public User Get(string userEmail)
        {
            User U = new User();
            return U.ReadLogUser(userEmail);
        }



        [HttpDelete]
        [Route("api/User")]
        public HttpResponseMessage DeleteUser([FromBody] User u)
        {
            u.DeleteUser();
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        //// PUT: api/User/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}
    }
}
