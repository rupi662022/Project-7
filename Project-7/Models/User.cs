﻿using System;
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
        string userType;
        bool isAdmin;
        List<GatePass> gatePassList;

        public User() { }

        public User(int userID, string userName, string userEmail, string userPassword, string userType,bool isAdmin)
        {
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserType = userType;
            IsAdmin= isAdmin;
        }

        public User(int userID, string userName, string userEmail, string userPassword, string userType,bool isAdmin, List<GatePass> gatePassList)

        {
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserType = userType;
            List<GatePass> GatePassList=new List<GatePass>();
            IsAdmin = isAdmin;

        }



        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string UserType { get => userType; set => userType = value; }      
        internal List<GatePass> GatePassList { get => gatePassList; set => gatePassList = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }



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

        public int UpdateUser()
        {
            DataServices ds = new DataServices();
            return ds.UpdateUser(this);
        }


    
        public User ReadLogUser(string userEmail)
       {
            DataServices ds = new DataServices();
            return ds.ReadLogUser(userEmail);

        }



        public int DeleteUser()
        {
            DataServices ds = new DataServices();
            return ds.DeleteUser(this);
        }
    }
}