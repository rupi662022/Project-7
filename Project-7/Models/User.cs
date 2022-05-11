using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_7.Models.DAL;

namespace Project_7.Models
{
    public class User
    {
        int userID;
        string userName;
        string userEmail;
        string userPassword;
        string userCompany;
        string userType;
        List<GatePass> gatePassList;

        public User() { }

        public User(int userID, string userName, string userEmail, string userPassword, string userCompany, string userType)
        {
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserCompany = userCompany;
            UserType = userType;
            
        }

        public User(int userID, string userName, string userEmail, string userPassword, string userCompany, string userType, List<GatePass> gatePassList)

        {
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserCompany = userCompany;
            UserType = userType;
            List<GatePass> GatePassList=new List<GatePass>();

        }



        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string UserCompany { get => userCompany; set => userCompany = value; }
        public string UserType { get => userType; set => userType = value; }      
        internal List<GatePass> GatePassList { get => gatePassList; set => gatePassList = value; }


        //public User(string userEmail, string userPassword)
        //{

        //    UserEmail = userEmail;
        //    UserPassword = userPassword;

        //}

        public void InsertUser()
        {
            DataServices ds = new DataServices();
            ds.InsertUser(this);
        }

        public List<GatePass> ReadMyGatePass(int userID)
        {
            DataServices ds = new DataServices();
            return ds.ReadMyGatePass(userID);
        }

        public List<User> ReadUsers()
        {
            DataServices ds = new DataServices();
            return ds.ReadUsers();
        }

        //קריאה


        ////}
        public User ReadUser(string userEmail)/*---READ test for Procedures*/
        {
            //int res = 0;
            DataServices ds = new DataServices();
            return ds.ReadUser(userEmail);

        }




    }
}