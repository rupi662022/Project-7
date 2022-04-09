using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PROJECT_5.Models.DAL;

namespace PROJECT_5.Models
{
    public class User
    {
        int userID;
        string userName;
        string userEmail;
        string userPassword;
        string userCompany;

        public User() { }

        public User(int userID, string userName, string userEmail, string userPassword, string userCompany)
        {
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserCompany = userCompany;
        }

        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string UserCompany { get => userCompany; set => userCompany = value; }

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



        //קריאה
        public User ReadUser(string userEmail)
        {
            DataServices ds = new DataServices();
            return ds.ReadUser(userEmail);
        }

        ////}
        //public User ReadUser()/*---READ test for Procedures*/
        //{
        //    //int res = 0;
        //    DataServices ds = new DataServices();
        //    ds.ReadUser(this);

        //}




    }
}