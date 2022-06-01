using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_7.Models.DAL;

namespace Project_7.Models
{
    public class GatePass
    {
        int id;
        string containerNum;
        string containerType;
        string transportCompany;
        string importer;
        string customsBroker;
        string shippingCompanyAndLine;
        string storageCertificate;
        string note;
        string isActive;
        string userEmail;
        DateTime createdDate;
        //User userID;

        public GatePass() { }






        public GatePass(int id,string containerNum, string containerType, string transportCompany, string importer, string customsBroker, string shippingCompanyAndLine, string storageCertificate, string note,  string isActive, string userEmail, DateTime createdDate)
        {
            this.id = id;
            this.containerNum = containerNum;
            this.containerType = containerType;
            this.transportCompany = transportCompany;
            this.importer = importer;
            this.customsBroker = customsBroker;
            this.shippingCompanyAndLine = shippingCompanyAndLine;
            this.storageCertificate = storageCertificate; 
            this.note = note;
            this.isActive = isActive;
            this.userEmail = userEmail;
            this.createdDate = createdDate;
            //this.userID = userID;
        }

        public int Id { get => id; set => id = value; }
        public string ContainerNum { get => containerNum; set => containerNum = value; }
        public string ContainerType { get => containerType; set => containerType = value; }
        public string TransportCompany { get => transportCompany; set => transportCompany = value; }
        public string Importer { get => importer; set => importer = value; }
        public string CustomsBroker { get => customsBroker; set => customsBroker = value; }
        public string ShippingCompanyAndLine { get => shippingCompanyAndLine; set => shippingCompanyAndLine = value; }
        public string StorageCertificate { get => storageCertificate; set => storageCertificate = value; }
        public string Note { get => note; set => note = value; }
        public string IsActive { get => isActive; set => isActive = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        //public User UserID { get => userID; set => userID = value; }

        //הכנס גייטפס 
        public int InsertGatePass()
        {
           
            DataServices ds = new DataServices();
            return ds.InsertGatePass(this);
           
        }

        //הבא את הגייטפסים הלא פעילים-בארכיון

        public List<GatePass> ReadNegativGatePass(string isActive)
        {
            DataServices ds = new DataServices();
            return ds.ReadNegativGatePass(isActive);
        }


        //הבא את הגייטפסים הפעילים
        public List<GatePass> ReadgatePass()
        {
            DataServices ds = new DataServices();
            return ds.ReadgatePass();
        }

        //שליחה לארכיון במידה וביצענו מחיקה
        public void SendGateToArchive()
        {
            DataServices ds = new DataServices();
            ds.SendGateToArchive(this);
        }

       

        //עדכון רשומה
        public int UpdateGatePass()
        {
            DataServices ds = new DataServices();
            return ds.UpdateGatePass(this);
        }


    }
}