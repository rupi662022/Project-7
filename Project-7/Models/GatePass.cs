using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PROJECT_5.Models.DAL;

namespace PROJECT_5.Models
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
        string caseNumber;
        string note;
        string officeNote;
        string goToRepair;
        string returnFromRepair;
        string isActive;
        string userEmail;
        DateTime createdDate;


        public GatePass() { }




        //public GatePass(int id, string containerNum, string containerType, string transportCompany, string importer) { 
        //        this.id = id;
        //    this.containerNum = containerNum;
        //    this.containerType = containerType;
        //    this.transportCompany = transportCompany;
        //    this.importer = importer;
        //}



        public GatePass(int id,string containerNum, string containerType, string transportCompany, string importer, string customsBroker, string shippingCompanyAndLine, string storageCertificate, string caseNumber, string note, string officeNote, string goToRepair, string returnFromRepair, string isActive, string userEmail, DateTime createdDate)
        {
            this.id = id;
            this.containerNum = containerNum;
            this.containerType = containerType;
            this.transportCompany = transportCompany;
            this.importer = importer;
            this.customsBroker = customsBroker;
            this.shippingCompanyAndLine = shippingCompanyAndLine;
            this.storageCertificate = storageCertificate;
            this.caseNumber = caseNumber;
            this.note = note;
            this.officeNote = officeNote;
            this.goToRepair = goToRepair;
            this.returnFromRepair = returnFromRepair;
            this.isActive = isActive;
            this.userEmail = userEmail;
            this.createdDate = createdDate;
        }

        public int Id { get => id; set => id = value; }
        public string ContainerNum { get => containerNum; set => containerNum = value; }
        public string ContainerType { get => containerType; set => containerType = value; }
        public string TransportCompany { get => transportCompany; set => transportCompany = value; }
        public string Importer { get => importer; set => importer = value; }
        public string CustomsBroker { get => customsBroker; set => customsBroker = value; }
        public string ShippingCompanyAndLine { get => shippingCompanyAndLine; set => shippingCompanyAndLine = value; }
        public string StorageCertificate { get => storageCertificate; set => storageCertificate = value; }
        public string CaseNumber { get => caseNumber; set => caseNumber = value; }
        public string Note { get => note; set => note = value; }
        public string OfficeNote { get => officeNote; set => officeNote = value; }
        public string GoToRepair { get => goToRepair; set => goToRepair = value; }
        public string ReturnFromRepair { get => returnFromRepair; set => returnFromRepair = value; }
        public string IsActive { get => isActive; set => isActive = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public int InsertGatePass()
        {
            //int res = 0;
            DataServices ds = new DataServices();
            return ds.InsertGatePass(this);
            //return res;
        }

        ////בדיקה לטבלה  [HttpGet]
        //[Route("api/''/''")]
        public List<GatePass> ReadgatePass(string transportCompany)
        {
            DataServices ds = new DataServices();
            return ds.ReadgatePass(transportCompany);
        }


        //שליחה לארכיון במידה וביצענו מחיקה
        public void SendGateToArchive(int id)
        {
            DataServices ds = new DataServices();
            ds.SendGateToArchive(id);
        }


        public int UpdateGatePass()
        {
            DataServices ds = new DataServices();
            return ds.UpdateGatePass(this);
        }
   
        //public List<GatePass> ReadgatePassList()
        //{
        //    DataServices ds = new DataServices();
        //    return ds.ReadgatePassList();
        //}

    }
}