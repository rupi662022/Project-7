using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_7.Models.DAL;


namespace Project_7.Models
{
    public class TransportCompany
    {
        int companyId;
        string companyName;
        string companyAdress;
        string companyFax;
        string companyPhone;
        DateTime companyCreatedDate;

        public TransportCompany(int companyId, string companyName, string companyAdress, string companyFax, string companyPhone, DateTime companyCreatedDate)
        {
            this.CompanyId = companyId;
            this.CompanyName = companyName;
            this.CompanyAdress = companyAdress;
            this.CompanyFax = companyFax;
            this.CompanyPhone = companyPhone;
            this.CompanyCreatedDate = companyCreatedDate;
        }

        public int CompanyId { get => companyId; set => companyId = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string CompanyAdress { get => companyAdress; set => companyAdress = value; }
        public string CompanyFax { get => companyFax; set => companyFax = value; }
        public string CompanyPhone { get => companyPhone; set => companyPhone = value; }
        public DateTime CompanyCreatedDate { get => companyCreatedDate; set => companyCreatedDate = value; }


        public TransportCompany() { }




        public int InsertTransportComany()
        {
            DataServices ds = new DataServices();
            return ds.InsertTransportComany(this);
        }

        public int UpdateTransportComany()
        {
            DataServices ds = new DataServices();
            return ds.UpdateTransportComany(this);
        }


        



        public int DeleteTransportComany()
        {
            DataServices ds = new DataServices();
            return ds.DeleteTransportComany(this);
        }




        public List<TransportCompany> ReadTransportCompany()
        {
            DataServices ds = new DataServices();
            return ds.ReadTransportCompany();
        }

    }
}